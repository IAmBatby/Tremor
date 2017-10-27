using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CoalFish : ModItem
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
			DisplayName.SetDefault("Coal Fish");
			Tooltip.SetDefault("");
		}

		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return NPC.downedBoss1;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "Oh, this wonderful underwater world! How much it hides.. There is a fish, black and dirty as coal.  Catch it and try not to drabble your hands!";
			catchLocation = "Anywhere";
		}
	}
}
