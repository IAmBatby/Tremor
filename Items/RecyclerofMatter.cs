using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class RecyclerofMatter : ModItem
{
    public override void SetDefaults()
    {

        item.width = 46;
        item.height = 46;
        item.maxStack = 99;
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
        item.value = 150;
        item.createTile = mod.TileType("RecyclerofMatterTile");
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Recycler of Matter");
      Tooltip.SetDefault("Allows to convert hardmode metals to their alternatives");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.StoneBlock, 50);
        recipe.AddIngredient(ItemID.TitaniumBar, 1);
        recipe.AddIngredient(ItemID.AdamantiteBar, 1);
        recipe.AddIngredient(ItemID.Glass, 20);
        recipe.AddIngredient(ItemID.LavaBucket, 1);
        recipe.SetResult(this);
        recipe.AddTile(null, "MagicWorkbenchTile");
        recipe.AddRecipe();
    }
}}
