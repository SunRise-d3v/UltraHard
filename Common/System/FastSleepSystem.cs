using Terraria;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.Systems
{
    public class FastSleepSystem : ModSystem
    {
        private const double TimeSpeed = 50.0;

        public override void PostUpdateWorld()
        {
            foreach (Player player in Main.player)
            {
                if (player.active && player.sleeping.isSleeping)
                {
                    Main.time += TimeSpeed;

                    if (Main.dayTime && Main.time >= Main.dayLength)
                    {
                        Main.time = 0;
                        Main.dayTime = false;
                    }
                    else if (!Main.dayTime && Main.time >= Main.nightLength)
                    {
                        Main.time = 0;
                        Main.dayTime = true;
                    }

                    break;
                }
            }
        }
    }
}