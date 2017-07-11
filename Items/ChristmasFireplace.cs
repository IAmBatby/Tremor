using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ChristmasFireplace : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 48;
			item.height = 32;
			item.maxStack = 99;
			item.rare = 1;
			item.createTile = mod.TileType("ChristmasFireplace");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Christmas Fireplace");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RedBrick, 10);
			recipe.AddIngredient(ItemID.Wood, 4);
			recipe.AddIngredient(ItemID.Torch, 2);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
