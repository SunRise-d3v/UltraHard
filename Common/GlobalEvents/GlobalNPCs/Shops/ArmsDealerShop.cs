using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.Shops
{
    public class ArmsDealerShop : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.ArmsDealer)
                return;

            void AddItem(int itemID, int priceInGold = 1, int stack = 1)
            {
                int slot = FindFreeSlot(items);
                if (slot == -1)
                    return;

                items[slot] = new Item();
                items[slot].SetDefaults(itemID);
                items[slot].stack = stack;
                items[slot].shopCustomPrice = Item.buyPrice(0, priceInGold);
            }

            // После Глаза Ктулху — Мушкет и гробовщик
            if (NPC.downedBoss1)
            {
                AddItem(ItemID.Musket, 15);
                AddItem(ItemID.TheUndertaker, 15);
            }

            // После Пчелы — Обрез
            if (NPC.downedQueenBee)
                AddItem(ItemID.Boomstick, 25);

            // После Скелетрона — Пистолет
            if (NPC.downedBoss3)
                AddItem(ItemID.FlintlockPistol, 30);

            // После Стенки Плоти — Заводная штурмовая винтовка
            if (Main.hardMode)
                AddItem(ItemID.ClockworkAssaultRifle, 50);

            // После Плантеры — Боевой дробовик
            if (NPC.downedPlantBoss)
                AddItem(ItemID.TacticalShotgun, 75);

            // После всех трёх механиков — Узи
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                AddItem(ItemID.Uzi, 100);

            // После Голема — Снайперская винтовка
            if (NPC.downedGolemBoss)
                AddItem(ItemID.SniperRifle, 150);

            // После Скелетрона Прайма — Огнемёт
            if (NPC.downedMechBoss3)
                AddItem(ItemID.Flamethrower, 80);

            // Боеприпасы
            if (NPC.downedMechBossAny) // После любого механика — Проклятая пуля
                AddItem(ItemID.CursedBullet, 3, 999);

            if (NPC.downedPlantBoss) // После Плантеры — Хлорофитовая пуля
                AddItem(ItemID.ChlorophyteBullet, 5, 999);

            if (Main.hardMode) // После Стенки Плоти — Ихоровая пуля
                AddItem(ItemID.IchorBullet, 4, 999);

            if (NPC.downedQueenSlime) // После Королевы слизней — Кристальная пуля
                AddItem(ItemID.CrystalBullet, 4, 999);

            if (NPC.downedBoss2) // После босса мирового зла — Ожерелье из акульих зубов
                AddItem(ItemID.SharkToothNecklace, 20);

            if (NPC.downedPlantBoss) // После Плантеры — Оптический прицел
                AddItem(ItemID.SniperScope, 60);
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