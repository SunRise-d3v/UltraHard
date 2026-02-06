using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace InPursuitOfSouls.Buffs.Debuffs
{
    public class ArachnophobiaDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 5;
            player.AddBuff(BuffID.Confused, 2);
        }
    }
}