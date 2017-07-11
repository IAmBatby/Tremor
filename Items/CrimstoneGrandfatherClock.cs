using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CrimstoneGrandfatherClock : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 74;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
                        item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("CrimstoneGrandfatherClock");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Crimstone Grandfather Clock");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(836, 10);
        recipe.AddIngredient(ItemID.IronBar, 3);
        recipe.AddIngredient(ItemID.Glass, 6);
        recipe.AddIngredient(1257, 1);
        recipe.SetResult(this);
        recipe.AddTile(17);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(836, 10);
        recipe.AddIngredient(ItemID.LeadBar, 3);
        recipe.AddIngredient(ItemID.Glass, 6);
        recipe.AddIngredient(1257, 1);
        recipe.SetResult(this);
        recipe.AddTile(17);
        recipe.AddRecipe();
    }

	}
}
