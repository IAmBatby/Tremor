using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Projectiles
{
	public class NovaSkull : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 52;
			projectile.height = 52;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.timeLeft = 420;
			Main.projFrames[projectile.type] = 15;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (Main.rand.Next(1, 101) <= Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).alchemistCrit)
			{
				crit = true;
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			int num613 = 10;
			int num614 = 15;
			float num615 = 1f;
			int num616 = 150;
			int num617 = 42;
			if (projectile.velocity.X != 0f)
			{
				projectile.direction = (projectile.spriteDirection = -Math.Sign(projectile.velocity.X));
			}
			projectile.frameCounter++;
			if (projectile.frameCounter > 2)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 10)
			{ projectile.velocity.X = 0f; projectile.velocity.Y = 0f; }
			if (projectile.frame >= 15)
			{ projectile.Kill(); }
			if (!Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
			{
				projectile.alpha -= 30;
				if (projectile.alpha < 60)
				{
					projectile.alpha = 60;
				}
			}
			else
			{
				projectile.alpha += 30;
				if (projectile.alpha > 150)
				{
					projectile.alpha = 150;
				}
			}
		}
	}
}