using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FleshWorkstation : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 48;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
                        item.rare = 1;
			item.consumable = true;
			item.value = 200;
			item.createTile = mod.TileType("FleshWorkstationTile");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Flesh Workstation");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Wood, 15);
        recipe.AddIngredient(null, "UntreatedFlesh", 10);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
	}
}
