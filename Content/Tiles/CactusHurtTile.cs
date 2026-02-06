using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Content.Tiles
{
    public class CactusHurtTile : GlobalTile
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return true;
        }

        public override void NearbyEffects(int i, int j, int type, bool closer)
        {
            if (type == TileID.Cactus && Main.netMode != NetmodeID.Server)
            {
                Rectangle tileHitbox = new Rectangle(i * 16, j * 16, 16, 16);

                for (int p = 0; p < Main.maxPlayers; p++)
                {
                    Player player = Main.player[p];
                    if (player.active && !player.dead && player.Hitbox.Intersects(tileHitbox))
                    {
                        // Защита от многократного урона: ждём, пока игрок выйдет
                        if (!player.GetModPlayer<CactusHurtCooldown>().recentlyHurtByCactus)
                        {
                            int damage = Main.rand.Next(15, 26);
                            player.Hurt(PlayerDeathReason.ByCustomReason($"{player.name} got poked by a cactus."), damage, 0);
                            player.GetModPlayer<CactusHurtCooldown>().recentlyHurtByCactus = true;
                        }
                    }
                }
            }
        }
    }

    public class CactusHurtCooldown : ModPlayer
    {
        public bool recentlyHurtByCactus;
        private int cooldown;

        public override void ResetEffects()
        {
            if (cooldown > 0)
            {
                cooldown--;
                if (cooldown <= 0)
                    recentlyHurtByCactus = false;
            }
        }

        public override void UpdateDead()
        {
            cooldown = 0;
            recentlyHurtByCactus = false;
        }

        public override void PostUpdate()
        {
            if (recentlyHurtByCactus && cooldown == 0)
            {
                cooldown = 45; // 0.5 секунды между уронами
            }
        }
    }
}