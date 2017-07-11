using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BoneThrone : ModItem
{
    public override void SetDefaults()
    {

        item.width = 48;
        item.height = 64;
        item.maxStack = 999;
        item.value = 100;
        item.rare = 1;
        item.createTile = mod.TileType("BoneThrone");
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bone Throne");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Bone, 75);
        recipe.AddIngredient(ItemID.Silk, 15);
        recipe.SetResult(this);
        recipe.AddTile(106);
        recipe.AddRecipe();
    }
}}
