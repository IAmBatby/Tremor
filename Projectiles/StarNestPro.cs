using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class StarNestPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(566);

			aiType = 566;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("StarNest");

		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			if (Main.rand.NextBool())
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 57, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}
		}
	}
}
