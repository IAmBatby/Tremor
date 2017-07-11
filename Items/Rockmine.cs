using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class Rockmine : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 26;
        item.thrown = true;
        item.width = 26;
        item.noUseGraphic = true;
        item.maxStack = 999;
        item.consumable = true;
        item.height = 30;
        item.useTime = 25;
        item.useAnimation = 25;
        item.shoot = mod.ProjectileType("RockminePro");
        item.shootSpeed = 11f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 7;
        item.rare = 3;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Rockmine");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.StoneBlock, 15);
        recipe.AddIngredient(null, "RockHorn", 3);
        recipe.SetResult(this, 25);
        recipe.AddTile(14);
        recipe.AddRecipe();
    }
}}
