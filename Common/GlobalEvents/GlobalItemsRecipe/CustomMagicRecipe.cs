using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using InPursuitOfSouls.Content.Items.OthersMaterials.Souls;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalItemsRecipe
{
    public class CustomMagicRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            #region Pre HM Wands
            Recipe wandofSparking = Recipe.Create(ItemID.WandofSparking);
            wandofSparking.AddIngredient(ItemID.Wood, 15);
            wandofSparking.AddIngredient(ItemID.Torch, 99);
            wandofSparking.AddIngredient(ModContent.ItemType<Soul>(), 125);
            wandofSparking.AddTile(TileID.WorkBenches);
            wandofSparking.Register();

            Recipe thunderStaff1 = Recipe.Create(ItemID.ThunderStaff);
            thunderStaff1.AddIngredient(ItemID.OasisCrate, 5);
            thunderStaff1.AddIngredient(ModContent.ItemType<Soul>(), 150);
            thunderStaff1.AddTile(TileID.WorkBenches);
            thunderStaff1.Register();

            Recipe thunderStaff2 = Recipe.Create(ItemID.ThunderStaff);
            thunderStaff2.AddIngredient(ItemID.OasisCrateHard, 5);
            thunderStaff2.AddIngredient(ModContent.ItemType<Soul>(), 150);
            thunderStaff2.AddTile(TileID.WorkBenches);
            thunderStaff2.Register();

            Recipe Vilethorn1 = Recipe.Create(ItemID.Vilethorn);
            Vilethorn1.AddIngredient(ItemID.CorruptFishingCrate, 5);
            Vilethorn1.AddIngredient(ModContent.ItemType<Soul>(), 200);
            Vilethorn1.AddTile(TileID.DemonAltar);
            Vilethorn1.Register();

            Recipe Vilethorn2 = Recipe.Create(ItemID.Vilethorn);
            Vilethorn2.AddIngredient(ItemID.CorruptFishingCrateHard, 5);
            Vilethorn2.AddIngredient(ModContent.ItemType<Soul>(), 200);
            Vilethorn2.AddTile(TileID.DemonAltar);
            Vilethorn2.Register();
            #endregion

            #region HM Wands
            Recipe flowerofFrost = Recipe.Create(ItemID.FlowerofFrost);
            flowerofFrost.AddIngredient(ItemID.FlowerofFire);
            flowerofFrost.AddIngredient(ItemID.FrostCore);
            flowerofFrost.AddIngredient(ItemID.SoulofLight, 3);
            flowerofFrost.AddIngredient(ItemID.SoulofNight, 3);
            flowerofFrost.AddIngredient(ModContent.ItemType<Soul>(), 750);
            flowerofFrost.AddTile(TileID.CrystalBall);
            flowerofFrost.Register();

            Recipe FrostStaff1 = Recipe.Create(ItemID.FrostStaff);
            FrostStaff1.AddIngredient(ItemID.IceElementalBanner);
            FrostStaff1.AddIngredient(ModContent.ItemType<Soul>(), 1000);
            FrostStaff1.AddTile(TileID.CrystalBall);
            FrostStaff1.Register();

            Recipe FrostStaff2 = Recipe.Create(ItemID.FrostStaff);
            FrostStaff2.AddIngredient(ItemID.IcyMermanBanner);
            FrostStaff2.AddIngredient(ModContent.ItemType<Soul>(), 1000);
            FrostStaff2.AddTile(TileID.CrystalBall);
            FrostStaff2.Register();

            Recipe poisonStaff = Recipe.Create(ItemID.PoisonStaff);
            poisonStaff.AddIngredient(ItemID.BlackRecluseBanner);
            poisonStaff.AddIngredient(ModContent.ItemType<Soul>(), 1100);
            poisonStaff.AddTile(TileID.CrystalBall);
            poisonStaff.Register();

            Recipe unholyTrident = Recipe.Create(ItemID.UnholyTrident);
            unholyTrident.AddIngredient(ItemID.RedDevilBanner);
            unholyTrident.AddIngredient(ModContent.ItemType<Soul>(), 1250);
            unholyTrident.AddTile(TileID.CrystalBall);
            unholyTrident.Register();
            #endregion

            #region Magic Guns
            #endregion

            #region Spell Books
            Recipe demonScythe = Recipe.Create(ItemID.DemonScythe);
            demonScythe.AddIngredient(ItemID.DemonBanner);
            demonScythe.AddIngredient(ModContent.ItemType<Soul>(), 1300);
            demonScythe.AddTile(TileID.Bookcases);
            demonScythe.Register();

            Recipe magnetSphere1 = Recipe.Create(ItemID.MagnetSphere);
            magnetSphere1.AddIngredient(ItemID.BlueArmoredBonesBanner);
            magnetSphere1.AddIngredient(ModContent.ItemType<Soul>(), 1500);
            magnetSphere1.AddTile(TileID.Bookcases);
            magnetSphere1.Register();

            Recipe magnetSphere2 = Recipe.Create(ItemID.MagnetSphere);
            magnetSphere2.AddIngredient(ItemID.HellArmoredBonesBanner);
            magnetSphere2.AddIngredient(ModContent.ItemType<Soul>(), 1500);
            magnetSphere2.AddTile(TileID.Bookcases);
            magnetSphere2.Register();

            Recipe magnetSphere3 = Recipe.Create(ItemID.MagnetSphere);
            magnetSphere3.AddIngredient(ItemID.RustyArmoredBonesBanner);
            magnetSphere3.AddIngredient(ModContent.ItemType<Soul>(), 1500);
            magnetSphere3.AddTile(TileID.Bookcases);
            magnetSphere3.Register();
            #endregion

            #region Others
            Recipe crimsonRod1 = Recipe.Create(ItemID.CrimsonRod);
            crimsonRod1.AddIngredient(ItemID.CrimsonFishingCrate, 5);
            crimsonRod1.AddIngredient(ModContent.ItemType<Soul>(), 350);
            crimsonRod1.AddTile(TileID.Anvils);
            crimsonRod1.Register();

            Recipe crimsonRod2 = Recipe.Create(ItemID.CrimsonRod);
            crimsonRod2.AddIngredient(ItemID.CrimsonFishingCrateHard, 5);
            crimsonRod2.AddIngredient(ModContent.ItemType<Soul>(), 350);
            crimsonRod2.AddTile(TileID.Anvils);
            crimsonRod2.Register();

            Recipe nimbusRod = Recipe.Create(ItemID.NimbusRod);
            nimbusRod.AddIngredient(ItemID.AngryNimbusBanner);
            nimbusRod.AddIngredient(ModContent.ItemType<Soul>(), 600);
            nimbusRod.AddTile(TileID.CrystalBall);
            nimbusRod.Register();

            Recipe medusaHead = Recipe.Create(ItemID.MedusaHead);
            medusaHead.AddIngredient(ItemID.MedusaBanner);
            medusaHead.AddIngredient(ModContent.ItemType<Soul>(), 850);
            medusaHead.AddTile(TileID.CrystalBall);
            medusaHead.Register();

            Recipe shadowFlameHexDoll = Recipe.Create(ItemID.ShadowFlameHexDoll);
            shadowFlameHexDoll.AddIngredient(ItemID.GoblinWarriorBanner);
            shadowFlameHexDoll.AddIngredient(ModContent.ItemType<Soul>(), 1000);
            shadowFlameHexDoll.AddTile(TileID.CrystalBall);
            shadowFlameHexDoll.Register();
            #endregion
        }
    }
}