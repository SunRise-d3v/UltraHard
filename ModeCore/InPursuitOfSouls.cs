using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace InPursuitOfSouls.GameCore
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class InPursuitOfSouls : Mod
    {
        public static Texture2D SunOverlayTexture;
        public static Texture2D HeatOverlayTexture;
        public static Texture2D BrainOverlayTexture;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                SunOverlayTexture = ModContent.Request<Texture2D>("InPursuitOfSouls/Assets/Textures/SunOverlay", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
                HeatOverlayTexture = ModContent.Request<Texture2D>("InPursuitOfSouls/Assets/Textures/HeatDistortionOverlay", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
                BrainOverlayTexture = ModContent.Request<Texture2D>("InPursuitOfSouls/Assets/Textures/BrainNerveOverlay", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;}
        }

        public override void Unload()
        {
            SunOverlayTexture = null;
            HeatOverlayTexture = null;
            BrainOverlayTexture = null;
        }
    }
}