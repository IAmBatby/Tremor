using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Jellyxir : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 22;
			item.maxStack = 999;
			item.rare = 5;
			item.value = Item.buyPrice(0, 0, 3, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jellyxir");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchematorTile");
			recipe.AddRecipe();
		}
	}
}
