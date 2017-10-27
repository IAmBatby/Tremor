using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Wood
{
	public class WoodenPiranha : ModItem
	{
		public override void SetDefaults()
		{

			item.questItem = true;
			item.maxStack = 1;
			item.width = 26;
			item.height = 26;
			item.uniqueStack = true;
			item.rare = -11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Piranha");
			Tooltip.SetDefault("");
		}

		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return NPC.downedBoss2;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "Imagine a piece of wood that had fallen into the lake. It could find the fins and tail and give rise to a new type of fish. Catch her for me, she's worth it!";
			catchLocation = "Jungle";
		}
	}
}
