using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Sandstone
{
	public class SandstoneChest : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 18;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
			item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("SandstoneChest");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Chest");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(607, 8);
			recipe.AddIngredient(ItemID.IronBar, 2);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(607, 8);
			recipe.AddIngredient(ItemID.LeadBar, 2);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
