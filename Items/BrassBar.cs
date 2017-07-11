using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BrassBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 300;
			item.rare = 5;
			item.createTile = mod.TileType("BrassBar");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Bar");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrassNugget", 2);
			recipe.AddIngredient(null, "Charcoal", 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "BlastFurnace");
			recipe.AddRecipe();
		}
	}
}
