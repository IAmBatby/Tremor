using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class AlchemyStation : ModItem
{
    public override void SetDefaults()
    {

        item.width = 50;
        item.height = 26;
        item.maxStack = 99;
        item.useTurn = true;
        item.autoReuse = true;

        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
        item.value = 150;
        item.createTile = mod.TileType("AlchemyStationTile");
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Alchemy Station");
      Tooltip.SetDefault("Allows you to create unusual potions and transformation of different materials");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Wood, 12);
        recipe.AddIngredient(null, "CarbonSteel", 12);
        recipe.AddIngredient(ItemID.SoulofLight, 12);
        recipe.AddIngredient(ItemID.SoulofNight, 12);
        recipe.AddIngredient(ItemID.Glass, 12);
        recipe.AddIngredient(ItemID.Bottle, 3);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
