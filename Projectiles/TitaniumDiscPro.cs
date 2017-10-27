using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TitaniumDiscPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(106);

			aiType = 106;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TitaniumDiscPro");

		}

	}
}
