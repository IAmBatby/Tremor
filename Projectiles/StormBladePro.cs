using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class StormBladePro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 26;
			projectile.height = 26;
			projectile.aiStyle = 27;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 600;
			projectile.light = 0.7f;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Blade Pro");

		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.velocity.X * 0.5f, projectile.velocity.Y * 2.5f);
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 40; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

	}
}
