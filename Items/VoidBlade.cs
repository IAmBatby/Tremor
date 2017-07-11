using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class VoidBlade : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 72;
        item.melee = true;
        item.width = 46;
        item.height = 48;
        item.useTime = 44;
        item.useAnimation = 44;
        item.useStyle = 1;
        item.knockBack = 3;
			item.shoot = mod.ProjectileType("VoidBladePro");
			item.shootSpeed = 12f;
        item.value = 12400;
        item.rare = 11;
        item.UseSound = SoundID.Item15;
        item.autoReuse = false;
        item.useTurn = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Void Blade");
      Tooltip.SetDefault("");
    }



    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
        recipe.AddIngredient(ItemID.HallowedBar, 25);
        recipe.AddIngredient(ItemID.Ectoplasm, 15);
        recipe.AddIngredient(null, "DarkMatter", 45);
        recipe.AddIngredient(null, "AirFragment", 10);
        recipe.AddIngredient(null, "FireFragment", 10);
        recipe.AddIngredient(null, "MultidimensionalFragment", 8);
        recipe.SetResult(this);
        recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
