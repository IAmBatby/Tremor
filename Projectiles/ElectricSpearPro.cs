using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ElectricSpearPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(47);

			aiType = 47;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ElectricSpearPro");

		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 0.9f);
			Main.dust[dust].noGravity = true;
		}

	}
}
