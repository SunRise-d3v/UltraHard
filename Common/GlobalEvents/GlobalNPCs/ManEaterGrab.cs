using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs
{
    public class ManEaterGrab : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        private int grabTimer = 0;           // сколько NPC держит игрока
        private int abilityCooldown = 0;     // перезарядка способности
        private Player grabbedPlayer;        // кого держит
        private static bool someoneIsGrabbing = false; // чтобы не хватали по очереди

        public override void AI(NPC npc)
        {
            if (npc.type != NPCID.ManEater && npc.type != NPCID.AngryTrapper)
                return;

            if (abilityCooldown > 0)
                abilityCooldown--;

            if (grabTimer > 0 && grabbedPlayer != null && grabbedPlayer.active)
            {
                grabTimer--;

                // Полный контроль над игроком (он не может двигаться, прыгать, атаковать)
                grabbedPlayer.velocity = Vector2.Zero;
                grabbedPlayer.controlJump = false;
                grabbedPlayer.controlLeft = false;
                grabbedPlayer.controlRight = false;
                grabbedPlayer.controlUseItem = false;
                grabbedPlayer.controlUseTile = false;

                Vector2 pullDir = npc.Center - grabbedPlayer.Center;
                grabbedPlayer.position += pullDir;

                // Маленький урон раз в 1 секунду
                if (Main.GameUpdateCount % 60 == 0)
                    grabbedPlayer.Hurt(
                        PlayerDeathReason.ByNPC(npc.whoAmI),
                        10, 0);

                // Когда время истекло — отпускаем
                if (grabTimer <= 0)
                {
                    grabbedPlayer = null;
                    someoneIsGrabbing = false;
                    abilityCooldown = 1000; // 30 секунд перезарядка
                }

                return;
            }

            // Если не держит никого и способность готова
            if (grabbedPlayer == null && abilityCooldown <= 0 && !someoneIsGrabbing)
            {
                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    Player player = Main.player[i];
                    if (player.active && !player.dead && Vector2.Distance(player.Center, npc.Center) < 60f)
                    {
                        grabbedPlayer = player;
                        grabTimer = Main.rand.Next(180, 300); // 2–4 секунды
                        someoneIsGrabbing = true;
                        break;
                    }
                }
            }
        }
    }
}
