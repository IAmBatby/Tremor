using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CrimstoneBed : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 64;
			item.height = 26;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
                        item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("CrimstoneBed");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Crimstone Bed");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(836, 15);
        recipe.AddIngredient(1257, 1);
        recipe.AddIngredient(ItemID.Silk, 5);
        recipe.SetResult(this);
        recipe.AddTile(17);
        recipe.AddRecipe();
    }
	}
}
