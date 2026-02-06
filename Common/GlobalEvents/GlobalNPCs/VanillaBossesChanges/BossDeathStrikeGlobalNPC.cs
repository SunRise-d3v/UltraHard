using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.VanillaBossesChanges
{
    public class BossDeathStrikeGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            if (npc.boss && Main.rand.Next(100) == 0) // 1% шанс и только для боссов
            {
                int fatalDamage = target.statLife + target.statDefense * 2;
                target.Hurt(PlayerDeathReason.ByCustomReason($"{target.name} был уничтожен мощью босса {npc.FullName}!"), fatalDamage, 0);

                // Эффекты смерти
                for (int i = 0; i < 40; i++)
                    Dust.NewDust(target.position, target.width, target.height, DustID.Blood, Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-3, 3));

                Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCDeath6, target.Center); // Жуткий звук
            }
        }
    }
}