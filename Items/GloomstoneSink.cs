using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GloomstoneSink : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
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
			item.createTile = mod.TileType("GloomstoneSink");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gloomstone Sink");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "Gloomstone", 6);
        recipe.AddIngredient(206);
        recipe.SetResult(this);
        recipe.AddTile(17);
        recipe.AddRecipe();
    }
	}
}
