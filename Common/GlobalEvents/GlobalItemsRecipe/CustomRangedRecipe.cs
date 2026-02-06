using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using InPursuitOfSouls.Content.Items.OthersMaterials.Souls;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalItemsRecipe
{
    public class CustomRangedRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            #region Pre HM Bow
            Recipe bloodRainBow1 = Recipe.Create(ItemID.BloodRainBow);
            bloodRainBow1.AddIngredient(ItemID.WanderingEyeBanner);
            bloodRainBow1.AddIngredient(ModContent.ItemType<Soul>(), 500);
            bloodRainBow1.AddCondition(Condition.DownedEyeOfCthulhu);
            bloodRainBow1.AddTile(TileID.DemonAltar);
            bloodRainBow1.Register();

            Recipe bloodRainBow2 = Recipe.Create(ItemID.BloodRainBow);
            bloodRainBow2.AddIngredient(ItemID.ZombieMermanBanner);
            bloodRainBow2.AddIngredient(ModContent.ItemType<Soul>(), 500);
            bloodRainBow1.AddCondition(Condition.DownedEyeOfCthulhu);
            bloodRainBow2.AddTile(TileID.DemonAltar);
            bloodRainBow2.Register();

            Recipe hellwingBow1 = Recipe.Create(ItemID.HellwingBow);
            hellwingBow1.AddIngredient(ItemID.HellbatBanner);
            hellwingBow1.AddCondition(Condition.DownedSkeletron);
            hellwingBow1.AddTile(TileID.Hellforge);
            hellwingBow1.Register();

            Recipe hellwingBow2 = Recipe.Create(ItemID.HellwingBow);
            hellwingBow2.AddIngredient(ItemID.MoltenFury);
            hellwingBow2.AddIngredient(ItemID.HellstoneBar, 11);
            hellwingBow2.AddIngredient(ItemID.Fireblossom, 5);
            hellwingBow2.AddCondition(Condition.DownedSkeletron);
            hellwingBow2.AddTile(TileID.Hellforge);
            hellwingBow2.Register();
            #endregion

            #region HM Bow
            Recipe marrow = Recipe.Create(ItemID.Marrow);
            marrow.AddIngredient(ItemID.SkeletonArcherBanner);
            marrow.AddTile(TileID.MythrilAnvil);
            marrow.Register();

            Recipe iceBow1 = Recipe.Create(ItemID.IceBow);
            iceBow1.AddIngredient(ItemID.IceBlock, 75);
            iceBow1.AddIngredient(ItemID.Shiverthorn, 10);
            iceBow1.AddIngredient(ItemID.SoulofLight, 10);
            iceBow1.AddIngredient(ItemID.PlatinumBow);
            iceBow1.AddTile(TileID.IceMachine);
            iceBow1.Register();

            Recipe iceBow2 = Recipe.Create(ItemID.IceBow);
            iceBow2.AddIngredient(ItemID.IceBatBanner);
            iceBow2.AddCondition(Condition.DownedQueenSlime);
            iceBow2.AddTile(TileID.IceMachine);
            iceBow2.Register();

            Recipe shadowFlameBow = Recipe.Create(ItemID.ShadowFlameBow);
            shadowFlameBow.AddIngredient(ItemID.GoblinWarriorBanner);
            shadowFlameBow.AddIngredient(ModContent.ItemType<Soul>(), 1500);
            shadowFlameBow.AddTile(TileID.DemonAltar);
            shadowFlameBow.Register();

            Recipe stakeLauncher = Recipe.Create(ItemID.StakeLauncher);
            stakeLauncher.AddIngredient(ItemID.SpookyWood, 125);
            stakeLauncher.AddIngredient(ItemID.Bone, 77);
            stakeLauncher.AddIngredient(ItemID.Cobweb, 50);
            stakeLauncher.AddIngredient(ModContent.ItemType<Soul>(), 2222);
            stakeLauncher.AddTile(TileID.MythrilAnvil);
            stakeLauncher.Register();
            #endregion

            #region Pre HM Guns
            Recipe redRyder = Recipe.Create(ItemID.RedRyder);
            redRyder.AddIngredient(ItemID.Present, 15);
            redRyder.AddTile(TileID.Anvils);
            redRyder.Register();
            #endregion

            #region HM Guns
            Recipe uzi = Recipe.Create(ItemID.Uzi);
            uzi.AddIngredient(ItemID.AngryTrapperBanner);
            uzi.AddTile(TileID.MythrilAnvil);
            uzi.Register();

            Recipe tacticalShotgun = Recipe.Create(ItemID.TacticalShotgun);
            tacticalShotgun.AddIngredient(ItemID.TacticalSkeletonBanner);
            tacticalShotgun.AddTile(TileID.MythrilAnvil);
            tacticalShotgun.Register();

            Recipe sniperRifle = Recipe.Create(ItemID.SniperRifle);
            sniperRifle.AddIngredient(ItemID.SkeletonSniperBanner);
            sniperRifle.AddTile(TileID.MythrilAnvil);
            sniperRifle.Register();
            #endregion

            #region Launchers
            Recipe rocketLauncher = Recipe.Create(ItemID.RocketLauncher);
            rocketLauncher.AddIngredient(ItemID.SkeletonCommandoBanner);
            rocketLauncher.AddTile(TileID.MythrilAnvil);
            rocketLauncher.Register();

            Recipe nailGun = Recipe.Create(ItemID.NailGun);
            nailGun.AddIngredient(ItemID.NailheadBanner);
            nailGun.AddTile(TileID.MythrilAnvil);
            nailGun.Register();
            #endregion
        }
    }
}