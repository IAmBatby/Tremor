using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class AltarofEnchantments : ModItem
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
        item.createTile = mod.TileType("AltarofEnchantmentsTile");
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Altar of Enchantments");
      Tooltip.SetDefault("Allows you to improve some items");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.StoneBlock, 30);
        recipe.AddIngredient(null, "StoneofLife", 2);
        recipe.AddIngredient(null, "Gloomstone", 30);
        recipe.AddIngredient(ItemID.Book, 1);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
