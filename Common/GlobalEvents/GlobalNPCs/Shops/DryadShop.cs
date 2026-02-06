using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.Shops
{
    public class DryadShop : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.Dryad)
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

            // Всегда после прихода — продаёт лозу
            AddItem(ItemID.Vine, 1);

            // После Глаза Ктулху — Шипохват (ThornChakram)
            if (NPC.downedBoss1)
                AddItem(ItemID.ThornHook, 20);

            // После Короля слизней — Браслет ветра
            if (NPC.downedSlimeKing)
                AddItem(ItemID.FeralClaws, 10);

            // После Скелетрона — Дар природы и Роза джунглей
            if (NPC.downedBoss3)
            {
                AddItem(ItemID.NaturesGift, 5);
                AddItem(ItemID.JungleRose, 2);
            }

            // После Королевы пчёл — Цветочные ботинки
            if (NPC.downedQueenBee)
                AddItem(ItemID.FlowerBoots, 15);

            if (NPC.downedPlantBoss)
                AddItem(ItemID.Seedling, 10);
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

        public override bool? CanGoToStatue(NPC npc, bool toKingStatue)
            => null;
    }
}