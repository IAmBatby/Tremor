using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class BestNightmarePro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(106);

			aiType = 106;
			projectile.width = 54;
			projectile.height = 54;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BestNightmarePro");

		}



		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			if (Main.rand.Next(1) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 62, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}
			Vector2 vector63 = Main.player[projectile.owner].Center - projectile.Center;
			if (Main.player[projectile.owner].dead)
			{
				projectile.Kill();
				return;
			}
			if (projectile.ai[0] == 0f && vector63.Length() > 400f)
			{
				projectile.ai[0] = 1f;
			}
			if (projectile.ai[0] == 1f || projectile.ai[0] == 2f)
			{
				float num810 = vector63.Length();
				if (num810 > 1500f)
				{
					projectile.Kill();
					return;
				}
				if (num810 > 600f)
				{
					projectile.ai[0] = 2f;
				}
				float num811 = 20f;
				if (projectile.ai[0] == 2f)
				{
					num811 = 40f;
				}
				if (vector63.Length() < num811)
				{
					projectile.Kill();
					return;
				}
			}
			projectile.ai[1] += 1f;
			if (projectile.ai[1] > 5f)
			{
				projectile.alpha = 0;
			}
			if ((int)projectile.ai[1] % 3 == 0 && projectile.owner == Main.myPlayer)
			{
				Vector2 vector64 = vector63 * -1f;
				vector64.Normalize();
				vector64 *= Main.rand.Next(5, 25) * 0.9f;

				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector64.X, vector64.Y, mod.ProjectileType("ChaosStarPro"), projectile.damage / 3, projectile.knockBack, projectile.owner, -10f, 0f);
			}
		}
	}
}
