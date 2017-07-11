using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StoneDoor : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 48;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.rare = 1;
			item.consumable = true;
			item.value = 0;
			item.createTile = mod.TileType("StoneDoorClosed");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Door");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3, 6);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
