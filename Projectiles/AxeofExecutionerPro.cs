using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class AxeofExecutionerPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(182);

			projectile.width = 29;
			projectile.height = 29;
			aiType = 182;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AxeofExecutioner");

		}

	}
}
