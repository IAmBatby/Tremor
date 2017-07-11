using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PartyOver : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.useAnimation = 24;
			item.useTime = 9;

			item.width = 24;
			item.height = 14;
			item.shoot = 587;
			item.damage = 122;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.knockBack = 1.25f;
			item.scale = 0.85f;
			item.rare = 2;
			item.ranged = true;
			item.crit = 7;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Party Over");
      Tooltip.SetDefault("");
    }



public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
    {
        Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
        Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 2, type, damage, knockBack, Main.myPlayer);
    }
    return false;
}

		public override Vector2? HoldoutOffset()
		{
			return Vector2.Zero;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddIngredient(null, "ConcentratedEther", 8);
			recipe.AddIngredient(null, "CandyBar", 15);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
