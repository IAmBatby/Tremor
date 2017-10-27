using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class BrassCog : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(24);

			aiType = 24;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BrassCog");

		}

	}
}
