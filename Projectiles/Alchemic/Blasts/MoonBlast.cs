using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic.Blasts
{
	public class MoonBlast : AlchemistProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			projectile.timeLeft = 420;
			projectile.width = 98;
			projectile.height = 98;
			projectile.friendly = true;
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
			if (projectile.frame >= 7)
			{ projectile.Kill(); }
		}
	}
}