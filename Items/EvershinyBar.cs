using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EvershinyBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = 8;
			item.createTile = mod.TileType("EvershinyBar");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evershining Bar");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 2);
			recipe.SetResult(this);
			recipe.AddTile(133);
			recipe.AddRecipe();
		}
	}
}
