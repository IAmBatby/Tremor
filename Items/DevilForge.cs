using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DevilForge : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 50;
			item.height = 26;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("DevilForge");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devil Forge");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DemonBlood", 5);
			recipe.AddIngredient(ItemID.Hellstone, 25);
			recipe.AddIngredient(ItemID.Obsidian, 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
