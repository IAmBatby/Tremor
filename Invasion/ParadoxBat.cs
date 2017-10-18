using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class ParadoxBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Bat");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 750;
			npc.damage = 105;
			npc.defense = 35;
			npc.knockBackResist = 0f;
			npc.width = 34;
			npc.height = 20;
			animationType = 75;
			npc.aiStyle = -1;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit55;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.color = Color.White;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			float spawn = 20f;
			if (InvasionWorld.CyberWrath)
				return 1000f;
			return 0f;

			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return InvasionWorld.CyberWrath && y > Main.worldSurface ? 1f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 10; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
				if (InvasionWorld.CyberWrath && Main.rand.NextBool(2))
				{
					InvasionWorld.CyberWrathPoints1 += 1;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

		int TimeToAnimation = 6;
		int AnimationRate = 6;
		int FrameCount = 4;
		float DistortPercent = 0.15f;
		int Frame = 0;

		/*void PlayAnimation()
        {
            if (--TimeToAnimation <= 0)
            {
                TimeToAnimation = (int)Helper.DistortFloat(AnimationRate, DistortPercent);
                if (++Frame >= FrameCount)
                    Frame = 0;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects Direction = (npc.target == -1) ? SpriteEffects.None : ((Main.player[npc.target].position.X < npc.position.X) ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            spriteBatch.Draw(Main.npcTexture[npc.type], new Rectangle((int)(npc.position.X - Main.screenPosition.X), (int)(npc.position.Y - Main.screenPosition.Y), npc.width, npc.height), new Rectangle(0, Frame * npc.height, npc.width, npc.height), drawColor, 0, new Vector2(0, 0), Direction, 0);
            return false;
        }  */

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ParadoxElement"), Main.rand.Next(3, 5));
				}
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SecondHand"));
				}
			}
		}

		float customAi1;
		bool FirstState;
		bool SecondState;
		public override void AI()
		{
			//PlayAnimation();
			if (npc.life > npc.lifeMax / 2)
			{
				FirstState = true;
			}

			if (npc.life < npc.lifeMax / 2)
			{
				FirstState = false;
				SecondState = true;
			}

			if (Main.rand.Next(150) == 0)
			{
				for (int num36 = 0; num36 < 25; num36++)
				{
					int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, mod.DustType<CyberDust>(), npc.velocity.X + Main.rand.Next(-10, 10), npc.velocity.Y + Main.rand.Next(-10, 10), 1, npc.color, 1f);
					Main.dust[dust].noGravity = true;
				}

				npc.ai[3] = (float)(Main.rand.Next(360) * (Math.PI / 180));
				npc.ai[2] = 0;
				npc.ai[1] = 0;
				if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
				{
					npc.TargetClosest(true);
				}
				if (Main.player[npc.target].dead)
				{
					npc.position.X = 0;
					npc.position.Y = 0;
					if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
						return;
					}
				}
				else
				{
					npc.position.X = Main.player[npc.target].position.X + (float)((250 * Math.Cos(npc.ai[3])) * -1);
					npc.position.Y = Main.player[npc.target].position.Y + (float)((250 * Math.Sin(npc.ai[3])) * -1);
				}
			}
			if (Main.rand.NextBool(2))
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), 0f, 0f, 200, npc.color, 0.5f);
				Main.dust[num706].velocity *= 0.6f;
			}
			if (FirstState)
			{
				npc.TargetClosest(true);
				Vector2 PTC = Main.player[npc.target].position + new Vector2(npc.width / 2, npc.height / 2);
				Vector2 NPos = npc.position + new Vector2(npc.width / 2, npc.height / 2);
				npc.netUpdate = true;

				if (npc.ai[1] == 0)
				{
					if (Main.player[npc.target].position.X < npc.position.X)
					{
						if (npc.velocity.X > -8) npc.velocity.X -= 0.10f;
					}

					if (Main.player[npc.target].position.X > npc.position.X)
					{
						if (npc.velocity.X < 8) npc.velocity.X += 0.10f;
					}

					if (Main.player[npc.target].position.Y < npc.position.Y + 200)
					{
						if (npc.velocity.Y < 0)
						{
							if (npc.velocity.Y > -4) npc.velocity.Y -= 0.4f;
						}
						else npc.velocity.Y -= 0.8f;
					}

					if (Main.player[npc.target].position.Y > npc.position.Y + 200)
					{
						if (npc.velocity.Y > 0)
						{
							if (npc.velocity.Y < 4) npc.velocity.Y += 0.4f;
						}
						else npc.velocity.Y += 0.6f;
					}
				}

				customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
				if (customAi1 >= 4f)
					if (Main.rand.Next(120) == 1)
					{
						Main.PlaySound(16, (int)npc.position.X, (int)npc.position.Y, 12);
						float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
						int SpitShot1 = Projectile.NewProjectile(NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), mod.ProjectileType("CyberLaserBat"), 30, 0f, 0);
						//Main.projectile[SpitShot1].friendly = false;
						Main.projectile[SpitShot1].timeLeft = 500;
						customAi1 = 1f;
					}
				npc.netUpdate = true;

				if (Main.rand.NextBool(6))
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), 0f, 0f, 200, npc.color, 0.4f);
					Main.dust[dust].velocity *= 0.4f;
				}

				if (npc.ai[1] == 1)
				{

				}

				npc.ai[2] += 1;
				if (npc.ai[2] >= 600)
				{
					if (npc.ai[1] == 0) npc.ai[1] = 1;
					else npc.ai[1] = 0;
				}
				if (npc.life > 500)
				{
					Color color = new Color();
					int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, mod.DustType<CyberDust>(), npc.velocity.X, npc.velocity.Y, 100, color, 0.6f);
					Main.dust[dust].noGravity = true;
				}
				else if (npc.life <= 200)
				{
					Color color = new Color();
					int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, mod.DustType<CyberDust>(), npc.velocity.X, npc.velocity.Y, 50, color, 0.8f);
					Main.dust[dust].noGravity = true;
				}
			}

			if (SecondState && !FirstState)
			{
				Vector2 PTC = Main.player[npc.target].position + new Vector2(npc.width / 2, npc.height / 2);
				Vector2 NPos = npc.position + new Vector2(npc.width / 2, npc.height / 2);
				if (Main.rand.Next(70) == 1)
				{
					Main.PlaySound(16, (int)npc.position.X, (int)npc.position.Y, 12);
					float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
					int SpitShot1 = Projectile.NewProjectile(NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), mod.ProjectileType("CyberLaserBat"), 30, 0f, 0);
					//Main.projectile[SpitShot1].friendly = false;
					Main.projectile[SpitShot1].timeLeft = 500;
					customAi1 = 1f;
				}
				float npc_to_target_x = npc.position.X + npc.width / 2 - Main.player[npc.target].position.X - Main.player[npc.target].width / 2;
				float npc_to_target_y = npc.position.Y + npc.height - 59f - Main.player[npc.target].position.Y - Main.player[npc.target].height / 2; // 59(3.7 blocks) above bottom(slightly above center; ht is 110) to target center
				float npc_to_target_angle = (float)Math.Atan2(npc_to_target_y, npc_to_target_x) + 1.57f; // angle+pi/2
				if (npc_to_target_angle < 0f) // modulus
					npc_to_target_angle += 6.283f;
				else if (npc_to_target_angle > 6.283)
					npc_to_target_angle -= 6.283f;
				float rotation_rate = 0.15f;
				float top_speed = 4f;
				float accel = 0.1f;
				int close_side_of_target = 1;
				if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width)
					close_side_of_target = -1;

				Vector2 npc_pos = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
				npc_to_target_x = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + close_side_of_target * 360 - npc_pos.X;
				npc_to_target_y = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 + close_side_of_target * 160 - npc_pos.Y;
				float dist_to_target = (float)Math.Sqrt(npc_to_target_x * npc_to_target_x + npc_to_target_y * npc_to_target_y);
				dist_to_target = top_speed / dist_to_target;
				npc_to_target_x *= dist_to_target;
				npc_to_target_y *= dist_to_target;

				if (npc.velocity.X < npc_to_target_x)
				{
					npc.velocity.X = npc.velocity.X + accel;
					if (npc.velocity.X < 0f && npc_to_target_x > 0f)
						npc.velocity.X = npc.velocity.X + accel;
				}
				else if (npc.velocity.X > npc_to_target_x)
				{
					npc.velocity.X = npc.velocity.X - accel;
					if (npc.velocity.X > 0f && npc_to_target_x < 0f)
						npc.velocity.X = npc.velocity.X - accel;
				}
				if (npc.velocity.Y < npc_to_target_y)
				{
					npc.velocity.Y = npc.velocity.Y + accel;
					if (npc.velocity.Y < 0f && npc_to_target_y > 0f)
						npc.velocity.Y = npc.velocity.Y + accel;
				}
				else if (npc.velocity.Y > npc_to_target_y)
				{
					npc.velocity.Y = npc.velocity.Y - accel;
					if (npc.velocity.Y > 0f && npc_to_target_y < 0f)
						npc.velocity.Y = npc.velocity.Y - accel;
				}

				bool target_dead = Main.player[npc.target].dead;
				if (target_dead)
				{
					npc.velocity.Y = npc.velocity.Y - 0.04f;
					if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
				}
				else
				{
					if (npc.ai[1] == 0f)
					{
						top_speed = 4f;
						accel = 0.1f;
						close_side_of_target = 1;
						if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width)
							close_side_of_target = -1;

						npc_pos = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
						npc_to_target_x = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + close_side_of_target * 360 - npc_pos.X; //360 pix in front of target
						npc_to_target_y = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 + close_side_of_target * 160 - npc_pos.Y; //160 pix above target
						dist_to_target = (float)Math.Sqrt(npc_to_target_x * npc_to_target_x + npc_to_target_y * npc_to_target_y);
						dist_to_target = top_speed / dist_to_target;
						npc_to_target_x *= dist_to_target;
						npc_to_target_y *= dist_to_target;

						if (npc.velocity.X < npc_to_target_x)
						{
							npc.velocity.X = npc.velocity.X + accel;
							if (npc.velocity.X < 0f && npc_to_target_x > 0f)
								npc.velocity.X = npc.velocity.X + accel;
						}
						else if (npc.velocity.X > npc_to_target_x)
						{
							npc.velocity.X = npc.velocity.X - accel;
							if (npc.velocity.X > 0f && npc_to_target_x < 0f)
								npc.velocity.X = npc.velocity.X - accel;
						}
						if (npc.velocity.Y < npc_to_target_y)
						{
							npc.velocity.Y = npc.velocity.Y + accel;
							if (npc.velocity.Y < 0f && npc_to_target_y > 0f)
								npc.velocity.Y = npc.velocity.Y + accel;
						}
						else if (npc.velocity.Y > npc_to_target_y)
						{
							npc.velocity.Y = npc.velocity.Y - accel;
							if (npc.velocity.Y > 0f && npc_to_target_y < 0f)
								npc.velocity.Y = npc.velocity.Y - accel;
						}

						npc.ai[2] += 1f; // inc count till charge
						if (npc.ai[2] >= 400f) // charge after 400 ticks
						{
							npc.ai[1] = 1f; // transition state to 'start charge'
							npc.ai[2] = 0f;
							npc.ai[3] = 0f;
							npc.target = 255; // retarget
							npc.netUpdate = true;
						}
						if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
						{
							npc.localAI[2] += 1f; // ???
							if (Main.netMode != 1) // is server
							{ // localAI[1] grows faster the less life left
								npc.localAI[1] += 1f;

								if (npc.localAI[1] > 12f)
								{
									npc.localAI[1] = 10f;
									float projectile_velocity = 15f;
									int projectile_dmg = 75;
									npc_pos = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
									npc_to_target_x = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - npc_pos.X;
									npc_to_target_y = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - npc_pos.Y;
									dist_to_target = (float)Math.Sqrt(npc_to_target_x * npc_to_target_x + npc_to_target_y * npc_to_target_y);
									dist_to_target = projectile_velocity / dist_to_target; // prep to normalize by velocity
									npc_to_target_x *= dist_to_target; // normalize by velocity
									npc_to_target_y *= dist_to_target; // normalize by velocity
									npc_to_target_y += npc.velocity.Y * 0.5f; // advance fwd half a tick
									npc_to_target_x += npc.velocity.X * 0.5f; // advance fwd half a tick
									npc_pos.X -= npc_to_target_x * 1f;
									npc_pos.Y -= npc_to_target_y * 1f;
									//Projectile.NewProjectile(npc_pos.X, npc_pos.Y, npc_to_target_x, npc_to_target_y, ProjDef.byName["Pumpking:TerraGuardLaser"].type, projectile_dmg, 0f, Main.myPlayer);
								}
							}
						}
					}
					else if (npc.ai[1] == 1f)
					{
						npc.rotation = npc_to_target_angle;
						float speed = 14f;
						npc_pos = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
						npc_to_target_x = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - npc_pos.X;
						npc_to_target_y = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - npc_pos.Y;
						dist_to_target = (float)Math.Sqrt(npc_to_target_x * npc_to_target_x + npc_to_target_y * npc_to_target_y);
						dist_to_target = speed / dist_to_target;
						npc.velocity.X = npc_to_target_x * dist_to_target;
						npc.velocity.Y = npc_to_target_y * dist_to_target;
						npc.ai[1] = 2f;
					}
					else if (npc.ai[1] == 2f)
					{
						npc.ai[2] += 1f;
						if (npc.ai[2] >= 50f)
						{
							npc.velocity.X = npc.velocity.X * 0.93f;
							npc.velocity.Y = npc.velocity.Y * 0.93f;
							if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
								npc.velocity.X = 0f;
							if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
								npc.velocity.Y = 0f;
						}
						else
							npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) - 1.57f;

						if (npc.ai[2] >= 80f)
						{
							npc.ai[3] += 1f;
							npc.ai[2] = 0f;
							npc.target = 255;
							npc.rotation = npc_to_target_angle;
							if (npc.ai[3] >= 6f)
							{
								npc.ai[1] = 0f;
								npc.ai[3] = 0f;
								return;
							}
							npc.ai[1] = 1f;
						}
					}
				}
			}
		}
	}
}