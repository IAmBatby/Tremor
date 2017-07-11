using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class GlacierFence : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = mod.WallType("GlacierFenceWall");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Fence");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWood", 1);
			recipe.SetResult(this, 4);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
