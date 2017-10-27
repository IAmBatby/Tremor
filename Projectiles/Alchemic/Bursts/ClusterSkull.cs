using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic.Bursts
{
	public class ClusterSkull : AlchemistProjectile
	{
		public override void SetDefaults()
		{
			projectile.timeLeft = 420;
			projectile.width = 52;
			projectile.height = 52;
			projectile.friendly = true;
			Main.projFrames[projectile.type] = 15;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 2)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 10)
			{ projectile.velocity.X = 0f; projectile.velocity.Y = 0f; }
			if (projectile.frame >= 15)
			{ projectile.Kill(); }
		}

	}
}