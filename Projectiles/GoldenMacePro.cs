using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class GoldenMacePro : ModProjectile
	{

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 246, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
			}
		}
		public override void SetDefaults()
		{

			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.extraUpdates = 2;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GoldenMacePro");

		}

		public override void AI()
		{
			int dustType = 246;
			if (projectile.timeLeft > 133)
			{
				projectile.timeLeft = 133;
			}
			if (projectile.ai[0] > 7f)
			{
				float dustScale = 1f;
				if (projectile.ai[0] == 8f)
				{
					dustScale = 1f;
				}
				else if (projectile.ai[0] == 9f)
				{
					dustScale = 1f;
				}
				else if (projectile.ai[0] == 10f)
				{
					dustScale = 1f;
				}
				else if (projectile.ai[0] == 11f)
				{
					dustScale = 1f;
				}
				projectile.ai[0] += 1f;
				for (int i = 0; i < 1; i++)
				{
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
					Dust dust = Main.dust[dustIndex];
					dust.noGravity = true;
					dust.scale *= 1f;
					dust.velocity.X = dust.velocity.X * 2f;
					dust.velocity.Y = dust.velocity.Y * 2f;
					dust.scale *= dustScale;
				}
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * projectile.direction;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(5))
			{
				target.AddBuff(72, 500, false);
			}
		}
	}
}
