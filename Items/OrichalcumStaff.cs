using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class OrichalcumStaff : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 30;
        item.magic = true;
        item.mana = 8;
        item.width = 40;
        item.height = 40;
        item.useTime = 38;
        item.useAnimation = 38;
        item.useStyle = 5;
        item.noMelee = true;
        item.knockBack = 3;
        item.value = 18440;
        item.rare = 4;
        item.UseSound = SoundID.Item91;
        item.autoReuse = true;
        Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        item.shoot = mod.ProjectileType("OrichalcumBolt");
        item.shootSpeed = 15f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Orichalcum Staff");
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
        recipe.AddIngredient(ItemID.OrichalcumBar, 12);
        recipe.SetResult(this);
	recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
