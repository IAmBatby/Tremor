using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items.Furniture
{
	public class IceBed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Bed");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			item.width = 64;
			item.height = 26;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
			item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("IceBedTile");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWood", 15);
			recipe.AddIngredient(ItemID.Silk, 5);
			recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.AddRecipe();
		}
	}
}