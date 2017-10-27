using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TheSpikePro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(541);

			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 480;
			projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Spike");

		}

	}
}
