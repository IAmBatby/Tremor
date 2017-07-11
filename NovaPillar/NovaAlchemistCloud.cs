using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.NovaPillar
{
	public class NovaAlchemistCloud : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Cloud");
		}

		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 38;
			projectile.penetrate = 8;
			projectile.aiStyle = -1;
			projectile.timeLeft = 600;
			projectile.hostile = true;
			projectile.damage = 100;
		}

		public override void AI()
		{
			projectile.tileCollide = false;
			projectile.ai[1] += 1f;
			if (projectile.ai[1] > 60f)
			{
				projectile.ai[0] += 10f;
			}
			if (projectile.ai[0] > 255f)
			{
				projectile.Kill();
				projectile.ai[0] = 255f;
			}
			projectile.alpha = (int)(100.0 + (double)projectile.ai[0] * 0.7);
			projectile.rotation += projectile.velocity.X * 0.1f;
			projectile.rotation += (float)projectile.direction * 0.003f;
			projectile.velocity *= 0.96f;
		}
	}
}