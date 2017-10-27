using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class VultureFeatherPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 6;
			projectile.height = 6;
			projectile.friendly = false;
			projectile.aiStyle = 1;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vulture Feather");

		}

	}
}
