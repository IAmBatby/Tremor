using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class SpiK3Ball : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 14;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 1500;
			projectile.extraUpdates = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SpiK-3 Ball");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 40; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 26, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}
	}
}
