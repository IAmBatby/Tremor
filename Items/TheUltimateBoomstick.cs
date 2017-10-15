using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TheUltimateBoomstick : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 312;
			item.ranged = true;
			item.width = 78;
			item.height = 22;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 10;
			item.UseSound = SoundID.Item36;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 5f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Ultimate Boomstick");
			Tooltip.SetDefault("Has a chance to shoot moon flames\n" +
"'What can be better than a giant shotgun!?'");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{

			type = 638;

			if (Main.rand.Next(4) == 0)
			{
				type = 645;
			}

			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 2, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "VoidBar", 5);
			recipe.AddIngredient(3467, 5);
			recipe.AddIngredient(null, "MultidimensionalFragment", 10);
			recipe.AddIngredient(null, "ConcentratedEther", 15);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
