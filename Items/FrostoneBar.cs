using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FrostoneBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 2000;
			item.rare = 7;
			item.createTile = mod.TileType("FrostoneBarTile");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostone Bar");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FrostoneOre", 2);
			recipe.AddIngredient(ItemID.Ectoplasm, 1);
			recipe.SetResult(this);
			recipe.AddTile(133);
			recipe.AddRecipe();
		}
	}
}
