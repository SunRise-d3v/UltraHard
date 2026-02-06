using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs
{
    public class VultureShooter : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        private int featherShootTimer;

        public override void AI(NPC npc)
        {
            // Проверяем, что это именно стервятник
            if (npc.type == NPCID.Vulture && npc.HasValidTarget && !npc.friendly)
            {
                // Проверяем: находится ли он в воздухе
                bool isAirborne = npc.velocity.Y != 0f;

                if (isAirborne)
                {
                    featherShootTimer++;

                    if (featherShootTimer >= 90) // каждые 1.5 секунды
                    {
                        featherShootTimer = 0;
                        Player target = Main.player[npc.target];

                        // Направление к игроку
                        Vector2 direction = target.Center - npc.Center;
                        direction.Normalize();
                        direction *= 7f; // скорость снаряда

                        // Стреляем пером
                        int proj = Projectile.NewProjectile(
                            npc.GetSource_FromAI(),
                            npc.Center,
                            direction,
                            ProjectileID.HarpyFeather,   // перо
                            15,                     // урон
                            1f,                     // отбрасывание
                            Main.myPlayer
                        );

                        Main.projectile[proj].hostile = true;
                        Main.projectile[proj].friendly = false;

                        // Эффект выстрела
                        if (Main.netMode != NetmodeID.Server)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Cloud, direction.X * 0.2f, direction.Y * 0.2f);
                            }
                        }
                    }
                }
                else
                {
                    // Сброс таймера, если он на земле
                    featherShootTimer = 0;
                }
            }
        }
    }
}
