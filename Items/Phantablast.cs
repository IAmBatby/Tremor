using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Phantablast : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 83;
			item.ranged = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 12;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 210000;
			item.rare = AmmoID.Bullet;
			item.useStyle = 5;
			item.UseSound = SoundID.Item36;
			item.noMelee = true;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 23f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phantablast");
			Tooltip.SetDefault("Fires your ammo in a blast\n50% chance to not consume ammo");
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 1; i < 6; i++)
			{
				// Randomize speed
				Vector2 velocity = new Vector2(speedX, speedY) * Main.rand.NextFloat(0.90f - i/100f, 1.10f + i/100f);
				// Randomize the angle
				float spread = MathHelper.ToRadians(5f);
				float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
				double baseAngle = velocity.ToRotation();
				double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
				velocity = ((float)randomAngle).ToRotationVector2() * baseSpeed;
				// Shoot
				Projectile.NewProjectile(position.X, position.Y, velocity.X, velocity.Y, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

		public override bool ConsumeAmmo(Player p)
			=> Main.rand.NextBool();

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientTechnology", 1);
			recipe.AddIngredient(3456, 30);
			recipe.AddIngredient(null, "AirFragment", 25);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
