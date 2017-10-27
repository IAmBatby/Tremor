using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class MagicShurikenPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(3);

			projectile.width = 22;
			projectile.height = 22;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Shuriken");

		}

	}
}
