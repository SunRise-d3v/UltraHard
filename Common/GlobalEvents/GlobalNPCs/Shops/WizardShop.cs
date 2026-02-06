using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.Shops
{
    public class WizardShop : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.Wizard)
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

            // После Плантеры — Жезл раздора
            if (NPC.downedPlantBoss)
                AddItem(ItemID.RodofDiscord, 100);

            // Зелья маны
            if (NPC.downedBoss1)
            {
                AddItem(ItemID.ManaPotion, 2);
                AddItem(ItemID.LesserManaPotion, 1);
            }

            if (Main.hardMode)
            {
                AddItem(ItemID.GreaterManaPotion, 5);
                AddItem(ItemID.SuperManaPotion, 10);
            }

            // Аксессуары для маны
            if (NPC.downedBoss3)
            {
                AddItem(ItemID.ManaRegenerationBand, 15);
                AddItem(ItemID.MagicCuffs, 25);
            }

            if (NPC.downedMechBossAny)
                AddItem(ItemID.CelestialCuffs, 50);

            // Книги
            if (NPC.downedBoss1)
                AddItem(ItemID.WaterBolt, 20);

            if (Main.hardMode)
            {
                AddItem(ItemID.CrystalStorm, 40);
                AddItem(ItemID.CursedFlames, 45);
            }

            if (NPC.downedPlantBoss)
                AddItem(ItemID.RainbowRod, 80);

            // Посохи
            if (NPC.downedBoss2)
                AddItem(ItemID.Vilethorn, 15);

            if (NPC.downedQueenBee)
                AddItem(ItemID.BeeGun, 25);

            if (Main.hardMode)
                AddItem(ItemID.GoldenShower, 35);

            if (NPC.downedMechBossAny)
                AddItem(ItemID.MagicDagger, 60);
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