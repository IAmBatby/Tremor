using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EbonstonePlatform : ModItem
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
			item.value = 2000;
			item.createTile = mod.TileType("EbonstonePlatform");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ebonstone Platform");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(61, 1);
        recipe.SetResult(this, 2);
        recipe.AddTile(17);
        recipe.AddRecipe();
    }
	}
}
