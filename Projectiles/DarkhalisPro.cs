using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class DarkhalisPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(595);

			aiType = 595;
			Main.projFrames[projectile.type] = 28;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DarkhalisPro");

		}

	}
}
