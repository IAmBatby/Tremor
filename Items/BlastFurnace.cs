using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BlastFurnace : ModItem
{
    public override void SetDefaults()
    {

        item.width = 28;
        item.height = 14;
        item.maxStack = 99;
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
        item.value = 150;
        item.createTile = mod.TileType("BlastFurnace");
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blast Furnace");
      Tooltip.SetDefault("Used to craft alloys");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.GrayBrick, 25);
        recipe.AddIngredient(null, "Charcoal", 15);
        recipe.AddIngredient(ItemID.LavaBucket, 1);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
