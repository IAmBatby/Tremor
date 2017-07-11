using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Gloomstone : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.value = 100;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.rare = 3;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("GloomstoneTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gloomstone");
			Tooltip.SetDefault("");
		}



		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GloomstoneWall", 4);
			recipe.SetResult(this, 1);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
