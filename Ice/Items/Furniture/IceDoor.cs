using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items.Furniture
{
	public class IceDoor : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glacier Wood Door");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
		{
			item.width = 24;
			item.height = 48;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
                        item.rare = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("IceDoorClosed");
		}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GlacierWood", 6);
        recipe.SetResult(this);
        recipe.AddTile(18);
        recipe.AddRecipe();
    }
	}
}