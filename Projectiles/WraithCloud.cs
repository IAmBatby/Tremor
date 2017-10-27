using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class WraithCloud : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 40;
			projectile.height = 40;
			projectile.magic = true;
			projectile.penetrate = 8;
			projectile.aiStyle = 92;
			projectile.friendly = true;
			projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("WraithCloud");

		}

	}
}
