using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic.Bursts
{
	public class HealingBurst : AlchemistProjectile
	{
		public override void SetDefaults()
		{
			projectile.timeLeft = 420;
			projectile.width = 52;
			projectile.height = 52;
			projectile.friendly = true;
			Main.projFrames[projectile.type] = 20;
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
			if (projectile.frame >= 20)
			{ projectile.Kill(); }
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.LocalPlayer.HasBuff(mod.BuffType("ConcentratedTinctureBuff")))
			{
				int newLife = 2;
				Main.player[projectile.owner].statLife += newLife;
				Main.player[projectile.owner].HealEffect(newLife);
			}
			else
			{
				int newLife = 1;
				Main.player[projectile.owner].statLife += newLife;
				Main.player[projectile.owner].HealEffect(newLife);
			}
		}

	}
}