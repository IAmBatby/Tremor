using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class MeatClub : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 52;
        item.melee = true;
        item.width = 44;
        item.height = 44;
        item.useTime = 26;
        item.useAnimation = 26;
        item.useStyle = 1;
        item.knockBack = 9;
        item.value = 60000;
        item.rare = 3;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Meat Club");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Wood, 5);
        recipe.AddIngredient(ItemID.Rope, 5);
        recipe.AddIngredient(null, "MeatChunk", 15);
        recipe.SetResult(this);
        recipe.AddTile(14);
        recipe.AddRecipe();
    }
}}
