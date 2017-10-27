using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class GlacierWood : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.value = 1;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.rare = 1;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("GlacierWoodTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWoodWall", 4);
			recipe.SetResult(this, 1);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierFence", 4);
			recipe.SetResult(this, 1);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
