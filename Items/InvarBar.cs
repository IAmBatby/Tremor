using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class InvarBar : ModItem
{
    public override void SetDefaults()
    {

        item.width = 30;
        item.height = 24;
        item.maxStack = 99;
        item.value = 300;
        item.rare = 1;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Invar Bar");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "OldInvarPlate");
        recipe.SetResult(this, 4);
	recipe.AddTile(17);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "BrokenInvarShield");
        recipe.SetResult(this, 3);
	recipe.AddTile(17);
        recipe.AddRecipe(); 

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "MeltedInvarSword");
        recipe.SetResult(this, 2);
	recipe.AddTile(17);
        recipe.AddRecipe(); 
    }
}}
