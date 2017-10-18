using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class CyclonePro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(409);

			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyclone");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			projectile.localAI[1] += 1f;
			if (projectile.localAI[1] > 10f && Main.rand.NextBool(3))
			{
				int num816 = 6;
				for (int num817 = 0; num817 < num816; num817++)
				{
					Vector2 vector65 = Vector2.Normalize(projectile.velocity) * new Vector2(projectile.width, projectile.height) / 2f;
					vector65 = vector65.RotatedBy((num817 - (num816 / 2 - 1)) * 3.1415926535897931 / num816, default(Vector2)) + projectile.Center;
					Vector2 value24 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - 1.57079637f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num818 = Dust.NewDust(vector65 + value24, 0, 0, 61, value24.X * 2f, value24.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num818].noGravity = true;
					Main.dust[num818].noLight = true;
					Main.dust[num818].velocity /= 4f;
					Main.dust[num818].velocity -= projectile.velocity;
				}
				projectile.alpha -= 5;
				if (projectile.alpha < 50)
				{
					projectile.alpha = 50;
				}
				projectile.rotation += projectile.velocity.X * 0.1f;
				projectile.frame = (int)(projectile.localAI[1] / 3f) % 3;
				Lighting.AddLight((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16, 0.1f, 0.4f, 0.6f);
			}
			int num819 = -1;
			Vector2 vector66 = projectile.Center;
			float num820 = 500f;
			if (projectile.localAI[0] > 0f)
			{
				projectile.localAI[0] -= 1f;
			}
			if (projectile.ai[0] == 0f && projectile.localAI[0] == 0f)
			{
				for (int num821 = 0; num821 < 200; num821++)
				{
					NPC nPC8 = Main.npc[num821];
					if (nPC8.active && !nPC8.dontTakeDamage && !nPC8.friendly && nPC8.lifeMax > 5 && (projectile.ai[0] == 0f || projectile.ai[0] == num821 + 1))
					{
						Vector2 vector67 = nPC8.Center;
						float num822 = Vector2.Distance(vector67, vector66);
						if (num822 < num820 && Collision.CanHit(projectile.position, projectile.width, projectile.height, nPC8.position, nPC8.width, nPC8.height))
						{
							num820 = num822;
							vector66 = vector67;
							num819 = num821;
						}
					}
				}
				if (num819 >= 0)
				{
					projectile.ai[0] = num819 + 1;
					projectile.netUpdate = true;
				}
			}
			if (projectile.localAI[0] == 0f && projectile.ai[0] == 0f)
			{
				projectile.localAI[0] = 30f;
			}
			bool flag33 = false;
			if (projectile.ai[0] != 0f)
			{
				int num823 = (int)(projectile.ai[0] - 1f);
				if (Main.npc[num823].active && !Main.npc[num823].dontTakeDamage && Main.npc[num823].immune[projectile.owner] == 0)
				{
					float num824 = Main.npc[num823].position.X + Main.npc[num823].width / 2;
					float num825 = Main.npc[num823].position.Y + Main.npc[num823].height / 2;
					float num826 = Math.Abs(projectile.position.X + projectile.width / 2 - num824) + Math.Abs(projectile.position.Y + projectile.height / 2 - num825);
					if (num826 < 1000f)
					{
						flag33 = true;
						vector66 = Main.npc[num823].Center;
					}
				}
				else
				{
					projectile.ai[0] = 0f;
					flag33 = false;
					projectile.netUpdate = true;
				}
			}
			if (flag33)
			{
				Vector2 v = vector66 - projectile.Center;
				float num827 = projectile.velocity.ToRotation();
				float num828 = v.ToRotation();
				double num829 = num828 - num827;
				if (num829 > 3.1415926535897931)
				{
					num829 -= 6.2831853071795862;
				}
				if (num829 < -3.1415926535897931)
				{
					num829 += 6.2831853071795862;
				}
				projectile.velocity = projectile.velocity.RotatedBy(num829 * 0.10000000149011612, default(Vector2));
			}
			float num830 = projectile.velocity.Length();
			projectile.velocity.Normalize();
			projectile.velocity *= num830 + 0.0025f;
		}
	}
}
