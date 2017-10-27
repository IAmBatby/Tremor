using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Armchair : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 42;
			item.height = 32;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
			item.createTile = mod.TileType("Armchair");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armchair");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ItemID.Silk, 6);
			recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.AddRecipe();
		}
	}
}
