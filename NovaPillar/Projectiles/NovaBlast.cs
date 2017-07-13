using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Projectiles
{
	public class NovaBlast : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.timeLeft = 420;
			projectile.width = 60;
			projectile.height = 60;
			projectile.friendly = true;
			Main.projFrames[projectile.type] = 10;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (Main.rand.Next(1, 101) <= Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).alchemistCrit)
			{
				crit = true;
			}
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