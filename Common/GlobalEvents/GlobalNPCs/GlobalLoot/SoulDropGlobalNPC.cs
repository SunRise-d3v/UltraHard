using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using InPursuitOfSouls.Content.Items.OthersMaterials.Souls;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalNPCs.GlobalLoot
{
    public class SoulDropGlobalNPC : GlobalNPC
    {
        public static readonly HashSet<int> CorruptionNPCs = new()
        {
            NPCID.CochinealBeetle
        };

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.friendly || npc.townNPC || NPCID.Sets.CountsAsCritter[npc.type] || npc.type == NPCID.None)
                return;

            if (CorruptionNPCs.Contains(npc.type))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Soul>(), 1, 10, 50));
                return;
            }
            else if (npc.damage > 0)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Soul>(), 1, 1, 25));
                return;
            }
        }
    }
}
