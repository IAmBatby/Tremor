using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ThrowingCog : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.aiStyle = 2;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwing Cog");

		}


		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.GoldCoin, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}
