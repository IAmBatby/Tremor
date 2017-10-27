using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class GloomSphere : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 91;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 6;
			projectile.timeLeft = 600;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gloom Sphere");

		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			if (Main.rand.NextBool(2))
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 27, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}
