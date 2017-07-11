using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SteelBar : ModItem
{
    public override void SetDefaults()
    {

        item.width = 30;
        item.height = 24;
        item.maxStack = 99;
        item.value = 300;
        item.rare = 1;
        item.createTile = mod.TileType("SteelBar");
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Steel Bar");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.IronBar, 2);
        recipe.AddIngredient(null, "Charcoal", 2);
        recipe.SetResult(this);
	recipe.AddTile(null, "BlastFurnace");
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.LeadBar, 2);
        recipe.AddIngredient(null, "Charcoal", 2);
        recipe.SetResult(this);
	recipe.AddTile(null, "BlastFurnace");
        recipe.AddRecipe(); 
    }
}}
