using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ObsidianSaberPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(595);

			projectile.width = 96;
			projectile.height = 48;
			aiType = 595;
			Main.projFrames[projectile.type] = 28;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ObsidianSaberPro");

		}

	}
}
