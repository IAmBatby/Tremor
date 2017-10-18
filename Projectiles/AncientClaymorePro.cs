using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class AncientClaymorePro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 26;
			projectile.height = 26;
			projectile.aiStyle = 27;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Claymore Pro");

		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(69, 180, false);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(69, 180, false);
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 40; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

	}
}
