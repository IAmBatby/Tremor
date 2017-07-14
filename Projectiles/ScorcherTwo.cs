using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ScorcherTwo : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.scale = 1.6f;
			projectile.timeLeft = 120;
			projectile.penetrate = 3;
			aiType = 638;
			projectile.aiStyle = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ScorcherTwo");

		}


		public override void Kill(int timeLeft)
		{
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.3f);
				if (Main.rand.Next(3) == 0)
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
				int num160 = Main.rand.Next(1, 1);
				for (int num161 = 0; num161 < num160; num161++)
				{
					Vector2 value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					while (value12.X == 0f && value12.Y == 0f)
					{
						value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					}
					value12.Normalize();
					value12 *= Main.rand.Next(70, 101) * 0.1f;
					Projectile.NewProjectile(projectile.oldPosition.X + projectile.width / 2, projectile.oldPosition.Y + projectile.height / 2, value12.X, value12.Y, 612, (int)(projectile.damage * 0.8), projectile.knockBack * 2.8f, projectile.owner, 0f, 0f);
				}
			}
		}

		public override void AI()
		{
			int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.4f);
			projectile.light = 0.9f;
			projectile.alpha -= 50;
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.owner == Main.myPlayer)
			{
				if (projectile.timeLeft % 6 == 0)
				{
					projectile.localAI[0] += 1f;
					if (projectile.localAI[0] >= 4f)
					{
						projectile.localAI[0] = 0f;
						int num668 = 0;
						for (int num669 = 0; num669 < 1000; num669++)
						{
							if (Main.projectile[num669].active && Main.projectile[num669].owner == projectile.owner && Main.projectile[num669].type == 344)
							{
								num668++;
							}
						}
						float num670 = projectile.damage * 0.8f;
						if (num668 > 100)
						{
							float num671 = num668 - 100;
							num671 = 1f - num671 / 100f;
							num670 *= num671;
						}
						if (num668 > 100)
						{
							projectile.localAI[0] -= 1f;
						}
						if (num668 > 120)
						{
							projectile.localAI[0] -= 1f;
						}
						if (num668 > 140)
						{
							projectile.localAI[0] -= 1f;
						}
						if (num668 > 150)
						{
							projectile.localAI[0] -= 1f;
						}
						if (num668 > 160)
						{
							projectile.localAI[0] -= 1f;
						}
						if (num668 > 165)
						{
							projectile.localAI[0] -= 1f;
						}
						if (num668 > 170)
						{
							projectile.localAI[0] -= 2f;
						}
						if (num668 > 175)
						{
							projectile.localAI[0] -= 3f;
						}
						if (num668 > 180)
						{
							projectile.localAI[0] -= 4f;
						}
						if (num668 > 185)
						{
							projectile.localAI[0] -= 5f;
						}
						if (num668 > 190)
						{
							projectile.localAI[0] -= 6f;
						}
						if (num668 > 195)
						{
							projectile.localAI[0] -= 7f;
						}
						if (num670 > projectile.damage * 0.1f)
						{
							Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("ScorcherStar"), projectile.damage, projectile.knockBack * 0.55f, projectile.owner, 0f, Main.rand.Next(2));
						}
					}
				}
			}
		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}

	}
}
