using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class MagicGrenade : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(30);

			projectile.width = 14;
			projectile.height = 20;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Grenade");

		}

	}
}
