using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	public class AncientBanner : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 48;
			item.height = 64;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;

			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 50000;
			item.rare = 11;
			item.createTile = mod.TileType("AncientBanner");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Banner");
			Tooltip.SetDefault("Increases life regeneration if placed");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Gloomstone", 10);
			recipe.AddIngredient(null, "UnstableCrystal", 2);
			recipe.AddIngredient(ItemID.AncientCloth, 25);
			recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.AddRecipe();
		}
	}
}
