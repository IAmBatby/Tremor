using Terraria.ModLoader;

namespace Tremor.Ice.Items.Furniture
{
	public class IceSink : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Sink");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.width = 30;
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
			item.createTile = mod.TileType("IceSinkTile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWood", 6);
			recipe.AddIngredient(206);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}