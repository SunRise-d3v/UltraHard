using InPursuitOfSouls.Content.Items.OthersMaterials.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Content.Items.OtherItems.HealingItems
{
    /*public class EstusFlask : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.DrinkOld;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true; // Не расходуется
            Item.maxStack = 10;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(silver: 50);
            Item.healLife = 0; // мы сами восстановим здоровье
            Item.potion = false; // не считается зельем
        }

        public override bool? UseItem(Player player)
        {
            if (player.statLife < player.statLifeMax2)
            {
                player.statLife += 40;
                player.HealEffect(40, true);
            }

            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLife < player.statLifeMax2;
        }

        public override void AddRecipes()
        {
            Recipe estusFlask = Recipe.Create(ModContent.ItemType<EstusFlask>());
            estusFlask.AddIngredient(ItemID.HealingPotion, 2);
            estusFlask.AddIngredient(ItemID.Mushroom, 10);
            estusFlask.AddIngredient(ModContent.ItemType<Soul>(), 1000);
            estusFlask.AddCondition(Condition.DownedMechBossAny);
            estusFlask.AddTile(TileID.AlchemyTable);
            estusFlask.Register();
        }
    }*/
}