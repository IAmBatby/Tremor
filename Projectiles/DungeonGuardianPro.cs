using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class DungeonGuardianPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(555);

			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 420;
			projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DungeonGuardianPro");

		}

	}
}
