using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.Shops
{
    public class DyeTraderShop : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.DyeTrader)
                return;

            void AddItem(int dyeID, int stack = 20, int priceInGold = 1)
            {
                int slot = FindFreeSlot(items);
                if (slot == -1)
                    return;

                items[slot] = new Item();
                items[slot].SetDefaults(dyeID);
                items[slot].stack = stack;
                items[slot].shopCustomPrice = Item.buyPrice(0, priceInGold);
            }

            // После каждого босса добавляем краски
            if (NPC.downedBoss1) // Глаз Ктулху
                AddItem(ItemID.RedDye, 20, 2);

            if (NPC.downedBoss2) // Пожиратель миров/Мозг Ктулху
                AddItem(ItemID.PurpleDye, 20, 2);

            if (NPC.downedBoss3) // Скелетрон
                AddItem(ItemID.BlueDye, 20, 2);

            if (NPC.downedQueenBee) // Королева пчёл
                AddItem(ItemID.YellowDye, 20, 2);

            if (NPC.downedDeerclops) // Циклоп-олень
                AddItem(ItemID.SilverDye, 20, 3);

            if (NPC.downedQueenSlime) // Королева слизней
                AddItem(ItemID.BrightSilverDye, 20, 3);

            if (NPC.downedMechBossAny) // Любой механик
                AddItem(ItemID.TealDye, 20, 5);

            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3) // Все механики
                AddItem(ItemID.LimeDye, 20, 5);

            if (NPC.downedPlantBoss) // Плантера
                AddItem(ItemID.GreenDye, 20, 8);

            if (NPC.downedGolemBoss) // Голем
                AddItem(ItemID.OrangeDye, 20, 10);

            if (NPC.downedMoonlord) // Лунный лорд
                AddItem(ItemID.CyanDye, 20, 15);
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