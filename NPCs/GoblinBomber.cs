using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class GoblinBomber : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Bomber");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 90;
			npc.damage = 50;
			npc.defense = 0;
			npc.knockBackResist = 0.3f;
			npc.width = 42;
			npc.height = 56;
			npc.aiStyle = -1;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 1, 21);
		}
		
		public override void AI()
		{
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			DoAI();
		}

		public void DoAI()
		{
			int Num = 15;
			bool Flag = false;
			bool Flag2 = true;

			if (npc.velocity.Y == 0f && ((npc.velocity.X > 0f && npc.direction < 0) || (npc.velocity.X < 0f && npc.direction > 0)))
			{
				Flag = true;
			}
			if (npc.position.X == npc.oldPosition.X || npc.ai[3] >= Num || Flag)
			{
				npc.ai[3] += 1f;
			}
			else
			{
				if (Math.Abs(npc.velocity.X) > 0.9 && npc.ai[3] > 0f)
				{
					npc.ai[3] -= 1f;
				}
			}
			if (npc.ai[3] > Num * 10)
			{
				npc.ai[3] = 0f;
			}
			if (npc.justHit)
			{
				npc.ai[3] = 0f;
			}
			if (npc.ai[3] == Num)
			{
				npc.netUpdate = true;
			}

			if (npc.ai[3] < Num)
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
				int Num2 = (int)(npc.position.Y + npc.height + 8f) / 16;
				int Num3 = (int)npc.position.X / 16;
				int Num4 = (int)(npc.position.X + npc.width) / 16;
				for (int l = Num3; l <= Num4; l++)
				{
					if (Main.tile[l, Num2] == null)
					{
						return;
					}
					if (Main.tile[l, Num2].active() && Main.tileSolid[Main.tile[l, Num2].type])
					{
						Flag3 = true;
						break;
					}
				}
			}

			if (Flag3)
			{
				int Num5 = (int)((npc.position.X + npc.width / 2 + (npc.width / 2 + 6) * npc.direction) / 16f);
				int Num6 = (int)((npc.position.Y + npc.height - 15f) / 16f);
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
						npc.velocity.X = 0.5f * -(float)npc.direction;
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
								npc.ai[3] = Num;
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
					if (Main.tile[Num5, Num6 - 2].active() && Main.tileSolid[Main.tile[Num5, Num6 - 2].type])
					{
						if ((Main.tile[Num5, Num6 - 3].active() && Main.tileSolid[Main.tile[Num5, Num6 - 3].type]))
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
						if (Main.tile[Num5, Num6 - 1].active() && Main.tileSolid[Main.tile[Num5, Num6 - 1].type])
						{
							npc.velocity.Y = -6f;
							npc.netUpdate = true;
						}
						else
						{
							if (Main.tile[Num5, Num6].active() && Main.tileSolid[Main.tile[Num5, Num6].type])
							{
								npc.velocity.Y = -5f;
								npc.netUpdate = true;
							}
							else
							{
								if (npc.directionY < 0 && (!Main.tile[Num5, Num6 + 1].active() || !Main.tileSolid[Main.tile[Num5, Num6 + 1].type]) && (!Main.tile[Num5 + npc.direction, Num6 + 1].active() || !Main.tileSolid[Main.tile[Num5 + npc.direction, Num6 + 1].type]))
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

		public override void FindFrame(int frameHeight)
		{
			if ((npc.frameCounter += Math.Abs(npc.velocity.X)) >= 20)
			{
				npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
				npc.frameCounter = 0;
			}
			npc.spriteDirection = npc.direction;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			npc.life = -1;
			HitEffect(-1, 0);
			npc.checkDead();
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 62);
				npc.position.X = npc.position.X + npc.width / 2;
				npc.position.Y = npc.position.Y + npc.height / 2;
				npc.width = 80;
				npc.height = 80;
				npc.position.X = npc.position.X - npc.width / 2;
				npc.position.Y = npc.position.Y - npc.height / 2;

				for (int i = 0; i < 40; i++)
				{
					int num629 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 31, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num629].velocity *= 3f;
					if (Main.rand.NextBool(2))
					{
						Main.dust[num629].scale = 0.5f;
						Main.dust[num629].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
					}
				}
				for (int i = 0; i < 70; i++)
				{
					int num631 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6, 0f, 0f, 100, default(Color), 3f);
					Main.dust[num631].noGravity = true;
					Main.dust[num631].velocity *= 5f;
					num631 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num631].velocity *= 2f;
				}
				for (int num632 = 0; num632 < 3; num632++)
				{
					float scaleFactor10 = 0.33f;
					if (num632 == 1)
					{
						scaleFactor10 = 0.66f;
					}
					if (num632 == 2)
					{
						scaleFactor10 = 1f;
					}
					Gore gore = Main.gore[Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64))];
					gore.velocity *= scaleFactor10;
					gore.velocity.X = gore.velocity.X + 1f;
					gore.velocity.Y = gore.velocity.Y + 1f;

					gore = Main.gore[Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 2f)];
					gore.velocity *= scaleFactor10;
					gore.velocity.X = gore.velocity.X - 1f;
					gore.velocity.Y = gore.velocity.Y + 1f;

					gore = Main.gore[Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64))];
					gore.velocity *= scaleFactor10;
					gore.velocity.X = gore.velocity.X + 1f;
					gore.velocity.Y = gore.velocity.Y - 1f;

					gore = Main.gore[Gore.NewGore(new Vector2(npc.position.X + npc.width / 2 - 24f, npc.position.Y + npc.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64))];
					gore.velocity *= scaleFactor10;
					gore.velocity.X = gore.velocity.X - 1f;
					gore.velocity.Y = gore.velocity.Y - 1f;
				}
				npc.position.X = npc.position.X + npc.width / 2;
				npc.position.Y = npc.position.Y + npc.height / 2;
				npc.width = 10;
				npc.height = 10;
				npc.position.X = npc.position.X - npc.width / 2;
				npc.position.Y = npc.position.Y - npc.height / 2;
			}
		}

		public override void NPCLoot()
		{
			if (Main.invasionType == InvasionID.GoblinArmy)
			{
				Main.invasionSize -= 1;
				if (Main.invasionSize < 0)
					Main.invasionSize = 0;
				if (Main.netMode != 1)
					Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, Main.invasionSizeStart, InvasionID.GoblinArmy + 3, 0);
				if (Main.netMode == 2)
					NetMessage.SendData(78, -1, -1, null, Main.invasionProgress, Main.invasionProgressMax, Main.invasionProgressIcon, 0f, 0, 0, 0);
			}

			if (Main.rand.NextBool(2))
				npc.NewItem(ItemID.SpikyBall, Main.rand.Next(1, 16));
			if (Main.rand.Next(200) == 0)
				npc.NewItem(ItemID.Harpoon);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.invasionType == InvasionID.GoblinArmy && NPC.downedBoss3 && spawnInfo.spawnTileY < Main.worldSurface ? 0.08f : 0f;
	}
}