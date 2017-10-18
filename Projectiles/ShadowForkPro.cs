using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ShadowForkPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(66);

			aiType = 66;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ShadowForkPro");

		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 37, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}
