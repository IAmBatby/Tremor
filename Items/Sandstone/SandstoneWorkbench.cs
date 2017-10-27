using Terraria.ModLoader;

namespace Tremor.Items.Sandstone
{
	public class SandstoneWorkbench : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 16;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
			item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("SandstoneWorkbench");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Workbench");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(607, 10);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
