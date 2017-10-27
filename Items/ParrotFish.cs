using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ParrotFish : ModItem
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
			DisplayName.SetDefault("Parrot Fish");
			Tooltip.SetDefault("");
		}

		public override bool IsQuestFish()
		{
			return true;
		}

		//public override bool IsAnglerQuestAvailable()
		//{
		//return Main.downedInvasion3;
		//}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "This fish couldn't fly in the air so she decided to swim away from all the fuss. However, it's her problem and you should bring me this fish!";
			catchLocation = "Anywhere";
		}
	}
}
