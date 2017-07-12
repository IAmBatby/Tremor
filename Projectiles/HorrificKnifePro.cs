using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class HorrificKnifePro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 14;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horrific Dagger");

		}


		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(1) == 0)
			{
				target.AddBuff(mod.BuffType("DeathFear"), 480, false);
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType<Dusts.NightmareFlame>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 2f, 100, default(Color), 2f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(3) == 0)
			{
				target.AddBuff(mod.BuffType("DeathFear"), 480, false);
			}
		}
	}
}
