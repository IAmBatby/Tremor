using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Projectiles
{
	public class NovaAlchemistProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Portal");
		}
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.hostile = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255 - projectile.alpha, 255 - projectile.alpha, 255 - projectile.alpha, 255 - projectile.alpha);
		}

		public override void AI()
		{
			if (projectile.localAI[0] == 0f)
			{
				projectile.localAI[0] = 1f;
				int num960 = Player.FindClosest(projectile.Center, 0, 0);
				Vector2 vector103 = Main.player[num960].Center - projectile.Center;
				if (vector103 == Vector2.Zero)
				{
					vector103 = Vector2.UnitY;
				}
				projectile.ai[1] = vector103.ToRotation();
				projectile.netUpdate = true;
			}
			projectile.ai[0] += 1f;
			if (projectile.ai[0] <= 50f)
			{
				if (Main.rand.Next(2) == 0)
				{
					Vector2 vector106 = projectile.ai[1].ToRotationVector2();
					Vector2 vector107 = vector106.RotatedBy(1.5707963705062866, default(Vector2)) * (Main.rand.Next(2) == 0).ToDirectionInt() * Main.rand.Next(10, 21);
					Vector2 value60 = vector106 * Main.rand.Next(-80, 81);
					Vector2 vector108 = value60 - vector107;
					vector108 /= 10f;
					int num961 = 57;
					Dust dust14 = Main.dust[Dust.NewDust(projectile.Center, 0, 0, num961, 0f, 0f, 0, default(Color), 1f)];
					dust14.noGravity = true;
					dust14.position = projectile.Center + vector107;
					dust14.velocity = vector108;
					dust14.scale = 0.5f + Main.rand.NextFloat();
					dust14.fadeIn = 0.5f;
					value60 = vector106 * Main.rand.Next(40, 121);
					vector108 = value60 - vector107 / 2f;
					vector108 /= 10f;
					dust14 = Main.dust[Dust.NewDust(projectile.Center, 0, 0, num961, 0f, 0f, 0, default(Color), 1f)];
					dust14.noGravity = true;
					dust14.position = projectile.Center + vector107 / 2f;
					dust14.velocity = vector108;
					dust14.scale = 1f + Main.rand.NextFloat();
				}
			}
			else if (projectile.ai[0] <= 90f)
			{
				projectile.scale = (projectile.ai[0] - 50f) / 40f;
				projectile.alpha = 255 - (int)(255f * projectile.scale);
				Vector2 vector111 = projectile.ai[1].ToRotationVector2();
				Vector2 value61 = vector111.RotatedBy(1.5707963705062866, default(Vector2)) * (Main.rand.Next(2) == 0).ToDirectionInt() * Main.rand.Next(10, 21);
				vector111 *= (float)Main.rand.Next(-80, 81);
				Vector2 vector112 = vector111 - value61;
				vector112 /= 10f;
				int num962 = Utils.SelectRandom(Main.rand, 57, 57);
				Dust dust17 = Main.dust[Dust.NewDust(projectile.Center, 0, 0, num962, 0f, 0f, 0, default(Color), 1f)];
				dust17.noGravity = true;
				dust17.position = projectile.Center + value61;
				dust17.velocity = vector112;
				dust17.scale = 0.5f + Main.rand.NextFloat();
				dust17.fadeIn = 0.5f;
				if (projectile.ai[0] == 90f && Main.netMode != 1)
				{
					Vector2 vector113 = projectile.ai[1].ToRotationVector2() * 8f;
					float ai2 = Main.rand.Next(80);
					Projectile.NewProjectile(projectile.Center.X - vector113.X, projectile.Center.Y - vector113.Y, vector113.X, vector113.Y, mod.ProjectileType("NovaAlchemistFlask"), 15, 1f, Main.myPlayer, projectile.ai[1], ai2);
				}
			}
			else
			{
				if (projectile.ai[0] > 120f)
				{
					projectile.scale = 1f - (projectile.ai[0] - 120f) / 60f;
					projectile.alpha = 255 - (int)(255f * projectile.scale);
					if (projectile.alpha >= 255)
					{
						projectile.Kill();
					}
					for (int num965 = 0; num965 < 2; num965++)
					{
						int num966 = Main.rand.Next(3);
						if (num966 == 0)
						{
							Vector2 vector114 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * projectile.scale;
							Dust dust18 = Main.dust[Dust.NewDust(projectile.Center - vector114 * 30f, 0, 0, 57, 0f, 0f, 0, default(Color), 1f)];
							dust18.noGravity = true;
							dust18.position = projectile.Center - vector114 * Main.rand.Next(10, 21);
							dust18.velocity = vector114.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
							dust18.scale = 0.5f + Main.rand.NextFloat();
							dust18.fadeIn = 0.5f;
							dust18.customData = projectile.Center;
						}
						else if (num966 == 1)
						{
							Vector2 vector115 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * projectile.scale;
							Dust dust19 = Main.dust[Dust.NewDust(projectile.Center - vector115 * 30f, 0, 0, 57, 0f, 0f, 0, default(Color), 1f)];
							dust19.noGravity = true;
							dust19.position = projectile.Center - vector115 * 30f;
							dust19.velocity = vector115.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
							dust19.scale = 0.5f + Main.rand.NextFloat();
							dust19.fadeIn = 0.5f;
							dust19.customData = projectile.Center;
						}
					}
					return;
				}
				projectile.scale = 1f;
				projectile.alpha = 0;
				if (Main.rand.Next(2) == 0)
				{
					Vector2 vector116 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
					Dust dust20 = Main.dust[Dust.NewDust(projectile.Center - vector116 * 30f, 0, 0, 57, 0f, 0f, 0, default(Color), 1f)];
					dust20.noGravity = true;
					dust20.position = projectile.Center - vector116 * Main.rand.Next(10, 21);
					dust20.velocity = vector116.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
					dust20.scale = 0.5f + Main.rand.NextFloat();
					dust20.fadeIn = 0.5f;
					dust20.customData = projectile.Center;
					return;
				}
				Vector2 vector117 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
				Dust dust21 = Main.dust[Dust.NewDust(projectile.Center - vector117 * 30f, 0, 0, 57, 0f, 0f, 0, default(Color), 1f)];
				dust21.noGravity = true;
				dust21.position = projectile.Center - vector117 * 30f;
				dust21.velocity = vector117.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
				dust21.scale = 0.5f + Main.rand.NextFloat();
				dust21.fadeIn = 0.5f;
				dust21.customData = projectile.Center;
			}
		}
	}
}
