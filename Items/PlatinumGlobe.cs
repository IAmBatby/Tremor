using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PlatinumGlobe : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 48;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 1;
			item.createTile = mod.TileType("PlatinumGlobe");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Globe");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ItemID.PlatinumBar, 5);
			recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.AddRecipe();
		}
	}
}
