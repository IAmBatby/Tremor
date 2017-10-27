using Terraria.ModLoader;

namespace Tremor.Items.Sandstone
{
	public class SandstonePiano : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 62;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
			item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("SandstonePiano");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Piano");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(154, 4);
			recipe.AddIngredient(607, 15);
			recipe.AddIngredient(149);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
