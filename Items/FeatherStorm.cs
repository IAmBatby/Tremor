using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class FeatherStorm : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 22;
        item.ranged = true;
        item.width = 26;
        item.noUseGraphic = true;
        item.maxStack = 1;
        item.height = 30;
        item.useTime = 20;
        item.useAnimation = 20;
        item.shoot = mod.ProjectileType("HarpyFeather");
        item.shootSpeed = 19f; 
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 32000;
        item.rare = 3;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sharp Feathers");
      Tooltip.SetDefault("");
    }


public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    for (int i = 0; i < 1; ++i)
    {
        Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 2, type, damage, knockBack, Main.myPlayer);
    }
    return false;
}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Feather, 15);
        recipe.AddIngredient(ItemID.Cloud, 5);
        recipe.AddIngredient(null, "AirFragment", 14);
        recipe.SetResult(this);
	recipe.AddTile(16);
        recipe.AddRecipe();
    }
}}
