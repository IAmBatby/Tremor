using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SaturatedDagger : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 57;
        item.thrown = true;
        item.width = 26;
        item.noUseGraphic = true;
        item.maxStack = 999;
        item.consumable = true;
        item.height = 30;
        item.useTime = 20;
        item.useAnimation = 20;
        item.shoot = mod.ProjectileType("SaturatedDaggerPro");
        item.shootSpeed = 22f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 50;
        item.rare = 5;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Saturated Dagger");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ParaxydeShard", 1);
        recipe.SetResult(this, 75);
        recipe.AddTile(null, "AlchematorTile");
        recipe.AddRecipe();
    }
}}
