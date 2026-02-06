using System.Linq;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using InPursuitOfSouls.Content.Items.OthersMaterials.Souls;
using InPursuitOfSouls.Buffs.Debuffs;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalPlayer
{
    public class GlobalPlayer : ModPlayer
    {
        #region QuickRespawn
        public override void UpdateDead()
        {
            if (!Main.npc.Any(n => n.active && n.boss) && Player.respawnTimer > 180)
                Player.respawnTimer = 180;
        }
        #endregion

        #region DashSystem
        public int dashCooldown = 120;
        public int dashDuration = 25;

        public int dashDir = -1;

        public int dashDelay = 0;
        public int dashTimer = 0;

        public const int dashRight = 2;
        public const int dashLeft = 3;

        public float dashVelocity;

        public override void ResetEffects()
        {
            Player.pickSpeed = 0.8f;
            if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[dashRight] < 15)
                dashDir = dashRight;
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[dashLeft] < 15)
                dashDir = dashLeft;
            else
                dashDir = -1;

            dashVelocity = 6.25f;
        }

        public override void PreUpdateMovement()
        {
            if (CanUseDash())
            {
                Vector2 newVelocity = Player.velocity;

                switch (dashDir)
                {
                    case dashLeft when Player.velocity.X > -dashVelocity:
                    case dashRight when Player.velocity.X < dashVelocity:
                        {
                            float dashDirection = dashDir == dashRight ? 1 : -1;
                            newVelocity.X = dashDirection * dashVelocity;
                            break;
                        }
                    default:
                        return;
                }

                dashDelay = dashCooldown;
                dashTimer = dashDuration;
                Player.velocity = newVelocity;
                SoundEngine.PlaySound(SoundID.DD2_MonkStaffSwing, Player.position);
            }

            if (dashDelay > 0)
                dashDelay--;

            if (dashTimer > 0)
            {
                Player.eocDash = dashTimer;
                dashTimer--;
            }
        }

        public bool CanUseDash()
        {
            return Player.dashType == 0
            && !Player.setSolar
            && dashDir != -1
            && dashDelay == 0
            && !Player.mount.Active;
        }
        #endregion

        #region Losing souls
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            int totalSoulsLost = 0;

            int[] soulTypes = new int[]
            {
                ModContent.ItemType<Soul>()
                // Добавь другие типы душ
            };

            for (int i = 0; i < Player.inventory.Length; i++)
            {
                Item item = Player.inventory[i];

                if (item != null && soulTypes.Contains(item.type) && item.stack > 0)
                {
                    int amountToLose = (int)(item.stack * 0.1f);
                    if (amountToLose < 1 && item.stack >= 10)
                        amountToLose = 1;

                    if (amountToLose > 0)
                    {
                        item.stack -= amountToLose;
                        totalSoulsLost += amountToLose;

                        // Дроп в мир
                        Item.NewItem(Player.GetSource_Death(), Player.position, Player.width, Player.height, item.type, amountToLose);
                    }
                }
            }

            if (totalSoulsLost > 0 && Main.netMode != NetmodeID.Server)
            {
                // Цвет надписи
                Color textColor = new Color(136, 231, 136);

                // Создание текста
                int index = CombatText.NewText(Player.Hitbox, textColor, $"You lost {totalSoulsLost} soul{(totalSoulsLost == 1 ? "" : "s")}");

                // Установка длительности текста: 60 фреймов = 1 секунда
                if (index >= 0 && index < Main.combatText.Length && Main.combatText[index] != null)
                    Main.combatText[index].lifeTime = 60;
            }
        }
        #endregion

        #region Burning in hell
        public class BurnInHellPlayer : ModPlayer
        {
            public override void PostUpdate()
            {
                if (Player.ZoneUnderworldHeight)
                {
                    // Проверка на наличие предметов, защищающих от огня
                    bool hasFireProtection =
                        Player.lavaImmune || // Любая иммунность к лаве (аксессуары)
                        Player.fireWalk ||   // Ходьба по огню (например, Obsidian Skull)
                        Player.HasBuff(BuffID.ObsidianSkin); // Зелье обсидиановой кожи

                    if (!hasFireProtection)
                        // Накладываем эффект горения, если нет защиты
                        Player.AddBuff(BuffID.OnFire, 5); // Обновляется каждые 2 тика (~0.03 секунды)
                }
            }
        }
        #endregion

        #region Quick death in water
        public class DrownFasterPlayer : ModPlayer
        {
            private float drownDamageCooldown = 0;

            public override void PostUpdate()
            {
                if (Player.wet && !Player.lavaWet && !Player.honeyWet)
                {
                    // Уменьшаем воздух в 2 раза быстрее
                    if (Player.breath > 0 && Main.GameUpdateCount % 2 == 0)
                    {
                        Player.breath--;
                    }

                    // Если воздух закончился — отключаем защиту от урона
                    if (Player.breath <= 0)
                    {
                        Player.breath = 0;
                        Player.breathCD = 0;

                        // Запускаем кулдаун урона
                        drownDamageCooldown--;
                        if (drownDamageCooldown <= 0)
                        {
                            int damage = 5; // Урон от удушья
                            Player.Hurt(PlayerDeathReason.ByOther(4), damage, 0);
                            drownDamageCooldown = 0.5f; // 1 секунда между ударами
                        }
                    }
                    else
                    {
                        drownDamageCooldown = 0; // сброс при наличии воздуха
                    }
                }
                else
                {
                    drownDamageCooldown = 0;
                }
            }
        }
        #endregion

        #region Instant death in lava
        public class InstantLavaDeath : ModPlayer
        {
            public override void PostUpdate()
            {
                if (Player.lavaWet && !HasLavaProtection()) // Игрок в лаве и без защиты
                {
                    Player.statLife = 0;

                    Player.KillMe(Terraria.DataStructures.PlayerDeathReason
                        .ByCustomReason(Player.name + " испарился в лаве"), 9999, 0);

                    for (int i = 0; i < 50; i++)
                    {
                        Dust.NewDust(Player.position, Player.width, Player.height, DustID.Torch, 0f, 0f, 100, default, 3f);
                    }
                }
            }

            private bool HasLavaProtection()
            {
                return Player.lavaImmune ||
                       Player.HasBuff(BuffID.ObsidianSkin); // Зелье обсидиановой кожи
            }
        }
        #endregion

        #region Snow biome is not so safe
        public class FreezeInSnowPlayer : ModPlayer
        {
            private int freezeTimer = 0;
            private int freezeCooldown = 0;

            public override void PostUpdate()
            {
                if (Player.ZoneSnow) // Игрок в снежном биоме
                {
                    freezeCooldown--;

                    if (freezeCooldown <= 0)
                    {
                        freezeTimer = 60; // Длительность заморозки (60 тиков = 1 секунда)
                        freezeCooldown = Main.rand.Next(1000, 1501); // 20–30 секунд перерыва (в тиках)
                    }
                }
                else
                {
                    freezeCooldown = 0;
                    freezeTimer = 0;
                }

                if (freezeTimer > 0)
                {
                    freezeTimer--;

                    // Применяем обездвиживание
                    Player.velocity = Vector2.Zero;
                    Player.controlLeft = false;
                    Player.controlRight = false;
                    Player.controlJump = false;
                    Player.controlDown = false;
                    Player.controlUp = false;
                    Player.controlUseItem = false;
                    Player.controlUseTile = false;
                    Player.controlHook = false;
                    Player.controlMount = false;
                    Player.controlQuickHeal = false;
                    Player.controlQuickMana = false;

                    // Визуальный эффект (по желанию)
                    Player.AddBuff(BuffID.Frozen, 2);
                }
            }
        }

        public class ChillInSnowPlayer : ModPlayer
        {
            public override void PostUpdate()
            {
                if (Player.ZoneSnow)
                {
                    // Постоянно обновляем эффект замедления (Chilled)
                    Player.AddBuff(BuffID.Chilled, 2); // 2 тика = обновляется каждый кадр
                }
            }
        }
        #endregion

        public class ArachnophobiaPlayer : ModPlayer
        {
            public override void PostUpdate()
            {
                bool surroundedBySpiders = false;

                if (!IsInSpiderNest())
                {
                    int spiderCount = 0;
                    float detectionRadius = 600f; // Радиус в пикселях (~10 блоков)

                    foreach (NPC npc in Main.npc)
                    {
                        if (npc.active && npc.Distance(Player.Center) <= detectionRadius)
                        {
                            if (IsSpider(npc))
                            {
                                spiderCount++;
                                if (spiderCount >= 3)
                                {
                                    surroundedBySpiders = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (IsInSpiderNest() || surroundedBySpiders)
                {
                    Player.AddBuff(ModContent.BuffType<ArachnophobiaDebuff>(), 1); // 1 секунда
                }
            }

            private bool IsSpider(NPC npc)
            {
                return npc.type == NPCID.WallCreeper ||
                       npc.type == NPCID.WallCreeperWall ||
                       npc.type == NPCID.BlackRecluse ||
                       npc.type == NPCID.BlackRecluseWall;
            }

            private bool IsInSpiderNest()
            {
                int tileX = (int)(Player.Center.X / 16f);
                int tileY = (int)(Player.Center.Y / 16f);

                if (WorldGen.InWorld(tileX, tileY, 10))
                {
                    ushort wall = Main.tile[tileX, tileY].WallType;
                    return Player.ZoneDirtLayerHeight && (wall == WallID.SpiderUnsafe);
                }

                return false;
            }
        }

        public class EvilBleedPlayer : ModPlayer
        {
            public override void PostUpdate()
            {
                if (Player.ZoneCorrupt || Player.ZoneCrimson)
                    // Накладываем кровотечение постоянно
                    Player.AddBuff(BuffID.Bleeding, 2); // 2 тика (~0.03 сек) — постоянно обновляется
            }
        }

        public class DesertDebuffPlayer : ModPlayer
        {
            public override void PostUpdate()
            {
                // 🏜 Пустыня
                if (Player.ZoneDesert)
                    Player.AddBuff(BuffID.Slow, 2); // Замедление
            }
        }

        public class DarkCaveDebuffPlayer : ModPlayer
        {
            public override void PostUpdate()
            {
                // Проверяем: подземелье, но не ад и не святая область
                bool inCave = Player.ZoneRockLayerHeight || Player.ZoneDirtLayerHeight;

                if (inCave)
                {
                    // Получаем уровень освещённости вокруг игрока
                    Vector2 center = Player.Center / 32f; // Переводим в координаты тайлов
                    int x = (int)center.X;
                    int y = (int)center.Y;

                    // Проверка освещения: берём яркость в центре игрока
                    float light = Lighting.GetSubLight(Player.Center).Length();

                    if (light < 0.2f)
                        // Темно → даём дебафф
                        Player.AddBuff(BuffID.Darkness, 2);
                }
            }
        }

        public class SolarStrikePlayer : ModPlayer
        {
            private int sunStrikeTimer = 0;
            private int nextStrikeDelay = 0;

            public override void Initialize()
            {
                ResetTimer();
            }

            public override void PostUpdate()
            {
                if (Player.ZoneDesert && Main.dayTime && !Main.raining && !Player.HasBuff(BuffID.ObsidianSkin))
                {
                    sunStrikeTimer++;

                    if (sunStrikeTimer >= nextStrikeDelay * 60) // 60 тиков = 1 секунда
                    {
                        int damage = Main.rand.Next(25, 55); // урон от солнечного удара
                        Player.Hurt(PlayerDeathReason.ByCustomReason($"{Player.name} был поражён солнечным ударом."), damage, 0);

                        ResetTimer();
                    }
                }
                else
                    sunStrikeTimer = 0;
            }

            private void ResetTimer()
            {
                sunStrikeTimer = 0;
                nextStrikeDelay = Main.rand.Next(30, 61); // от 30 до 60 секунд
            }
        }

        public class ScreenShakePlayer : ModPlayer
        {
            private int shakeTime;
            private float shakePower;

            public void Shake(float power, int time)
            {
                shakePower = power;
                shakeTime = time;
            }

            public override void ModifyScreenPosition()
            {
                if (shakeTime > 0)
                {
                    Main.screenPosition += Main.rand.NextVector2Circular(shakePower, shakePower);
                    shakeTime--;
                }
            }
        }

        #region BasicStats
        public class PlayerProperties : ModPlayer
        {
            public override void PreUpdateMovement()
                => Player.moveSpeed += 0.365f;

            public override void PostUpdateRunSpeeds()
                => Player.maxRunSpeed *= 1.395f;

            public override void ResetEffects()
                => Player.pickSpeed = 0.3f;
        }
        #endregion
    }
}