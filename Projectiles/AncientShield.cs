using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class AncientShield : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 28;
			projectile.height = 36;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 2;
			projectile.tileCollide = false;
			projectile.timeLeft = 660;
			projectile.light = 0;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AncientShield");

		}

		public override bool PreAI()
		{
			float Num = 4f;
			float Num2 = 1.1f;
			int Num3 = 1;
			if (projectile.position.X + projectile.width / 2 < Main.player[projectile.owner].position.X + Main.player[projectile.owner].width)
			{
				Num3 = -1;
			}
			Vector2 Vector1 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
			float Num4 = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 + Num3 * 180 - Vector1.X;
			float Num5 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - Vector1.Y;
			float Num6 = (float)Math.Sqrt(Num4 * Num4 + Num5 * Num5);
			float Num7 = projectile.position.X + projectile.width / 2 - Main.player[projectile.owner].position.X - Main.player[projectile.owner].width / 2;
			float Num8 = projectile.position.Y + projectile.height - 59f - Main.player[projectile.owner].position.Y - Main.player[projectile.owner].height / 2;
			float Num9 = (float)Math.Atan2(Num8, Num7) + 1.57f;
			if (Num9 < 0f)
			{
				Num9 += 6.283f;
			}
			else if (Num9 > 6.283)
			{
				Num9 -= 6.283f;
			}
			float Num10 = 0.15f;
			if (projectile.rotation < Num9)
			{
				if (Num9 - projectile.rotation > 3.1415)
				{
					projectile.rotation -= Num10;
				}
				else
				{
					projectile.rotation += Num10;
				}
			}
			else if (projectile.rotation > Num9)
			{
				if (projectile.rotation - Num9 > 3.1415)
				{
					projectile.rotation += Num10;
				}
				else
				{
					projectile.rotation -= Num10;
				}
			}
			if (projectile.rotation > Num9 - Num10 && projectile.rotation < Num9 + Num10)
			{
				projectile.rotation = Num9;
			}
			if (projectile.rotation < 0f)
			{
				projectile.rotation += 6.283f;
			}
			else if (projectile.rotation > 6.283)
			{
				projectile.rotation -= 6.283f;
			}
			if (projectile.rotation > Num9 - Num10 && projectile.rotation < Num9 + Num10)
			{
				projectile.rotation = Num9;
			}
			projectile.frameCounter++;
			if (projectile.frameCounter >= 16)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame >= 3)
				{
					projectile.frame = 0;
				}
			}
			Vector2 direction = Main.player[projectile.owner].Center - projectile.Center;
			direction.Normalize();
			direction *= 9f;
			Player player = Main.player[projectile.owner];
			double deg = (double)projectile.ai[1] / 2;
			double rad = deg * (Math.PI / 180);
			double dist = 100;
			projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
			projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;
			projectile.ai[1] += 2f;
			return false;
		}
	}
}
