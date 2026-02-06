using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.Shops
{
    public class GoblinTinkererShop : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.GoblinTinkerer)
                return;

            void AddItem(int itemID, int priceInGold = 1)
            {
                int slot = FindFreeSlot(items);
                if (slot == -1)
                    return;

                items[slot] = new Item();
                items[slot].SetDefaults(itemID);
                items[slot].shopCustomPrice = Item.buyPrice(0, priceInGold);
            }

            // Инженерные предметы
            if (NPC.downedBoss1)
                AddItem(ItemID.SpikyBall, 1);

            if (NPC.downedBoss3)
                AddItem(ItemID.RocketBoots, 25);

            if (Main.hardMode)
            {
                AddItem(ItemID.TinkerersWorkshop, 10);
                AddItem(ItemID.SpelunkerGlowstick, 2);
            }

            if (NPC.downedMechBossAny)
                AddItem(ItemID.MechanicalLens, 30);

            if (NPC.downedPlantBoss)
                AddItem(ItemID.ArchitectGizmoPack, 50);
        }

        private int FindFreeSlot(Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null || items[i].IsAir)
                    return i;
            }

            return -1;
        }
    }
}