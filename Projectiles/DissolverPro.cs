using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class DissolverPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(553);

			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DissolverPro");

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(69, 280, false);
			}
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			if (Main.rand.NextBool())
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 57, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(69, 280, false);
			}
		}
	}
}
