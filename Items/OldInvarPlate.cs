using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class OldInvarPlate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 30;
			item.maxStack = 990;
			item.value = Item.sellPrice(silver: 3);
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Invar Plate");
			Tooltip.SetDefault("Broken and useless... But its materials could be reused");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.SetResult(mod.ItemType<InvarBar>(), 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.AddRecipe();
		}
	}
}
