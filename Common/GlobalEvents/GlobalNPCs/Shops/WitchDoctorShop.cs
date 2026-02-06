using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.Shops
{
    public class WitchDoctorShop : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.WitchDoctor)
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

            // После любого механика — Безоар
            if (NPC.downedMechBossAny)
                AddItem(ItemID.Bezoar, 15);

            // После Плантеры — Посох тики
            if (NPC.downedPlantBoss)
                AddItem(ItemID.PygmyStaff, 50);

            // После Голема — Глаз голема
            if (NPC.downedGolemBoss)
                AddItem(ItemID.GolemFist, 80);

            // Флаконы
            if (NPC.downedBoss1)
            {
                AddItem(ItemID.PoisonDart, 5);
                AddItem(ItemID.Blowpipe, 10);
            }

            if (NPC.downedQueenBee)
            {
                AddItem(ItemID.BeeCloak, 25);
                AddItem(ItemID.BeeGun, 35);
                AddItem(ItemID.HiveBackpack, 30);
            }

            // После Королевы слизней — Кукла-шедоуфляж-хекс
            if (NPC.downedQueenSlime)
            {
                AddItem(ItemID.QueenSlimeCrystal, 40);
                AddItem(ItemID.ShadowFlameHexDoll, 60);
            }

            // Снаряжение лягушки
            if (NPC.downedBoss1)
                AddItem(ItemID.FrogLeg, 20);

            if (Main.hardMode)
                AddItem(ItemID.FrogGear, 50);

            // После Циклопа-оленя — Топор восстановления
            if (NPC.downedDeerclops)
                AddItem(ItemID.AcornAxe, 15);
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