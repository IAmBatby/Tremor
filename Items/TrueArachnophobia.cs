using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class TrueArachnophobia : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 49;
        item.melee = true;
        item.width = 66;
        item.height = 66;
        item.useTime = 35;
        item.useAnimation = 35;
        item.useStyle = 1;
        item.knockBack = 7;
        item.shoot = 379; 
        item.shootSpeed = 17f;
        item.value = 12500;
        item.rare = 8;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("True Arachnophobia");
      Tooltip.SetDefault("");
    }


public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
    {
        Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
    }
    return false;
}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "Arachnophobia", 1);
        recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
        recipe.SetResult(this);
        recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
