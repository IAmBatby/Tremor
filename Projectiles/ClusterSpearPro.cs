using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ClusterSpearPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(218);

			aiType = 218;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ClusterSpearPro");

		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.ClusterFlame>(), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 2.9f);
			Main.dust[dust].noGravity = true;
		}

	}
}
