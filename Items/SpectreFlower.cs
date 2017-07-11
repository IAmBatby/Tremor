using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SpectreFlower : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 60;
        item.magic = true;
        item.width = 46;
        item.height = 48;
        item.mana = 15;
        item.useTime = 30;
        item.useAnimation = 30;
        item.useStyle = 1;
        item.noMelee = true;
        item.knockBack = 6;
        item.value = 30000;
        item.rare = 8;
        item.UseSound = SoundID.Item43;
        item.autoReuse = true;
        item.shoot = mod.ProjectileType("SpectreFlower");
        item.shootSpeed = 6f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Spectre Flower");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.SpectreBar, 17);
        recipe.SetResult(this);
	recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
