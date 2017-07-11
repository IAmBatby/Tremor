using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items.Furniture
{
	public class IceGrandfatherClock : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glacier Wood Grandfather Clock");
            Tooltip.SetDefault("");
        }
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
			item.createTile = mod.TileType("IceGrandfatherClockTile");
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.IronBar, 3);
        recipe.AddIngredient(ItemID.Glass, 6);
        recipe.AddIngredient(null, "GlacierWood", 10);
        recipe.SetResult(this);
        recipe.AddTile(106);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.LeadBar, 3);
        recipe.AddIngredient(ItemID.Glass, 6);
        recipe.AddIngredient(null, "GlacierWood", 10);
        recipe.SetResult(this);
        recipe.AddTile(106);
        recipe.AddRecipe();
    }

	}
}