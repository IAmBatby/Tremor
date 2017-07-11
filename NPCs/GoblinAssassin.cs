using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class GoblinAssassin : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Assassin");
			Main.npcFrameCount[npc.type] = 3;
		}

		int CountFrame = 0;
		int TimeToAnimation = 4;
		public override void SetDefaults()
		{
			npc.lifeMax = 90;
			npc.damage = 21;
			npc.defense = 10;
			npc.knockBackResist = 0.4f;
			npc.width = 46;
			npc.height = 44;
			npc.aiStyle = -1;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 0, 56);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void AI()
		{
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			DoAI();
			ExpertSetting();
			PlayAnimation();
		}

		public void ExpertSetting()
		{
			if (Main.expertMode)
			{
				if (npc.life > npc.lifeMax * 0.5f)
				{
					npc.defense = 13;
				}
				if (npc.life < npc.lifeMax * 0.5f && npc.life > npc.lifeMax * 0.3f)
				{
					npc.defense = 15;
				}
				if (npc.life < npc.lifeMax * 0.3f)
				{
					npc.defense = 18;
				}
			}
		}

		public void PlayAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CountFrame > 3)
					CountFrame = 1;
				TimeToAnimation = 4;
				npc.frame = GetFrame(CountFrame);
			}
		}

		bool TimetoShoot = false;
		public void DoAI()
		{
			Vector2 VectorPos = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
			float FirstPos = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - VectorPos.X;
			float SecondPos = Main.player[npc.target].position.Y - VectorPos.Y;
			float FinallyPos = (float)Math.Sqrt((double)(FirstPos * FirstPos + SecondPos * SecondPos));
			if (!npc.wet && !Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				if (FinallyPos < 400f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
				{
					TimetoShoot = true;
				}
				else
					TimetoShoot = false;
			}
			if (TimetoShoot)
			{
				int Num = 15;
				bool Flag = false;
				bool Flag2 = true;

				if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
				{
					Flag = true;
				}
				if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)Num || Flag)
				{
					npc.ai[3] += 1f;
				}
				else
				{
					if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
					{
						npc.ai[3] -= 1f;
					}
				}
				if (npc.ai[3] > (float)(Num * 10))
				{
					npc.ai[3] = 0f;
				}
				if (npc.justHit)
				{
					npc.ai[3] = 0f;
				}
				if (npc.ai[3] == (float)Num)
				{
					npc.netUpdate = true;
				}

				if (npc.ai[3] < (float)Num)
				{
					npc.TargetClosest(true);
				}
				else
				{
					if (npc.velocity.X == 0f)
					{
						if (npc.velocity.Y == 0f)
						{
							npc.ai[0] += 1f;
							if (npc.ai[0] >= 2f)
							{
								npc.direction *= -1;
								npc.spriteDirection = npc.direction;
								npc.ai[0] = 0f;
							}
						}
					}
					else
					{
						npc.ai[0] = 0f;
					}
					if (npc.direction == 0)
					{
						npc.direction = 1;
					}
				}

				if (npc.velocity.X < -5f || npc.velocity.X > 5f)
				{
					if (npc.velocity.Y == 0f)
					{
						npc.velocity *= 0.8f;
					}
				}
				else
				{
					if (npc.velocity.X < 5f && npc.direction == 1)
					{
						npc.velocity.X = npc.velocity.X + 0.1f;
						if (npc.velocity.X > 5f)
						{
							npc.velocity.X = 5f;
						}
					}
					else
					{
						if (npc.velocity.X > -5f && npc.direction == -1)
						{
							npc.velocity.X = npc.velocity.X - 0.1f;
							if (npc.velocity.X < -5f)
							{
								npc.velocity.X = -5f;
							}
						}
					}
				}

				bool Flag3 = false;
				if (npc.velocity.Y == 0f)
				{
					int Num2 = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
					int Num3 = (int)npc.position.X / 16;
					int Num4 = (int)(npc.position.X + (float)npc.width) / 16;
					for (int l = Num3; l <= Num4; l++)
					{
						if (Main.tile[l, Num2] == null)
						{
							return;
						}
						if (Main.tile[l, Num2].active() && Main.tileSolid[(int)Main.tile[l, Num2].type])
						{
							Flag3 = true;
							break;
						}
					}
				}

				if (Flag3)
				{
					int Num5 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 6) * npc.direction)) / 16f);
					int Num6 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
					if (Main.tile[Num5, Num6] == null)
					{
						Main.tile[Num5, Num6] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 1] == null)
					{
						Main.tile[Num5, Num6 - 1] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 2] == null)
					{
						Main.tile[Num5, Num6 - 2] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 3] == null)
					{
						Main.tile[Num5, Num6 - 3] = new Tile();
					}
					if (Main.tile[Num5, Num6 + 1] == null)
					{
						Main.tile[Num5, Num6 + 1] = new Tile();
					}
					if (Main.tile[Num5 + npc.direction, Num6 - 1] == null)
					{
						Main.tile[Num5 + npc.direction, Num6 - 1] = new Tile();
					}
					if (Main.tile[Num5 + npc.direction, Num6 + 1] == null)
					{
						Main.tile[Num5 + npc.direction, Num6 + 1] = new Tile();
					}

					if (Main.tile[Num5, Num6 - 1].active() && Main.tile[Num5, Num6 - 1].type == 10 && Flag2)
					{
						npc.ai[2] += 1f;
						npc.ai[3] = 0f;
						if (npc.ai[2] >= 60f)
						{
							npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
							npc.ai[1] += 1f;
							npc.ai[2] = 0f;
							bool Flag4 = false;
							if (npc.ai[1] >= 10f)
							{
								Flag4 = true;
								npc.ai[1] = 10f;
							}
							WorldGen.KillTile(Num5, Num6 - 1, true, false, false);
							if ((Main.netMode != 1 || !Flag4) && Flag4 && Main.netMode != 1)
							{
								bool Flag5 = WorldGen.OpenDoor(Num5, Num6, npc.direction);
								if (!Flag5)
								{
									npc.ai[3] = (float)Num;
									npc.netUpdate = true;
								}
								if (Main.netMode == 2 && Flag5)
								{
									//NetMessage.SendData(19, -1, -1, "", 0, (float)Num5, (float)Num6, (float)npc.direction, 0);
								}
							}
						}
					}

					if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
					{
						if (Main.tile[Num5, Num6 - 2].active() && Main.tileSolid[(int)Main.tile[Num5, Num6 - 2].type])
						{
							if ((Main.tile[Num5, Num6 - 3].active() && Main.tileSolid[(int)Main.tile[Num5, Num6 - 3].type]))
							{
								npc.velocity.Y = -8f;
								npc.netUpdate = true;
							}
							else
							{
								npc.velocity.Y = -7f;
								npc.netUpdate = true;
							}
						}
						else
						{
							if (Main.tile[Num5, Num6 - 1].active() && Main.tileSolid[(int)Main.tile[Num5, Num6 - 1].type])
							{
								npc.velocity.Y = -6f;
								npc.netUpdate = true;
							}
							else
							{
								if (Main.tile[Num5, Num6].active() && Main.tileSolid[(int)Main.tile[Num5, Num6].type])
								{
									npc.velocity.Y = -5f;
									npc.netUpdate = true;
								}
								else
								{
									if (npc.directionY < 0 && (!Main.tile[Num5, Num6 + 1].active() || !Main.tileSolid[(int)Main.tile[Num5, Num6 + 1].type]) && (!Main.tile[Num5 + npc.direction, Num6 + 1].active() || !Main.tileSolid[(int)Main.tile[Num5 + npc.direction, Num6 + 1].type]))
									{
										npc.velocity.Y = -8f;
										npc.velocity.X = npc.velocity.X * 1.5f;
										npc.netUpdate = true;
									}
									else
									{
										if (Flag2)
										{
											npc.ai[1] = 0f;
											npc.ai[2] = 0f;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					if (Flag2)
					{
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
				}
			}
			else
			{
				int Num = 15;
				bool Flag = false;
				bool Flag2 = true;

				if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
				{
					Flag = true;
				}
				if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= (float)Num || Flag)
				{
					npc.ai[3] += 1f;
				}
				else
				{
					if ((double)Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
					{
						npc.ai[3] -= 1f;
					}
				}
				if (npc.ai[3] > (float)(Num * 10))
				{
					npc.ai[3] = 0f;
				}
				if (npc.justHit)
				{
					npc.ai[3] = 0f;
				}
				if (npc.ai[3] == (float)Num)
				{
					npc.netUpdate = true;
				}

				if (npc.ai[3] < (float)Num)
				{
					npc.TargetClosest(true);
				}
				else
				{
					if (npc.velocity.X == 0f)
					{
						if (npc.velocity.Y == 0f)
						{
							npc.ai[0] += 1f;
							if (npc.ai[0] >= 2f)
							{
								npc.direction *= -1;
								npc.spriteDirection = npc.direction;
								npc.ai[0] = 0f;
							}
						}
					}
					else
					{
						npc.ai[0] = 0f;
					}
					if (npc.direction == 0)
					{
						npc.direction = 1;
					}
				}

				if (npc.velocity.X < -3f || npc.velocity.X > 3f)
				{
					if (npc.velocity.Y == 0f)
					{
						npc.velocity *= 0.8f;
					}
				}
				else
				{
					if (npc.velocity.X < 3f && npc.direction == 1)
					{
						npc.velocity.X = npc.velocity.X + 0.1f;
						if (npc.velocity.X > 3f)
						{
							npc.velocity.X = 3f;
						}
					}
					else
					{
						if (npc.velocity.X > -3f && npc.direction == -1)
						{
							npc.velocity.X = npc.velocity.X - 0.1f;
							if (npc.velocity.X < -3f)
							{
								npc.velocity.X = -3f;
							}
						}
					}
				}

				bool Flag3 = false;
				if (npc.velocity.Y == 0f)
				{
					int Num2 = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
					int Num3 = (int)npc.position.X / 16;
					int Num4 = (int)(npc.position.X + (float)npc.width) / 16;
					for (int l = Num3; l <= Num4; l++)
					{
						if (Main.tile[l, Num2] == null)
						{
							return;
						}
						if (Main.tile[l, Num2].active() && Main.tileSolid[(int)Main.tile[l, Num2].type])
						{
							Flag3 = true;
							break;
						}
					}
				}

				if (Flag3)
				{
					int Num5 = (int)((npc.position.X + (float)(npc.width / 2) + (float)((npc.width / 2 + 6) * npc.direction)) / 16f);
					int Num6 = (int)((npc.position.Y + (float)npc.height - 15f) / 16f);
					if (Main.tile[Num5, Num6] == null)
					{
						Main.tile[Num5, Num6] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 1] == null)
					{
						Main.tile[Num5, Num6 - 1] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 2] == null)
					{
						Main.tile[Num5, Num6 - 2] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 3] == null)
					{
						Main.tile[Num5, Num6 - 3] = new Tile();
					}
					if (Main.tile[Num5, Num6 + 1] == null)
					{
						Main.tile[Num5, Num6 + 1] = new Tile();
					}
					if (Main.tile[Num5 + npc.direction, Num6 - 1] == null)
					{
						Main.tile[Num5 + npc.direction, Num6 - 1] = new Tile();
					}
					if (Main.tile[Num5 + npc.direction, Num6 + 1] == null)
					{
						Main.tile[Num5 + npc.direction, Num6 + 1] = new Tile();
					}

					if (Main.tile[Num5, Num6 - 1].active() && Main.tile[Num5, Num6 - 1].type == 10 && Flag2)
					{
						npc.ai[2] += 1f;
						npc.ai[3] = 0f;
						if (npc.ai[2] >= 60f)
						{
							npc.velocity.X = 0.5f * (float)(-(float)npc.direction);
							npc.ai[1] += 1f;
							npc.ai[2] = 0f;
							bool Flag4 = false;
							if (npc.ai[1] >= 10f)
							{
								Flag4 = true;
								npc.ai[1] = 10f;
							}
							WorldGen.KillTile(Num5, Num6 - 1, true, false, false);
							if ((Main.netMode != 1 || !Flag4) && Flag4 && Main.netMode != 1)
							{
								bool Flag5 = WorldGen.OpenDoor(Num5, Num6, npc.direction);
								if (!Flag5)
								{
									npc.ai[3] = (float)Num;
									npc.netUpdate = true;
								}
								if (Main.netMode == 2 && Flag5)
								{
									//NetMessage.SendData(19, -1, -1, "", 0, (float)Num5, (float)Num6, (float)npc.direction, 0);
								}
							}
						}
					}

					if ((npc.velocity.X < 0f && npc.spriteDirection == -1) || (npc.velocity.X > 0f && npc.spriteDirection == 1))
					{
						if (Main.tile[Num5, Num6 - 2].active() && Main.tileSolid[(int)Main.tile[Num5, Num6 - 2].type])
						{
							if ((Main.tile[Num5, Num6 - 3].active() && Main.tileSolid[(int)Main.tile[Num5, Num6 - 3].type]))
							{
								npc.velocity.Y = -8f;
								npc.netUpdate = true;
							}
							else
							{
								npc.velocity.Y = -7f;
								npc.netUpdate = true;
							}
						}
						else
						{
							if (Main.tile[Num5, Num6 - 1].active() && Main.tileSolid[(int)Main.tile[Num5, Num6 - 1].type])
							{
								npc.velocity.Y = -6f;
								npc.netUpdate = true;
							}
							else
							{
								if (Main.tile[Num5, Num6].active() && Main.tileSolid[(int)Main.tile[Num5, Num6].type])
								{
									npc.velocity.Y = -5f;
									npc.netUpdate = true;
								}
								else
								{
									if (npc.directionY < 0 && (!Main.tile[Num5, Num6 + 1].active() || !Main.tileSolid[(int)Main.tile[Num5, Num6 + 1].type]) && (!Main.tile[Num5 + npc.direction, Num6 + 1].active() || !Main.tileSolid[(int)Main.tile[Num5 + npc.direction, Num6 + 1].type]))
									{
										npc.velocity.Y = -8f;
										npc.velocity.X = npc.velocity.X * 1.5f;
										npc.netUpdate = true;
									}
									else
									{
										if (Flag2)
										{
											npc.ai[1] = 0f;
											npc.ai[2] = 0f;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					if (Flag2)
					{
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (NPC.AnyNPCs(26) || NPC.AnyNPCs(27) || NPC.AnyNPCs(28) || NPC.AnyNPCs(29)) && NPC.downedBoss3 && y < Main.worldSurface ? 0.08f : 0f;
		}

		public override void NPCLoot()
		{
			if (Main.invasionType == Terraria.ID.InvasionID.GoblinArmy)
			{
				Main.invasionProgress++;
			}
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 161, Main.rand.Next(1, 15));
				}

				if (Main.rand.Next(200) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 160);
				}
			}
		}

		Rectangle GetFrame(int Num)
		{
			return new Rectangle(0, npc.frame.Height * (Num - 1), npc.frame.Width, npc.frame.Height);
		}
	}
}