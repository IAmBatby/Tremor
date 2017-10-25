using Terraria.ModLoader;

namespace Tremor.Items.Argite
{
	public class ArgiteBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 3;
			item.createTile = mod.TileType("ArgiteBar");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Argite Bar");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ArgiteOre", 4);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
