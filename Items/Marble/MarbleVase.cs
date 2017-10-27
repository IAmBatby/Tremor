using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Marble
{
	public class MarbleVase : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 22;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
			item.createTile = mod.TileType("MarbleVase");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Vase");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MarbleBlock, 10);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
