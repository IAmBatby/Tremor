using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class DarkBubblePro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.timeLeft = 150;
			projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Bubble");

		}

		public override void AI()
		{
			if (projectile.frameCounter < 5)
				projectile.frame = 0;
			else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
				projectile.frame = 1;
			else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
				projectile.frame = 2;
			else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
				projectile.frame = 3;
			else
				projectile.frameCounter = 0;
			projectile.frameCounter++;
		}

		public override void Kill(int timeLeft)
		{
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 54, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.3f);
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
				int num160 = Main.rand.Next(0, 0);
				for (int num161 = 0; num161 < num160; num161++)
				{
					Vector2 value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					while (value12.X == 0f && value12.Y == 0f)
					{
						value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					}
					value12.Normalize();
					value12 *= Main.rand.Next(70, 101) * 0.1f;
					Projectile.NewProjectile(projectile.oldPosition.X + projectile.width / 2, projectile.oldPosition.Y + projectile.height / 2, value12.X, value12.Y, 400, (int)(projectile.damage * 0.8), projectile.knockBack * 2.8f, projectile.owner, 0f, 0f);
				}
			}
		}
	}
}
