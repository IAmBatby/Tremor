using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items.Furniture
{
	public class IceBathtub : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glacier Wood Bathtub");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
		{
			item.width = 64;
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
			item.createTile = mod.TileType("IceBathtubTile");
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GlacierWood", 14);
        recipe.SetResult(this);
        recipe.AddTile(18);
        recipe.AddRecipe();
    }
	}
}