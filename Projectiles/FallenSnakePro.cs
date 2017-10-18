using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class FallenSnakePro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ValkyrieYoyo);
			projectile.width = 22;
			projectile.height = 22;
			projectile.timeLeft = 220;
			projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("");

		}

		public override bool PreAI()
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 13, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}

			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(72, 280, false);
			}
		}

	}
}
