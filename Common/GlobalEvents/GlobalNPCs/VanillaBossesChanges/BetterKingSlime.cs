using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static InPursuitOfSouls.Common.GlobalEvents.GlobalPlayer.GlobalPlayer;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.VanillaBossesChanges
{
    public class BetterKingSlime : ModNPC
    {
        private float customTimer;

        private int slamState;
        private float slamTimer;

        public override void Load() => On_NPC.UpdateNPC += OnUpdateNPC;
        public override void Unload() => On_NPC.UpdateNPC -= OnUpdateNPC;

        public override void SetDefaults()
        {
            NPC.Clone();
        }

        private void OnUpdateNPC(On_NPC.orig_UpdateNPC orig, NPC self, int j)
        {
            orig(self, j);
            if (self.type == NPCID.KingSlime && self.active && Main.netMode != NetmodeID.MultiplayerClient)
                CustomKingSlimeAI(self);
        }

        private void CustomKingSlimeAI(NPC npc)
        {
            Player player = Main.player[npc.target];
            if (!player.active || player.dead || Vector2.Distance(npc.Center, player.Center) > 1000f)
                return;

            customTimer++;

            if (customTimer % 300 == 0)
                ShootSpikeRainUpward(npc);

            if (customTimer % 600 == 0)
                SpawnSlimesAround(npc);

            if (customTimer % 400 == 0)
                DoSlamTowardPlayer(npc, player);

            if (customTimer % 900 == 0 && slamState == 0)
                StartSkySlam(npc);

            HandleSkySlam(npc);

        }

        private void ShootSpikeRainUpward(NPC npc)
        {
            Vector2 headPosition = npc.Center - new Vector2(0, npc.height / 2);
            int spikeCount = Main.rand.Next(20, 45 + 1);
            for (int i = 0; i < spikeCount; i++)
            {
                float angle = MathHelper.ToRadians(Main.rand.NextFloat(-60f, 60f));
                Vector2 velocity = Vector2.UnitY.RotatedBy(angle) * -Main.rand.NextFloat(6f, 9f);
                int proj = Projectile.NewProjectile(npc.GetSource_FromAI(), headPosition, velocity, ProjectileID.SpikedSlimeSpike, 15, 1f, Main.myPlayer);
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].hostile = true;
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].damage = 30;

                if (Main.rand.NextBool(3))
                    Dust.NewDustDirect(headPosition, 10, 10, DustID.BlueTorch).noGravity = true;
            }
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item21, npc.Center);
        }

        private void SpawnSlimesAround(NPC npc)
        {
            int slimeCount = Main.rand.Next(9, 18);
            int[] slimeTypes = new int[] {
            NPCID.GreenSlime, NPCID.BlueSlime, NPCID.RedSlime, NPCID.PurpleSlime,
            NPCID.YellowSlime, NPCID.BlackSlime, NPCID.IceSlime, NPCID.SandSlime,
            NPCID.JungleSlime, NPCID.SpikedIceSlime, NPCID.SpikedJungleSlime,
            NPCID.MotherSlime, NPCID.BabySlime, NPCID.LavaSlime, NPCID.DungeonSlime,
            NPCID.Pinky, NPCID.SlimeSpiked, NPCID.ToxicSludge, NPCID.CorruptSlime,
            NPCID.Slimeling, NPCID.Crimslime, NPCID.IlluminantSlime,
            NPCID.RainbowSlime, NPCID.HoppinJack
        };

            for (int i = 0; i < slimeCount; i++)
            {
                int chosenType = Main.rand.Next(slimeTypes);
                Vector2 spawnPos = npc.Center + new Vector2(Main.rand.NextFloat(-120f, 120f), -20f);
                int newSlime = NPC.NewNPC(npc.GetSource_FromAI(), (int)spawnPos.X, (int)spawnPos.Y, chosenType);
                if (newSlime < Main.maxNPCs)
                    Main.npc[newSlime].velocity = new Vector2(Main.rand.NextFloat(-2f, 2f), -3f);
            }

            Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit1, npc.Center);
        }

        private void DoSlamTowardPlayer(NPC npc, Player player)
        {
            Vector2 direction = player.Center - npc.Center;
            direction.Normalize();
            direction *= 10f; // Скорость рывка

            npc.velocity = new Vector2(direction.X, -5f); // Прыжок вперёд

            // Эффекты
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Water, direction.X * 0.5f, -2f);
            }

            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item74, npc.Center);
        }

        private void StartSkySlam(NPC npc)
        {
            slamState = 1;
            slamTimer = 0f;

            npc.velocity = new Vector2(0f, -18f);
            npc.netUpdate = true;

            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item62, npc.Center);
        }

        private void HandleSkySlam(NPC npc)
        {
            if (slamState == 0)
                return;

            slamTimer++;

            // Небольшая пауза в воздухе
            if (slamState == 1 && slamTimer > 12.5f)
            {
                npc.velocity.Y = 20f; // резкое падение
                slamState = 2;
                slamTimer = 0f;
            }

            // Приземление
            if (slamState == 2 && npc.velocity.Y == 0f)
            {
                DoSkyImpact(npc);
                slamState = 0;
            }
        }

        private void DoSkyImpact(NPC npc)
        {
            // 🟣 Тряска экрана
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player p = Main.player[i];
                if (p.active && !p.dead)
                {
                    p.GetModPlayer<ScreenShakePlayer>().Shake(18f, 25);
                }
            }

            float spacing = 110f;

            float left = Main.screenPosition.X - 200f;
            float right = Main.screenPosition.X + Main.screenWidth + 200f;

            for (float x = left; x < right; x += spacing)
            {
                Vector2 spawnPos = new Vector2(x, npc.Center.Y - 800f);

                int projectileType = Projectile.NewProjectile(
                    npc.GetSource_FromAI(),
                    spawnPos,
                    Vector2.UnitY * 12f, // ⬇ строго вниз
                    ProjectileID.BombSkeletronPrime,
                    25,
                    1f,
                    Main.myPlayer
                );
                Main.projectile[projectileType].tileCollide = false;
                Main.projectile[projectileType].hostile = true;
                Main.projectile[projectileType].friendly = false;
                //Main.projectile[projectileType].owner = -1;
                Main.projectile[projectileType].damage = 25;
            }


            // 💨 Визуал
            for (int i = 0; i < 40; i++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.BlueTorch,
                    Main.rand.NextFloat(-6, 6), -Main.rand.NextFloat(2, 6));
            }

            Terraria.Audio.SoundEngine.PlaySound(SoundID.DD2_MonkStaffGroundImpact, npc.Center);
        }
    }

    /*public class BetterKingSlimeDrop : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            // Проверка, что убит именно Король Слизень
            if (npc.type == NPCID.KingSlime)
            {
                // 5% шанс дропа PreciousJelly
                if (Main.rand.NextFloat() < 0.05f)
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ModContent.ItemType<PreciousJelly>());

                // 5% шанс дропа PreciousStone
                if (Main.rand.NextFloat() < 0.05f)
                    Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ModContent.ItemType<PreciousStone>());
            }
        }
    }*/
}