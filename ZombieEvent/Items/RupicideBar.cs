using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items {
public class RupicideBar : ModItem
{
    public override void SetDefaults()
    {

        item.width = 30;
        item.height = 24;
        item.maxStack = 99;
        item.value = 100;
        item.rare = 2;
        item.createTile = mod.TileType("RupicideBar");
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Rupicide Bar");
      Tooltip.SetDefault("");
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "Rupicide", 4);
        recipe.SetResult(this);
	recipe.AddTile(17);
        recipe.AddRecipe();
    }
}}
