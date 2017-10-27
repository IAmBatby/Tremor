using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class BurningHammerPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(3);

			projectile.width = 26;
			projectile.height = 36;
			aiType = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BurningHammerPro");

		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 2.9f);
			Main.dust[dust].noGravity = true;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 2f, 100, default(Color), 2f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

	}
}
