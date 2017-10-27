using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic.Blasts
{
	public class CrystalBlast : AlchemistProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 10;
		}

		public override void SetDefaults()
		{
			projectile.timeLeft = 420;
			projectile.width = 60;
			projectile.height = 60;
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
			if (projectile.frame >= 10)
			{ projectile.Kill(); }
		}
	}
}