using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class KeyFish : ModItem
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
			DisplayName.SetDefault("Key Fish");
			Tooltip.SetDefault("");
		}

		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return NPC.downedBoss3;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "What is that? A fish in form of a key? A key in form of a fish? A fish that ate the key? I don't care because I just can't wait to see her!";
			catchLocation = "Dungeon";
		}
	}
}
