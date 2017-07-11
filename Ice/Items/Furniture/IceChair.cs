using Terraria.ModLoader;

namespace Tremor.Ice.Items.Furniture
{
	public class IceChair : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Chair");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.width = 16;
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
			item.createTile = mod.TileType("IceChairTile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWood", 4);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}