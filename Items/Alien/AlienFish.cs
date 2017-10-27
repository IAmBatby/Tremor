using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Alien
{
	public class AlienFish : ModItem
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
			DisplayName.SetDefault("Alien Fish");
			Tooltip.SetDefault("");
		}

		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return NPC.downedMechBossAny;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "If a fish can't breathe under water without a suit, then it must be... an alien fish! Catch for me this valuable specimen!";
			catchLocation = "Anywhere";
		}
	}
}
