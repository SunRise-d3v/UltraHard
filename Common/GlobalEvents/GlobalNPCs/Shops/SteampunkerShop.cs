using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.Shops
{
    public class SteampunkerShop : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.Steampunker)
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

            // Технологические предметы
            if (Main.hardMode)
            {
                AddItem(ItemID.Teleporter, 50);
                AddItem(ItemID.Lever, 1);
            }

            if (NPC.downedMechBossAny)
            {
                AddItem(ItemID.Jetpack, 40);
                AddItem(ItemID.SteampunkBoiler, 25);
            }

            if (NPC.downedPlantBoss)
            {
                AddItem(ItemID.SteampunkWings, 75);
                AddItem(ItemID.Clentaminator, 100);
            }

            if (NPC.downedGolemBoss)
                AddItem(ItemID.SteampunkCup, 30);
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