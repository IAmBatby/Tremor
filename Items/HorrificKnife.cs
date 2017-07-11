using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class HorrificKnife : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 80;
        item.thrown = true;
        item.width = 26;
        item.noUseGraphic = true;
        item.maxStack = 999;
        item.consumable = true;
        item.height = 30;
        item.useTime = 20;
        item.useAnimation = 20;
        item.shoot = mod.ProjectileType("HorrificKnifePro");
        item.shootSpeed = 22f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 7;
        item.rare = 11;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Horrific Knife");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.ThrowingKnife, 50);
        recipe.AddIngredient(null, "ConcentratedEther", 1);               
        recipe.AddIngredient(null, "NightmareBar", 1);
        recipe.SetResult(this, 50);
        recipe.AddTile(412);
        recipe.AddRecipe();
    }
}}
