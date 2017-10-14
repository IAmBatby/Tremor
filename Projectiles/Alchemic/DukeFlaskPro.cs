using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class DukeFlaskPro : AlchemistProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.aiStyle = 2;
			projectile.penetrate = 1;
			// todo: move
			if (Main.LocalPlayer.HasBuff(mod.BuffType("BouncingCasingBuff")))
			{
				projectile.penetrate = 3;
			}
			else
				projectile.penetrate = 1;
			projectile.timeLeft = 1200;
			projectile.scale = 1f;
		}

		public override void AI()
		{
			if (Main.LocalPlayer.HasBuff(mod.BuffType("TheCadenceBuff")))
			{
				int[] array = new int[20];
				int num428 = 0;
				float num429 = 495f;
				bool flag14 = false;
				for (int num430 = 0; num430 < 200; num430++)
				{
					if (Main.npc[num430].CanBeChasedBy(projectile, false))
					{
						float num431 = Main.npc[num430].position.X + Main.npc[num430].width / 2;
						float num432 = Main.npc[num430].position.Y + Main.npc[num430].height / 2;
						float num433 = Math.Abs(projectile.position.X + projectile.width / 2 - num431) + Math.Abs(projectile.position.Y + projectile.height / 2 - num432);
						if (num433 < num429 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num430].Center, 1, 1))
						{
							if (num428 < 20)
							{
								array[num428] = num430;
								num428++;
							}
							flag14 = true;
						}
					}
				}
				if (flag14)
				{
					int num434 = Main.rand.Next(num428);
					num434 = array[num434];
					float num435 = Main.npc[num434].position.X + Main.npc[num434].width / 2;
					float num436 = Main.npc[num434].position.Y + Main.npc[num434].height / 2;
					projectile.localAI[0] += 1f;
					if (projectile.localAI[0] > 8f)
					{
						projectile.localAI[0] = 0f;
						float num437 = 6f;
						Vector2 value10 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
						value10 += projectile.velocity * 4f;
						float num438 = num435 - value10.X;
						float num439 = num436 - value10.Y;
						float num440 = (float)Math.Sqrt(num438 * num438 + num439 * num439);
						num440 = num437 / num440;
						num438 *= num440;
						num439 *= num440;
						if (Main.rand.Next(2) == 0)
						{
							Projectile.NewProjectile(value10.X, value10.Y, num438, num439, mod.ProjectileType("TheCadenceProj"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
						}
					}
				}
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Main.LocalPlayer.HasBuff(mod.BuffType("BouncingCasingBuff")))
			{
				projectile.penetrate--;
				if (projectile.penetrate <= 0)
				{
					projectile.Kill();
				}
				else
				{
					if (projectile.velocity.X != oldVelocity.X)
					{
						projectile.velocity.X = -oldVelocity.X;
					}
					if (projectile.velocity.Y != oldVelocity.Y)
					{
						projectile.velocity.Y = -oldVelocity.Y;
					}
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
				}
			}
			else
			{
				projectile.Kill();
			}

			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107);
			Main.PlaySound(29, (int)projectile.position.X, (int)projectile.position.Y, 20);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 704, 1f);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 705, 1f);
			if (player.HasBuff(mod.BuffType("BrassChipBuff")))
			{
				for (int i = 0; i < 5; i++)
				{
					Vector2 vector2 = new Vector2(player.position.X + 75f * (float)Math.Cos(12), player.position.Y + 1075f * (float)Math.Sin(12));
					Vector2 Velocity = Helper.VelocityToPoint(vector2, Helper.RandomPointInArea(new Vector2(projectile.Center.X - 10, projectile.Center.Y - 10), new Vector2(projectile.Center.X + 20, projectile.Center.Y + 20)), 24);
					int a = Projectile.NewProjectile(vector2.X, vector2.Y, Velocity.X, Velocity.Y, 134, projectile.damage, 1f);
					Main.projectile[a].friendly = true;
				}
			}
			if (player.HasBuff(mod.BuffType("ChaosElementBuff")))
			{
				int num220 = Main.rand.Next(3, 6);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(10, 201) * 0.01f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, mod.ProjectileType("Shatter1"), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
				}
			}
			if (projectile.owner == Main.myPlayer)
			{
				int num231 = (int)(projectile.Center.Y / 16f);
				int num232 = (int)(projectile.Center.X / 16f);
				int num233 = 100;
				if (num232 < 10)
				{
					num232 = 10;
				}
				if (num232 > Main.maxTilesX - 10)
				{
					num232 = Main.maxTilesX - 10;
				}
				if (num231 < 10)
				{
					num231 = 10;
				}
				if (num231 > Main.maxTilesY - num233 - 10)
				{
					num231 = Main.maxTilesY - num233 - 10;
				}
				for (int num234 = num231; num234 < num231 + num233; num234++)
				{
					Tile tile = Main.tile[num232, num234];
					if (tile.active() && (Main.tileSolid[tile.type] || tile.liquid != 0))
					{
						num231 = num234;
						break;
					}
				}
				int num236 = Projectile.NewProjectile(num232 * 16 + 8, num231 * 16 - 24, 0f, 0f, mod.ProjectileType("Dukado"), 80, 4f, Main.myPlayer, 16f, 15f);
				int num237 = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("Dukado"), 80, 4f, Main.myPlayer, 16f, 15f);
				Main.projectile[num236].netUpdate = true;
				Main.projectile[num237].netUpdate = true;
			}
		}
	}
}