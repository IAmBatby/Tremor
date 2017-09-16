using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TrueDeathSickleProj : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 120;
			projectile.height = 112;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.hide = true;
			projectile.ownerHitCheck = false;
			projectile.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Death Sickle");

		}

		public override void AI()
		{
			projectile.soundDelay--;
			if (projectile.soundDelay <= 0)
			{
				Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 71);
				projectile.soundDelay = 45;
			}
			Player player = Main.player[projectile.owner];
			if (Main.myPlayer == projectile.owner)
			{
				if (!player.channel || player.noItems || player.CCed)
				{
					projectile.Kill();
				}
				else
				{
					projectile.ai[0] -= 1f;
					if (projectile.ai[0] <= 0f)
					{
						Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
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
						int num6 = 274;
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
						projectile.ai[0] = 50f;
					}
				}
			}
			projectile.Center = player.MountedCenter;
			projectile.position.X += player.width / 2 * player.direction;
			projectile.spriteDirection = player.direction;
			projectile.timeLeft = 2;
			projectile.rotation += 0.19f * player.direction;
			if (projectile.rotation > MathHelper.TwoPi)
			{
				projectile.rotation -= MathHelper.TwoPi;
			}
			else if (projectile.rotation < 0)
			{
				projectile.rotation += MathHelper.TwoPi;
			}
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = projectile.rotation;
		}
	}
}
