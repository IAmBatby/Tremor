using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Tremor.NovaPillar
{
	public class NovaCauldron : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 18000;
			projectile.penetrate = -1;
			projectile.timeLeft *= 5;
			projectile.tileCollide = false;
			projectile.minion = true;
			Main.projFrames[projectile.type] = 4;
			projectile.width = 32;
			projectile.height = 30;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 4)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 4)
			{
				projectile.frame = 0;
			}
			bool Flag1 = projectile.type == mod.ProjectileType("NovaCauldron");
			Player player = Main.player[projectile.owner];
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
			if (Flag1)
			{
				if (player.dead)
				{
					modPlayer.novaSet = false;
				}
				if (modPlayer.novaSet)
				{
					projectile.timeLeft = 2;
				}
			}
			if (!modPlayer.novaSet)
			{
				projectile.Kill();
			}
			projectile.rotation = 0f;
			Vector2 value = base.projectile.position;
			float num2 = 500f;
			bool flag = false;
			base.projectile.tileCollide = true;
			for (int j = 0; j < 200; j++)
			{
				NPC nPC = Main.npc[j];
				if (nPC.CanBeChasedBy(this, false))
				{
					float num3 = Vector2.Distance(nPC.Center, base.projectile.Center);
					if ((num3 < num2 || !flag) && Collision.CanHitLine(base.projectile.position, base.projectile.width, base.projectile.height, nPC.position, nPC.width, nPC.height))
					{
						num2 = num3;
						value = nPC.Center;
						flag = true;
					}
				}
			}
			if (Vector2.Distance(player.Center, base.projectile.Center) > (flag ? 1000f : 500f))
			{
				base.projectile.ai[0] = 1f;
				base.projectile.netUpdate = true;
			}
			if (base.projectile.ai[0] == 1f)
			{
				base.projectile.tileCollide = false;
			}
			if (flag && base.projectile.ai[0] == 0f)
			{
				Vector2 value2 = value - base.projectile.Center;
				if (value2.Length() > 200f)
				{
					value2.Normalize();
					base.projectile.velocity = (base.projectile.velocity * 20f + value2 * 6f) / 21f;
				}
				else
				{
					base.projectile.velocity *= (float)Math.Pow(0.97, 2.0);
				}
			}
			else
			{
				if (!Collision.CanHitLine(base.projectile.Center, 1, 1, player.Center, 1, 1))
				{
					base.projectile.ai[0] = 1f;
				}
				float num4 = 6f;
				if (base.projectile.ai[0] == 1f)
				{
					num4 = 15f;
				}
				Vector2 center = base.projectile.Center;
				Vector2 vector = player.Center - center;
				base.projectile.ai[1] = 3600f;
				base.projectile.netUpdate = true;
				int num5 = 1;
				for (int k = 0; k < base.projectile.whoAmI; k++)
				{
					if (Main.projectile[k].active && Main.projectile[k].owner == base.projectile.owner && Main.projectile[k].type == base.projectile.type)
					{
						num5++;
					}
				}
				vector.X -= (float)((10 + num5 * 40) * player.direction);
				vector.Y -= 70f;
				float num6 = vector.Length();
				if (num6 > 200f && num4 < 9f)
				{
					num4 = 9f;
				}
				if (num6 < 100f && base.projectile.ai[0] == 1f && !Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
				{
					base.projectile.ai[0] = 0f;
					base.projectile.netUpdate = true;
				}
				if (num6 > 2000f)
				{
					base.projectile.Center = player.Center;
				}
				if (num6 > 48f)
				{
					vector.Normalize();
					vector *= num4;
					float num7 = 10f;
					base.projectile.velocity = (base.projectile.velocity * num7 + vector) / (num7 + 1f);
				}
				else
				{
					base.projectile.direction = Main.player[base.projectile.owner].direction;
					base.projectile.velocity *= (float)Math.Pow(0.9, 2.0);
				}
			}
			base.projectile.rotation = base.projectile.velocity.X * 0.05f;
			if (base.projectile.velocity.X > 0f)
			{
				base.projectile.spriteDirection = (base.projectile.direction = -1);
			}
			else if (base.projectile.velocity.X < 0f)
			{
				base.projectile.spriteDirection = (base.projectile.direction = 1);
			}
			if (base.projectile.ai[1] > 0f)
			{
				base.projectile.ai[1] += 1f;
			}
			if (base.projectile.ai[1] > 140f)
			{
				base.projectile.ai[1] = 0f;
				base.projectile.netUpdate = true;
			}
			if (base.projectile.ai[0] == 0f && flag)
			{
				if ((value - base.projectile.Center).X > 0f)
				{
					base.projectile.spriteDirection = (base.projectile.direction = -1);
				}
				else if ((value - base.projectile.Center).X < 0f)
				{
					base.projectile.spriteDirection = (base.projectile.direction = 1);
				}
			}
			if (projectile.owner == Main.myPlayer)
			{
				if (projectile.ai[0] != 0f)
				{
					projectile.ai[0] -= 1f;
					return;
				}
				float Num3 = projectile.position.X;
				float Num4 = projectile.position.Y;
				float Num5 = 700f;
				bool Flag2 = false;
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].CanBeChasedBy(projectile, true))
					{
						float Num6 = Main.npc[k].position.X + (float)(Main.npc[k].width / 2);
						float Num7 = Main.npc[k].position.Y + (float)(Main.npc[k].height / 2);
						float Num8 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - Num6) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - Num7);
						if (Num8 < Num5 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height))
						{
							Num5 = Num8;
							Num3 = Num6;
							Num4 = Num7;
							Flag2 = true;
						}
					}
				}
				if (Flag2)
				{
					float Num9 = 12f;
					Vector2 Vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					float Num10 = Num3 - Vector.X;
					float Num11 = Num4 - Vector.Y;
					float Num12 = (float)Math.Sqrt((double)(Num10 * Num10 + Num11 * Num11));
					Num12 = Num9 / Num12;
					Num10 *= Num12;
					Num11 *= Num12;
					Projectile.NewProjectile(projectile.Center.X - 4f, projectile.Center.Y, Num10, Num11, mod.ProjectileType("NovaCauldron_Fire"), 65, projectile.knockBack, projectile.owner, 0f, 0f);
					projectile.ai[0] = 50f;
					return;
				}
			}
		}
	}
}