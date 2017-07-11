using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SandstoneChandelier : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
                        item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("SandstoneChandelier");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sandstone Chandelier");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(607, 4);
        recipe.AddIngredient(ItemID.Torch, 4);
        recipe.AddIngredient(ItemID.Chain, 1);
        recipe.SetResult(this);
        recipe.AddTile(17);
        recipe.AddRecipe();
    }
	}
}
