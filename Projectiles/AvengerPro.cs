using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class AvengerPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(542);

			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 220;
			projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avenger Pro");

		}

	}
}
