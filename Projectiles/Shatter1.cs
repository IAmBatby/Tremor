using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class Shatter1 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Grenade);
			projectile.penetrate = 1;
			projectile.width = 8;
			projectile.height = 8;
			projectile.alpha = 80;
			aiType = ProjectileID.Grenade;
			projectile.light = 0.5f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int newLife = 1;
			Main.player[projectile.owner].statLife += newLife;
			Main.player[projectile.owner].HealEffect(newLife);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
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
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
			}
			return false;
		}
	}
}