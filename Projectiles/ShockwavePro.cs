using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ShockwavePro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(348);

			projectile.timeLeft = 120;
			aiType = 348;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ShockwavePro");

		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			if (Main.rand.NextBool())
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}
		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}

	}
}
