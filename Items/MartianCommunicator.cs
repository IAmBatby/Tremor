using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MartianCommunicator : ModItem
	{
		const int XOffset = 0;
		const int YOffset = -200;

		public override void SetDefaults()
		{

			item.width = 34;
			item.height = 30;
			item.maxStack = 20;

			item.value = 100;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Martian Communicator");
			Tooltip.SetDefault("Starts the Martian Madness");
		}

		public override bool CanUseItem(Player player)
		{
			return Main.hardMode && NPC.downedGolemBoss;
		}

		public override bool UseItem(Player player)
		{
			Main.StartInvasion(4);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 25);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.Wire, 40);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
