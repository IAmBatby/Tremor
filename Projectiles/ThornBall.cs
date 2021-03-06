using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ThornBall : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 18;
			projectile.height = 18;
			projectile.aiStyle = 14;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 9000;
			projectile.extraUpdates = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorn Ball");

		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.velocity.Y = -oldVelocity.Y;
			}
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 30; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 21, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
			}
			Main.PlaySound(6, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}
	}
}
