using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Projectiles
{
	public class NovaFlask_ProjFire : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 24;
			Main.projFrames[projectile.type] = 3;
			projectile.timeLeft = 600;
			projectile.maxPenetrate = -1;
			projectile.hostile = false;
			projectile.friendly = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (Main.rand.Next(1, 101) <= Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).alchemistCrit)
			{
				crit = true;
			}
		}

		public override bool PreAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 3)
			{
				projectile.frame = 0;
			}
			float num2 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
			float num3 = projectile.localAI[0];
			if (num3 == 0f)
			{
				projectile.localAI[0] = num2;
				num3 = num2;
			}
			float num4 = projectile.position.X;
			float num5 = projectile.position.Y;
			float num6 = 300f;
			bool flag = false;
			int num7 = 0;
			if (projectile.ai[1] == 0f)
			{
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == j + 1))
					{
						float num8 = Main.npc[j].position.X + Main.npc[j].width / 2;
						float num9 = Main.npc[j].position.Y + Main.npc[j].height / 2;
						float num10 = Math.Abs(projectile.position.X + projectile.width / 2 - num8) + Math.Abs(projectile.position.Y + projectile.height / 2 - num9);
						if (num10 < num6 && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[j].position, Main.npc[j].width, Main.npc[j].height))
						{
							num6 = num10;
							num4 = num8;
							num5 = num9;
							flag = true;
							num7 = j;
						}
					}
				}
				if (flag)
				{
					projectile.ai[1] = num7 + 1;
				}
				flag = false;
			}
			if (projectile.ai[1] > 0f)
			{
				int num11 = (int)(projectile.ai[1] - 1f);
				if (Main.npc[num11].active && Main.npc[num11].CanBeChasedBy(this, true) && !Main.npc[num11].dontTakeDamage)
				{
					float num12 = Main.npc[num11].position.X + Main.npc[num11].width / 2;
					float num13 = Main.npc[num11].position.Y + Main.npc[num11].height / 2;
					float num14 = Math.Abs(projectile.position.X + projectile.width / 2 - num12) + Math.Abs(projectile.position.Y + projectile.height / 2 - num13);
					if (num14 < 1000f)
					{
						flag = true;
						num4 = Main.npc[num11].position.X + Main.npc[num11].width / 2;
						num5 = Main.npc[num11].position.Y + Main.npc[num11].height / 2;
					}
				}
				else
				{
					projectile.ai[1] = 0f;
				}
			}
			if (!projectile.friendly)
			{
				flag = false;
			}
			if (flag)
			{
				float num15 = num3;
				Vector2 vector = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
				float num16 = num4 - vector.X;
				float num17 = num5 - vector.Y;
				float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
				num18 = num15 / num18;
				num16 *= num18;
				num17 *= num18;
				int num19 = 8;
				projectile.velocity.X = (projectile.velocity.X * (num19 - 1) + num16) / num19;
				projectile.velocity.Y = (projectile.velocity.Y * (num19 - 1) + num17) / num19;
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			Helper.Explode(projectile.whoAmI, 120, 120, delegate
			{
				for (int i = 0; i < 40; i++)
				{
					int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, 0f, -2f, 0, default(Color), 2f);
					Main.dust[num].noGravity = true;
					Dust expr_62_cp_0 = Main.dust[num];
					expr_62_cp_0.position.X = expr_62_cp_0.position.X + (Main.rand.Next(-50, 51) / 20 - 1.5f);
					Dust expr_92_cp_0 = Main.dust[num];
					expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + (Main.rand.Next(-50, 51) / 20 - 1.5f);
					if (Main.dust[num].position != projectile.Center)
					{
						Main.dust[num].velocity = projectile.DirectionTo(Main.dust[num].position) * 6f;
					}
				}
			});
		}
	}
}
