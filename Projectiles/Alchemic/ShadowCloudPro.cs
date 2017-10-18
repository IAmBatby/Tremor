using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class ShadowCloudPro : AlchemistProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			projectile.magic = true;
			projectile.penetrate = 8;
			projectile.aiStyle = 92;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.light = 1.0f;
		}

		public override bool PreAI()
		{
			if (projectile.timeLeft == 600)
				projectile.alpha = 255;

			return true;
		}

		public override void AI()
		{
			projectile.rotation = 0f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(5))
			{
				target.AddBuff(153, 180, false);
			}
		}

	}
}