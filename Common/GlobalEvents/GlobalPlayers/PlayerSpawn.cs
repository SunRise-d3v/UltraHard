using InPursuitOfSouls.Content.Items.OtherItems.StarterItems;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InPursuitOfSouls.Common.GlobalEvents.GlobalPlayers
{
    public class PlayerSpawn : ModPlayer
    {
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (mediumCoreDeath)
                yield break;

            else
            {
                if (Main.expertMode != false || Main.masterMode != false)
                {
                    Item starterBag = new Item();
                    starterBag.SetDefaults(ModContent.ItemType<StarterBag>(), false);
                    yield return starterBag;
                }
            }
        }
    }

    public class PlayerStartingInventory : ModPlayer
    {
        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            itemsByMod["Terraria"].Clear();

            /*Item pick = new Item(ItemID.CopperPickaxe);

            if (Main.rand.NextBool(5))
                //pick = new Item(ItemID.TinPickaxe);

            itemsByMod["Terraria"].Add(pick);*/
        }
    }
}