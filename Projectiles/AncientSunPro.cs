using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class AncientSunPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 26;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 600;
			projectile.magic = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Sun Pro");

		}


		public override void AI()
		{
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.25f) / 255f, ((255 - projectile.alpha) * 0.2f) / 255f, ((255 - projectile.alpha) * 0.01f) / 255f);
			if (projectile.wet && !projectile.lavaWet)
			{
				projectile.Kill();
			}
			if (projectile.localAI[0] == 0f)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
				projectile.localAI[0] += 1f;
			}
			for (int num457 = 0; num457 < 10; num457++)
			{
				int num458 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num458].noGravity = true;
				Main.dust[num458].velocity *= 0.5f;
				Main.dust[num458].velocity += projectile.velocity * 0.1f;
			}
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
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("AncientSunExplosionPro"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 750);
		}
	}
}
