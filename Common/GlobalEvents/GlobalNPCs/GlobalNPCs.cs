using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs
{
    public class GlobalNPCs
    {

    }

    public class MimicSpawner : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (!Main.hardMode && !spawnInfo.Player.ZoneDungeon && !spawnInfo.PlayerSafe)
                pool[NPCID.Mimic] = 0.01f; // 1% шанс в любом месте
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Mimic && !Main.hardMode)
                npcLoot.RemoveWhere(rule => true); // Удаляет весь дроп
        }
    }

    public class TortoiseOneShotPlayer : ModPlayer
    {
        private int tortoiseCooldown = 0;

        public override void PostUpdate()
        {
            if (tortoiseCooldown > 0)
                tortoiseCooldown--;

            foreach (NPC npc in Main.npc)
            {
                if (!npc.active)
                    continue;

                if (npc.type == NPCID.GiantTortoise || npc.type == NPCID.IceTortoise)
                {
                    if (npc.Hitbox.Intersects(Player.Hitbox) && tortoiseCooldown <= 0)
                    {
                        if (Main.rand.NextFloat() < 0.4f) // 40% шанс
                        {
                            Player.Hurt(PlayerDeathReason.ByCustomReason($"{Player.name} был уничтожен черепашьим кувырком."), Player.statLife + 9999, 0);
                            Main.NewText("☠️ Черепаха провела смертельный таран!", Color.OrangeRed);
                        }

                        tortoiseCooldown = 60; // защита от многократного срабатывания (1 сек)
                    }
                }
            }
        }
    }

    public class GlobalNPCProperties : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (npc.friendly || npc.townNPC || NPCID.Sets.CountsAsCritter[npc.type] || npc.type == NPCID.None)
                return;

            if (!npc.friendly && npc.lifeMax >= 10)
            {
                if (npc.boss)
                {
                    npc.lifeMax = (int)(npc.lifeMax * 1.35f);
                    npc.damage = (int)(npc.damage * 1.2f);
                    npc.defense = (int)(npc.defense * 1.22f);
                    npc.knockBackResist = 0;
                    npc.lavaImmune = true;
                    npc.velocity *= (int)1.155f;
                }
                else if (npc.damage > 0)
                {
                    npc.lifeMax = (int)(npc.lifeMax * 1.2f);
                    npc.damage = (int)(npc.damage * 1.165f);
                    npc.defense = (int)(npc.defense * 1.245f);
                    npc.knockBackResist /= 1.1f;
                    npc.value *= (int)1.2f;
                    npc.velocity *= (int)1.2355f;
                }
            }
        }
    }

    public class GoldCritterDrop : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            // Проверяем, что это именно золотое животное
            if (npc.type == NPCID.GoldBird ||
                npc.type == NPCID.GoldBunny ||
                npc.type == NPCID.GoldButterfly ||
                npc.type == NPCID.GoldDragonfly ||
                npc.type == NPCID.GoldFrog ||
                npc.type == NPCID.GoldGoldfish ||
                npc.type == NPCID.GoldGrasshopper ||
                npc.type == NPCID.GoldLadyBug ||
                npc.type == NPCID.GoldMouse ||
                npc.type == NPCID.GoldSeahorse ||
                npc.type == NPCID.SquirrelGold ||
                npc.type == NPCID.GoldWorm)
            {
                int amount = Main.rand.Next(10, 16);
                Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemID.GoldCoin, amount);
            }
        }
    }
}