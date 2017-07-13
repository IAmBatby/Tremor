using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Items
{
	public class NovaDye : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 24;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 2, 50, 0);
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Dye");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(null, "NovaFragment", 10);
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
