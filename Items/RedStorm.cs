using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RedStorm : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);

			item.damage = 64;
			item.ranged = true;
			item.melee = false;
			item.width = 22;
			item.height = 46;

			item.useTime = 7;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.shootSpeed = 30f;
			item.shoot = 1;
			item.knockBack = 3;
			item.useAmmo = AmmoID.Arrow;
			item.value = 85000;
			item.rare = 11;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Storm");
			Tooltip.SetDefault("Causes red lasers to fall from sky\n");
		}

		public override bool ConsumeAmmo(Player p)
		{
			return Main.rand.NextBool(2);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int i = Main.myPlayer;
			float num72 = item.shootSpeed;
			int num73 = item.damage;
			float num74 = item.knockBack;
			num74 = player.GetWeaponKnockback(item, num74);
			player.itemTime = item.useTime;
			Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
			Vector2 value = Vector2.UnitX.RotatedBy(player.fullRotation, default(Vector2));
			Vector2 vector3 = Main.MouseWorld - vector2;
			float num78 = Main.mouseX + Main.screenPosition.X - vector2.X;
			float num79 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
			if (player.gravDir == -1f)
			{
				num79 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector2.Y;
			}
			float num80 = (float)Math.Sqrt(num78 * num78 + num79 * num79);
			float num81 = num80;
			if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
			{
				num78 = player.direction;
				num79 = 0f;
				num80 = num72;
			}
			else
			{
				num80 = num72 / num80;
			}
			num78 *= num80;
			num79 *= num80;
			int num107 = 3;
			for (int num108 = 0; num108 < num107; num108++)
			{
				vector2 = new Vector2(player.position.X + player.width * 0.5f + Main.rand.Next(201) * -(float)player.direction + (Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
				vector2.X = (vector2.X + player.Center.X) / 2f + Main.rand.Next(-200, 201);
				vector2.Y -= 100 * num108;
				num78 = Main.mouseX + Main.screenPosition.X - vector2.X;
				num79 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
				if (num79 < 0f)
				{
					num79 *= -1f;
				}
				if (num79 < 20f)
				{
					num79 = 20f;
				}
				num80 = (float)Math.Sqrt(num78 * num78 + num79 * num79);
				num80 = num72 / num80;
				num78 *= num80;
				num79 *= num80;
				float speedX4 = num78 + Main.rand.Next(-40, 41) * 0.02f;
				float speedY5 = num79 + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(vector2.X, vector2.Y, speedX4, speedY5, 606, num73, num74, i, 0f, Main.rand.Next(5));
				Projectile.NewProjectile(vector2.X, vector2.Y, speedX4, speedY5, 606, num73, num74, i, 0f, Main.rand.Next(3));
				Projectile.NewProjectile(vector2.X, vector2.Y, speedX4, speedY5, 606, num73, num74, i, 0f, Main.rand.Next(1));
			}
			return false;
		}
	}
}
