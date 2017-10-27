using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ScarredReaperPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(106);

			aiType = 106;
			projectile.width = 48;
			projectile.height = 48;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ScarredReaperPro");

		}

	}
}
