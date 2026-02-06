using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using InPursuitOfSouls.Content.Items.OthersMaterials.Souls;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalItemsRecipe
{
    public class CustomMeleeRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            #region Pre HM Sword
            Recipe bladedGlove = Recipe.Create(ItemID.BladedGlove);
            bladedGlove.AddIngredient(ItemID.Leather, 5);
            bladedGlove.AddIngredient(ItemID.IronBar, 7);
            bladedGlove.AddTile(TileID.WorkBenches);
            bladedGlove.Register();

            Recipe zombieArm = Recipe.Create(ItemID.ZombieArm);
            zombieArm.AddIngredient(ItemID.ZombieBanner);
            zombieArm.AddTile(TileID.WorkBenches);
            zombieArm.Register();

            Recipe antlionClaw = Recipe.Create(ItemID.AntlionClaw);
            antlionClaw.AddIngredient(ItemID.AntlionMandible, 11);
            antlionClaw.AddTile(TileID.WorkBenches);
            antlionClaw.Register();

            Recipe gladius1 = Recipe.Create(ItemID.Gladius);
            gladius1.AddIngredient(ItemID.GladiatorHelmet);
            gladius1.AddIngredient(ItemID.SilverBar, 15);
            gladius1.AddTile(TileID.Anvils);
            gladius1.Register();

            Recipe gladius2 = Recipe.Create(ItemID.Gladius);
            gladius2.AddIngredient(ItemID.GladiatorBreastplate);
            gladius2.AddIngredient(ItemID.SilverBar, 15);
            gladius2.AddTile(TileID.Anvils);
            gladius2.Register();

            Recipe gladius3 = Recipe.Create(ItemID.Gladius);
            gladius3.AddIngredient(ItemID.GladiatorLeggings);
            gladius3.AddIngredient(ItemID.SilverBar, 15);
            gladius3.AddTile(TileID.Anvils);
            gladius3.Register();

            Recipe gladius4 = Recipe.Create(ItemID.Gladius);
            gladius4.AddIngredient(ItemID.GreekSkeletonBanner);
            gladius4.AddTile(TileID.Anvils);
            gladius4.Register();

            Recipe boneSword = Recipe.Create(ItemID.BoneSword);
            boneSword.AddIngredient(ItemID.Bone, 100);
            boneSword.AddIngredient(ItemID.Cobweb, 50);
            boneSword.AddIngredient(ModContent.ItemType<Soul>(), 500);
            boneSword.AddTile(TileID.Anvils);
            boneSword.Register();

            Recipe candyCaneSword = Recipe.Create(ItemID.CandyCaneSword);
            candyCaneSword.AddIngredient(ItemID.CandyCaneBlock, 25);
            candyCaneSword.AddTile(TileID.WorkBenches);
            candyCaneSword.Register();

            Recipe katana1 = Recipe.Create(ItemID.Katana);
            katana1.AddIngredient(ItemID.IronBar, 20);
            katana1.AddIngredient(ItemID.Cobweb, 50);
            katana1.AddCondition(Condition.DownedEaterOfWorlds);
            katana1.AddTile(TileID.Anvils);
            katana1.Register();

            Recipe katana2 = Recipe.Create(ItemID.Katana);
            katana2.AddIngredient(ItemID.IronBar, 20);
            katana2.AddIngredient(ItemID.Cobweb, 50);
            katana2.AddCondition(Condition.DownedBrainOfCthulhu);
            katana2.AddTile(TileID.Anvils);
            katana2.Register();

            Recipe iceBlade = Recipe.Create(ItemID.IceBlade);
            iceBlade.AddIngredient(ItemID.IceBlock, 50);
            iceBlade.AddIngredient(ItemID.TungstenBar, 15);
            iceBlade.AddIngredient(ModContent.ItemType<Soul>(), 750);
            iceBlade.AddTile(TileID.IceMachine);
            iceBlade.Register();

            Recipe muramasa = Recipe.Create(ItemID.Muramasa);
            muramasa.AddIngredient(ItemID.Bone, 100);
            muramasa.AddIngredient(ItemID.PlatinumBar, 20);
            muramasa.AddCondition(Condition.DownedSkeletron);
            muramasa.AddTile(TileID.Anvils);
            muramasa.Register();

            Recipe starfury1 = Recipe.Create(ItemID.Starfury);
            starfury1.AddIngredient(ItemID.Star, 20);
            //starfury1.AddIngredient(ItemID.Cloud, 10);
            starfury1.AddIngredient(ItemID.PlatinumBroadsword);
            starfury1.AddIngredient(ModContent.ItemType<Soul>(), 750);
            starfury1.AddTile(TileID.SkyMill);
            starfury1.Register();

            Recipe starfury2 = Recipe.Create(ItemID.Starfury);
            starfury2.AddIngredient(ItemID.Star, 20);
            //starfury1.AddIngredient(ItemID.Cloud, 10);
            starfury2.AddIngredient(ItemID.GoldBroadsword);
            starfury2.AddIngredient(ModContent.ItemType<Soul>(), 750);
            starfury2.AddTile(TileID.SkyMill);
            starfury2.Register();

            Recipe starfury3 = Recipe.Create(ItemID.Starfury);
            starfury3.AddIngredient(ItemID.FloatingIslandFishingCrateHard, 5);
            starfury3.AddIngredient(ModContent.ItemType<Soul>(), 750);
            starfury3.AddTile(TileID.SkyMill);
            starfury3.Register();

            Recipe starfury4 = Recipe.Create(ItemID.Starfury);
            starfury4.AddIngredient(ItemID.FloatingIslandFishingCrate, 5);
            starfury4.AddIngredient(ModContent.ItemType<Soul>(), 750);
            starfury4.AddTile(TileID.SkyMill);
            starfury4.Register();

            Recipe enchantedSword1 = Recipe.Create(ItemID.EnchantedSword);
            enchantedSword1.AddIngredient(ItemID.GoldenCrate, 5);
            enchantedSword1.AddIngredient(ModContent.ItemType<Soul>(), 750);
            enchantedSword1.AddTile(TileID.Anvils);
            enchantedSword1.Register();

            Recipe enchantedSword2 = Recipe.Create(ItemID.EnchantedSword);
            enchantedSword2.AddIngredient(ItemID.Star, 15);
            enchantedSword2.AddIngredient(ItemID.PlatinumBar, 5);
            enchantedSword2.AddIngredient(ItemID.Wood, 10);
            enchantedSword2.AddIngredient(ModContent.ItemType<Soul>(), 750);
            enchantedSword2.AddTile(TileID.Anvils);
            enchantedSword2.Register();

            Recipe falconBlade = Recipe.Create(ItemID.FalconBlade);
            falconBlade.AddIngredient(ItemID.IronCrate, 5);
            falconBlade.AddTile(TileID.Anvils);
            falconBlade.Register();
            #endregion

            #region HM Sword
            Recipe iceSickle = Recipe.Create(ItemID.IceSickle);
            iceSickle.AddIngredient(ItemID.IceBlock, 150);
            iceSickle.AddIngredient(ItemID.FrozenTurtleShell);
            iceSickle.AddIngredient(ItemID.DeathSickle);
            iceSickle.AddIngredient(ModContent.ItemType<Soul>(), 2000);
            iceSickle.AddTile(TileID.MythrilAnvil);
            iceSickle.Register();

            Recipe frostbrand = Recipe.Create(ItemID.Frostbrand);
            frostbrand.AddIngredient(ItemID.IceBlock, 250);
            frostbrand.AddIngredient(ItemID.SoulofLight, 15);
            frostbrand.AddIngredient(ItemID.IceBlade);
            frostbrand.AddIngredient(ModContent.ItemType<Soul>(), 2000);
            frostbrand.AddTile(TileID.MythrilAnvil);
            frostbrand.Register();

            Recipe beamSword1 = Recipe.Create(ItemID.BeamSword);
            beamSword1.AddIngredient(ItemID.CobaltBar, 15);
            beamSword1.AddIngredient(ItemID.SoulofNight, 10);
            beamSword1.AddIngredient(ItemID.SilverBroadsword);
            beamSword1.AddIngredient(ModContent.ItemType<Soul>(), 1500);
            beamSword1.AddTile(TileID.MythrilAnvil);
            beamSword1.Register();

            Recipe beamSword2 = Recipe.Create(ItemID.BeamSword);
            beamSword2.AddIngredient(ItemID.ArmoredSkeletonBanner);
            beamSword2.AddIngredient(ModContent.ItemType<Soul>(), 1500);
            beamSword2.AddTile(TileID.MythrilAnvil);
            beamSword2.Register();

            Recipe hamBat = Recipe.Create(ItemID.HamBat);
            hamBat.AddIngredient(ItemID.GrilledSquirrel);
            hamBat.AddIngredient(ItemID.RoastedBird);
            hamBat.AddIngredient(ItemID.RoastedDuck);
            hamBat.AddIngredient(ItemID.Bacon);
            hamBat.AddCondition(Condition.Hardmode);
            hamBat.AddTile(TileID.MythrilAnvil);
            hamBat.Register();

            Recipe waffleIron = Recipe.Create(ItemID.WaffleIron);
            waffleIron.AddIngredient(ItemID.TitaniumBar, 33);
            waffleIron.AddIngredient(ItemID.SoulofLight, 15);
            waffleIron.AddIngredient(ItemID.SoulofNight, 15);
            waffleIron.AddIngredient(ModContent.ItemType<Soul>(), 3333);
            waffleIron.AddCondition(Condition.DownedMechBossAny);
            waffleIron.AddTile(TileID.MythrilAnvil);
            waffleIron.Register();

            Recipe deathSickle = Recipe.Create(ItemID.DeathSickle);
            deathSickle.AddIngredient(ItemID.ReaperBanner);
            deathSickle.AddIngredient(ModContent.ItemType<Soul>(), 1500);
            deathSickle.AddTile(TileID.MythrilAnvil);
            deathSickle.Register();

            Recipe Keybrand1 = Recipe.Create(ItemID.Keybrand);
            Keybrand1.AddIngredient(ItemID.BlueArmoredBonesBanner);
            Keybrand1.AddTile(TileID.HeavyWorkBench);
            Keybrand1.Register();

            Recipe Keybrand2 = Recipe.Create(ItemID.Keybrand);
            Keybrand2.AddIngredient(ItemID.HellArmoredBonesBanner);
            Keybrand2.AddTile(TileID.HeavyWorkBench);
            Keybrand2.Register();

            Recipe Keybrand3 = Recipe.Create(ItemID.Keybrand);
            Keybrand3.AddIngredient(ItemID.RustyArmoredBonesBanner);
            Keybrand3.AddTile(TileID.HeavyWorkBench);
            Keybrand3.Register();
            #endregion

            #region Pre HM Yoyos
            Recipe rally1 = Recipe.Create(ItemID.Rally);
            rally1.AddIngredient(ItemID.CrawdadBanner);
            rally1.AddTile(TileID.Anvils);
            rally1.Register();

            Recipe rally2 = Recipe.Create(ItemID.Rally);
            rally2.AddIngredient(ItemID.GiantShellyBanner);
            rally2.AddTile(TileID.Anvils);
            rally2.Register();

            Recipe rally3 = Recipe.Create(ItemID.Rally);
            rally3.AddIngredient(ItemID.GiantShellyBanner);
            rally3.AddTile(TileID.Anvils);
            rally3.Register();

            Recipe cascade = Recipe.Create(ItemID.Cascade);
            cascade.AddIngredient(ItemID.HellstoneBar, 15);
            cascade.AddIngredient(ItemID.CrimsonYoyo);
            cascade.AddIngredient(ItemID.Cobweb, 30);
            cascade.AddTile(TileID.Anvils);
            cascade.Register();
            #endregion

            #region HM Yoyos
            Recipe helFire = Recipe.Create(ItemID.HelFire);
            helFire.AddIngredient(ItemID.Cascade);
            helFire.AddIngredient(ItemID.HellstoneBar, 15);
            helFire.AddIngredient(ItemID.SoulofNight, 10);
            helFire.AddTile(TileID.Hellforge);
            helFire.Register();

            Recipe amarok = Recipe.Create(ItemID.Amarok);
            amarok.AddIngredient(ItemID.IceBlock, 100);
            amarok.AddIngredient(ItemID.Cobweb, 50);
            amarok.AddIngredient(ItemID.SoulofNight, 10);
            amarok.AddCondition(Condition.Hardmode);
            amarok.AddTile(TileID.IceMachine);
            amarok.Register();

            Recipe yelets = Recipe.Create(ItemID.Yelets);
            yelets.AddIngredient(ItemID.JungleYoyo);
            yelets.AddIngredient(ItemID.Stinger, 15);
            yelets.AddIngredient(ItemID.Vine, 5);
            yelets.AddIngredient(ItemID.JungleSpores, 20);
            yelets.AddIngredient(ItemID.SoulofNight, 10);
            yelets.AddCondition(Condition.Hardmode);
            yelets.AddTile(TileID.MythrilAnvil);
            yelets.Register();

            Recipe kraken = Recipe.Create(ItemID.Kraken);
            kraken.AddIngredient(ItemID.Code1);
            kraken.AddIngredient(ItemID.Bone, 200);
            kraken.AddIngredient(ItemID.Cobweb, 100);
            kraken.AddCondition(Condition.Hardmode);
            kraken.AddTile(TileID.Hellforge);
            kraken.Register();
            #endregion

            #region Pre HM Spears
            Recipe spear = Recipe.Create(ItemID.Spear);
            spear.AddIngredient(ItemID.GoldBar, 15);
            spear.AddIngredient(ItemID.IronBar, 7);
            spear.AddTile(TileID.Anvils);
            spear.Register();

            Recipe trident1 = Recipe.Create(ItemID.Trident);
            trident1.AddIngredient(ItemID.OceanCrate, 5);
            trident1.AddTile(TileID.Anvils);
            trident1.Register();

            Recipe trident2 = Recipe.Create(ItemID.Trident);
            trident2.AddIngredient(ItemID.OceanCrateHard, 5);
            trident2.AddTile(TileID.Anvils);
            trident2.Register();

            Recipe thunderSpear1 = Recipe.Create(ItemID.ThunderSpear);
            thunderSpear1.AddIngredient(ItemID.OasisCrateHard, 5);
            thunderSpear1.AddIngredient(ModContent.ItemType<Soul>(), 400);
            thunderSpear1.AddTile(TileID.Anvils);
            thunderSpear1.Register();

            Recipe thunderSpear2 = Recipe.Create(ItemID.ThunderSpear);
            thunderSpear2.AddIngredient(ItemID.OasisCrate, 5);
            thunderSpear2.AddIngredient(ModContent.ItemType<Soul>(), 400);
            thunderSpear2.AddTile(TileID.Anvils);
            thunderSpear2.Register();
            #endregion

            #region HM Spears
            Recipe obsidianSwordfish = Recipe.Create(ItemID.ObsidianSwordfish);
            obsidianSwordfish.AddIngredient(ItemID.Swordfish);
            obsidianSwordfish.AddIngredient(ItemID.Obsidian, 50);
            obsidianSwordfish.AddIngredient(ItemID.SoulBottleNight, 10);
            obsidianSwordfish.AddTile(TileID.Hellforge);
            obsidianSwordfish.Register();
            #endregion

            #region Pre HM Boomerangs
            Recipe fruitcakeChakram = Recipe.Create(ItemID.FruitcakeChakram);
            fruitcakeChakram.AddIngredient(ItemID.Present, 25);
            fruitcakeChakram.AddTile(TileID.WorkBenches);
            fruitcakeChakram.Register();

            Recipe bloodyMachete = Recipe.Create(ItemID.BloodyMachete);
            bloodyMachete.AddIngredient(ItemID.IronBar, 25);
            bloodyMachete.AddIngredient(ItemID.Wood, 10);
            bloodyMachete.AddIngredient(ModContent.ItemType<Soul>(), 300);
            katana1.AddCondition(Condition.NotInGraveyard);
            bloodyMachete.AddTile(TileID.Anvils);
            bloodyMachete.Register();

            Recipe shroomerang1 = Recipe.Create(ItemID.Shroomerang);
            shroomerang1.AddIngredient(ItemID.SporeBatBanner);
            shroomerang1.AddTile(TileID.WorkBenches);
            shroomerang1.Register();

            Recipe shroomerang2 = Recipe.Create(ItemID.Shroomerang);
            shroomerang2.AddIngredient(ItemID.GlowingMushroom, 100);
            shroomerang2.AddIngredient(ItemID.EnchantedBoomerang);
            shroomerang2.AddTile(TileID.WorkBenches);
            shroomerang2.Register();

            Recipe IceBoomerang1 = Recipe.Create(ItemID.IceBoomerang);
            IceBoomerang1.AddIngredient(ItemID.FrozenCrateHard, 5);
            IceBoomerang1.AddTile(TileID.IceMachine);
            IceBoomerang1.Register();

            Recipe IceBoomerang2 = Recipe.Create(ItemID.IceBoomerang);
            IceBoomerang2.AddIngredient(ItemID.FrozenCrate, 5);
            IceBoomerang2.AddTile(TileID.IceMachine);
            IceBoomerang2.Register();

            Recipe IceBoomerang3 = Recipe.Create(ItemID.IceBoomerang);
            IceBoomerang3.AddIngredient(ItemID.IceBlock, 100);
            IceBoomerang3.AddIngredient(ItemID.EnchantedBoomerang);
            IceBoomerang3.AddTile(TileID.IceMachine);
            IceBoomerang3.Register();
            #endregion

            #region HM Flails
            Recipe kOCannon = Recipe.Create(ItemID.KOCannon);
            kOCannon.AddIngredient(ItemID.ClownBanner);
            kOCannon.AddTile(TileID.MythrilAnvil);
            kOCannon.Register();
            #endregion
        }
    }
}