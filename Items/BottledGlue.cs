using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BottledGlue : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 22;
			item.maxStack = 999;
			item.rare = 3;
			item.value = Item.buyPrice(0, 0, 5, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Glue");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(null, "LightBulb", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
