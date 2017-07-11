using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StonePlatform : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 16;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
                        item.rare = 1;
			item.consumable = true;
			item.value = 0;
			item.createTile = mod.TileType("StonePlatform");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Stone Platform");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(3, 1);
        recipe.SetResult(this, 2);
        recipe.AddTile(17);
        recipe.AddRecipe();
    }
	}
}
