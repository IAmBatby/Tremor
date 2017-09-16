using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class RavenFeather : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 4;
			projectile.height = 4;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.aiStyle = 1;
			projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raven Feather");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 1, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
			}
			Main.PlaySound(6, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

	}
}
