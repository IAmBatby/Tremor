using Terraria.ModLoader;

namespace Tremor.Ice.Items.Furniture
{
	public class IceDresser : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Dresser");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.width = 48;
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
			item.createTile = mod.TileType("IceDresserTile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWood", 16);
			recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.AddRecipe();
		}
	}
}