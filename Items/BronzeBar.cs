using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BronzeBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 1;
			item.createTile = mod.TileType("BronzeBar");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bronze Bar");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinOre, 2);
			recipe.AddIngredient(ItemID.CopperOre, 2);
			recipe.AddTile(null, "BlastFurnace");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
