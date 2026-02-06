using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using InPursuitOfSouls.Content.Items.OthersMaterials.Souls;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalItemsRecipe
{
    public class CustomSummonerRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            #region Pre HM Minion-summoning weapons
            Recipe vampireFrogStaff1 = Recipe.Create(ItemID.VampireFrogStaff);
            vampireFrogStaff1.AddIngredient(ItemID.WanderingEyeBanner);
            vampireFrogStaff1.AddIngredient(ModContent.ItemType<Soul>(), 350);
            vampireFrogStaff1.AddTile(TileID.Anvils);
            vampireFrogStaff1.Register();

            Recipe vampireFrogStaff2 = Recipe.Create(ItemID.VampireFrogStaff);
            vampireFrogStaff2.AddIngredient(ItemID.ZombieMermanBanner);
            vampireFrogStaff2.AddIngredient(ModContent.ItemType<Soul>(), 350);
            vampireFrogStaff2.AddTile(TileID.Anvils);
            vampireFrogStaff2.Register();
            #endregion
        }
    }
}