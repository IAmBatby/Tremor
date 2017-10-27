using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ManiacChainsawPro : ModProjectile
	{
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(509);

			//aiType = 509;
			projectile.melee = true;
			projectile.friendly = true;
			projectile.penetrate = -1;
			Main.projFrames[projectile.type] = 2;
			projectile.width = 34;
			projectile.height = 140;

			projectile.tileCollide = false;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ManiacChainsawPro");

		}

		public override void AI()
		{
			Vector2 vector22;
			float num263;
			Vector2 vector23;
			float num264;
			float num265;
			float num266;
			int num267;
			vector22 = Main.player[projectile.owner].RotatedRelativePoint(Main.player[projectile.owner].MountedCenter, true);
			if (Main.myPlayer == projectile.owner)
			{
				if (Main.player[projectile.owner].channel)
				{
					num263 = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].shootSpeed * projectile.scale;
					vector23 = vector22;
					num264 = Main.mouseX + Main.screenPosition.X - vector23.X - 20;
					num265 = Main.mouseY + Main.screenPosition.Y - vector23.Y;
					if (Main.player[projectile.owner].gravDir == -1f)
					{
						num265 = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - vector23.Y;
					}
					num266 = (float)Math.Sqrt(num264 * num264 + num265 * num265);
					num266 = (float)Math.Sqrt(num264 * num264 + num265 * num265);
					num266 = num263 / num266;
					num264 *= num266;
					num265 *= num266;
					if (num264 != projectile.velocity.X || num265 != projectile.velocity.Y)
					{
						projectile.netUpdate = true;
					}
					projectile.velocity.X = num264;
					projectile.velocity.Y = num265;
				}
				else
				{
					projectile.Kill();
				}
			}
			if (projectile.velocity.X > 0f)
			{
				Main.player[projectile.owner].ChangeDir(1);
			}
			else if (projectile.velocity.X < 0f)
			{
				Main.player[projectile.owner].ChangeDir(-1);
			}
			projectile.spriteDirection = projectile.direction;
			Main.player[projectile.owner].ChangeDir(projectile.direction);
			Main.player[projectile.owner].heldProj = projectile.whoAmI;
			Main.player[projectile.owner].itemTime = 2;
			Main.player[projectile.owner].itemAnimation = 2;
			projectile.position.X = vector22.X - projectile.width / 2;
			projectile.position.Y = vector22.Y - projectile.height / 2;
			projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.5700000524520874);
			if (Main.player[projectile.owner].direction == 1)
			{
				Main.player[projectile.owner].itemRotation = (float)Math.Atan2(projectile.velocity.Y * projectile.direction, projectile.velocity.X * projectile.direction);
			}
			else
			{
				Main.player[projectile.owner].itemRotation = (float)Math.Atan2(projectile.velocity.Y * projectile.direction, projectile.velocity.X * projectile.direction);
			}

			projectile.frameCounter += 1;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= 2)
				{
					projectile.frame = 0;
				}
			}

			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 22);
		}
	}
}
