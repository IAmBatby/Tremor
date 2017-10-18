using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class SacredCrossPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 3;
			projectile.aiStyle = 1;
			projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sacred");

		}

		public override void AI()
		{
			if (projectile.localAI[0] == 0f)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
			}
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				int num90 = 1;
				if (projectile.localAI[0] > 5f)
				{
					num90 = 2;
				}
				for (int num91 = 0; num91 < num90; num91++)
				{
					int num92 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 57, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
					Main.dust[num92].noGravity = true;
					Dust expr_46AC_cp_0 = Main.dust[num92];
					expr_46AC_cp_0.velocity.X = expr_46AC_cp_0.velocity.X * 0.3f;
					Dust expr_46CA_cp_0 = Main.dust[num92];
					expr_46CA_cp_0.velocity.Y = expr_46CA_cp_0.velocity.Y * 0.3f;
					Main.dust[num92].noLight = true;
				}
				if (projectile.wet && !projectile.lavaWet)
				{
					projectile.Kill();
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 101);
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 3.5f);
				if (Main.rand.NextBool(3))
				{
					Main.dust[num159].fadeIn = 1.1f + Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num159].scale = 0.35f + Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num159].type++;
				}
				else
				{
					Main.dust[num159].scale = 1.2f + Main.rand.Next(-10, 11) * 0.01f;
				}
				Main.dust[num159].noGravity = true;
				Main.dust[num159].velocity *= 2.5f;
				Main.dust[num159].velocity -= projectile.oldVelocity / 10f;
			}
			if (Main.myPlayer == projectile.owner)
			{
				int num160 = Main.rand.Next(0, 0);
				for (int num161 = 0; num161 < num160; num161++)
				{
					Vector2 value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					while (value12.X == 0f && value12.Y == 0f)
					{
						value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					}
					value12.Normalize();
					value12 *= Main.rand.Next(70, 101) * 0.1f;
					Projectile.NewProjectile(projectile.oldPosition.X + projectile.width / 2, projectile.oldPosition.Y + projectile.height / 2, value12.X, value12.Y, 400, (int)(projectile.damage * 0.8), projectile.knockBack * 2.8f, projectile.owner, 0f, 0f);
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int newLife = Main.rand.Next(damage / 5) + 3;
			Main.player[projectile.owner].statLife += newLife;
			Main.player[projectile.owner].HealEffect(newLife);
		}

	}
}
