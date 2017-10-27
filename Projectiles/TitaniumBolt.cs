using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TitaniumBolt : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 18;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 6;
			projectile.aiStyle = 1;
			projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TitaniumBolt");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 0, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

	}
}
