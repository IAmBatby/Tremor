using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TungstenSpearPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(66);

			aiType = 66;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TungstenSpearPro");

		}

	}
}
