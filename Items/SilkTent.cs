using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SilkTent : ModItem
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
			item.createTile = mod.TileType("SilkTentTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silk Tent");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 4);
			recipe.AddIngredient(ItemID.Silk, 5);
			recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.AddRecipe();
		}
	}
}
