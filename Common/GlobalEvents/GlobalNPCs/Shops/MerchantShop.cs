using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.Shops
{
    public class MerchantShop : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.Merchant)
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

            // Полезные предметы по прогрессу
            if (NPC.downedBoss1)
            {
                AddItem(ItemID.SpelunkerPotion, 5);
                AddItem(ItemID.ShinePotion, 2);
            }

            if (NPC.downedBoss3)
            {
                AddItem(ItemID.IronskinPotion, 3);
                AddItem(ItemID.SwiftnessPotion, 3);
            }

            if (Main.hardMode)
            {
                AddItem(ItemID.LifeforcePotion, 10);
                AddItem(ItemID.EndurancePotion, 8);
            }

            if (NPC.downedPlantBoss)
            {
                AddItem(ItemID.RagePotion, 12);
                AddItem(ItemID.WrathPotion, 12);
            }
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