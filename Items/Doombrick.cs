using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Doombrick : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.value = 2000;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.rare = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("DoombrickTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doombrick");
			Tooltip.SetDefault("");
		}



		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DoombrickWall", 4);
			recipe.SetResult(this, 1);
			recipe.AddTile(17);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Doomstone", 1);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.SetResult(this, 50);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
