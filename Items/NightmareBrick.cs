using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NightmareBrick : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.value = 10000;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.rare = 11;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("NightmareBrickTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightmare Brick");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareBrickWall", 4);
			recipe.SetResult(this, 1);
			recipe.AddTile(17);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareOre", 1);
			recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.SetResult(this, 2);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
