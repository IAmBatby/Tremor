using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EbonstoneTable : ModItem
	{
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
			item.createTile = mod.TileType("EbonstoneTable");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonstone Table");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(61, 8);
			recipe.AddIngredient(57, 1);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
