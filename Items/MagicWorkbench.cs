using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MagicWorkbench : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 50;
			item.height = 26;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;

			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("MagicWorkbenchTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Workbench");
			Tooltip.SetDefault("Allows you to create scientific-magical things");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddIngredient(ItemID.MagicHat, 1);
			recipe.AddIngredient(ItemID.Bunny, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
