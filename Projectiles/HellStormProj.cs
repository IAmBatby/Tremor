using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class HellStormProj : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 78;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.ranged = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hell Storm");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			float num = 1.57079637f;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			if (projectile.type == mod.ProjectileType("HellStormProj"))
			{
				projectile.ai[0] += 1f;
				int num2 = 0;
				if (projectile.ai[0] >= 120f)
				{
					num2++;
				}
				if (projectile.ai[0] >= 200f)
				{
					num2++;
				}
				if (projectile.ai[0] >= 280f)
				{
					num2++;
				}
				int num3 = 24;
				int num4 = 6;
				projectile.ai[1] += 1f;
				bool flag = false;
				if (projectile.ai[1] >= num3 - num4 * num2)
				{
					projectile.ai[1] = 0f;
					flag = true;
				}
				projectile.frameCounter += 1 + num2;
				if (projectile.frameCounter >= 4)
				{
					projectile.frameCounter = 0;
					projectile.frame++;
					if (projectile.frame >= 3)
					{
						projectile.frame = 0;
					}
				}
				if (projectile.soundDelay <= 0)
				{
					projectile.soundDelay = num3 - num4 * num2;
					if (projectile.ai[0] != 1f)
					{
						Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 5);
					}
				}
				if (flag && Main.myPlayer == projectile.owner)
				{
					bool flag2 = player.channel && player.CheckMana(player.inventory[player.selectedItem].mana, true, false) && !player.noItems && !player.CCed;
					if (flag2)
					{
						float scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
						Vector2 value2 = vector;
						Vector2 value3 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - value2;
						if (player.gravDir == -1f)
						{
							value3.Y = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - value2.Y;
						}
						Vector2 vector3 = Vector2.Normalize(value3);
						if (float.IsNaN(vector3.X) || float.IsNaN(vector3.Y))
						{
							vector3 = -Vector2.UnitY;
						}
						vector3 *= scaleFactor;
						if (vector3.X != projectile.velocity.X || vector3.Y != projectile.velocity.Y)
						{
							projectile.netUpdate = true;
						}
						projectile.velocity = vector3;
						int num6 = mod.ProjectileType("HellStormArrow");
						float scaleFactor2 = 14f;
						int num7 = 7;
						value2 = projectile.Center + new Vector2(Main.rand.Next(-num7, num7 + 1), Main.rand.Next(-num7, num7 + 1));
						Vector2 spinningpoint = Vector2.Normalize(projectile.velocity) * scaleFactor2;
						spinningpoint = spinningpoint.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
						if (float.IsNaN(spinningpoint.X) || float.IsNaN(spinningpoint.Y))
						{
							spinningpoint = -Vector2.UnitY;
						}
						Projectile.NewProjectile(value2.X, value2.Y, spinningpoint.X, spinningpoint.Y, num6, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					}
					else
					{
						projectile.Kill();
					}
				}
			}
			projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
			projectile.rotation = projectile.velocity.ToRotation() + num;
			projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * projectile.direction, projectile.velocity.X * projectile.direction);
		}
	}
}
