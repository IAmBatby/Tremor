using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class HolyJavelin : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 57;
        item.thrown = true;
        item.width = 18;
        item.noUseGraphic = true;
        item.maxStack = 999;
        item.consumable = true;
        item.height = 38;
        item.useTime = 32;
        item.useAnimation = 32;
        item.shoot = mod.ProjectileType("HolyJavelinPro");
        item.shootSpeed = 16f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 60;
        item.rare = 5;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Holy Javelin");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.HallowedBar, 1);
        recipe.SetResult(this, 50);
	recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
