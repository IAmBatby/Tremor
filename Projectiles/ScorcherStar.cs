using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ScorcherStar : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(405);

			aiType = 405;
			projectile.friendly = true;
			projectile.timeLeft = 150;
			projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ScorcherStar");

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

		public override void Kill(int timeLeft)
		{
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.3f);
				if (Main.rand.NextBool(3))
				{
					Main.dust[num159].fadeIn = 1.1f + Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num159].scale = 0.35f + Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num159].type++;
				}
				else
				{
					Main.dust[num159].scale = 1.2f + Main.rand.Next(-10, 11) * 0.01f;
				}
				Main.dust[num159].noGravity = true;
				Main.dust[num159].velocity *= 2.5f;
				Main.dust[num159].velocity -= projectile.oldVelocity / 10f;
			}
			if (Main.myPlayer == projectile.owner)
			{
				int num160 = Main.rand.Next(1, 1);
				for (int num161 = 0; num161 < num160; num161++)
				{
					Vector2 value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					while (value12.X == 0f && value12.Y == 0f)
					{
						value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					}
					value12.Normalize();
					value12 *= Main.rand.Next(70, 101) * 0.1f;
					Projectile.NewProjectile(projectile.oldPosition.X + projectile.width / 2, projectile.oldPosition.Y + projectile.height / 2, value12.X, value12.Y, 612, (int)(projectile.damage * 0.8), projectile.knockBack * 2.8f, projectile.owner, 0f, 0f);
				}
			}
		}
	}
}
