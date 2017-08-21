using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class DesertPrincess : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Princess");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.npcSlots = 5f;
			npc.aiStyle = -1;
			aiType = -1;
			npc.damage = 110;
			npc.width = 77;
			npc.height = 72;
			npc.defense = 45;
			npc.lifeMax = 22000;
			npc.knockBackResist = 0f;
			npc.scale = 1f;
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.value = Item.buyPrice(0, 15, 0, 0);
			npc.HitSound = SoundID.NPCHit45;
			npc.DeathSound = SoundID.NPCDeath47;
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}

		int CurrentFrame;
		int TimeToAnimation = 4;
		public override void AI()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CurrentFrame > 2)
					CurrentFrame = 1;
				TimeToAnimation = 4;
				npc.frame = GetFrame(CurrentFrame + 0);
			}
			Player player = Main.player[npc.target];
			int num1305 = 3;
			npc.noTileCollide = false;
			npc.noGravity = true;
			npc.damage = npc.defDamage;
			if (npc.target < 0 || player.dead || !player.active)
			{
				npc.TargetClosest(true);
				if (player.dead)
				{
					npc.ai[0] = -1f;
				}
			}
			else
			{
				Vector2 vector205 = player.Center - npc.Center;
				if (npc.ai[0] > 1f && vector205.Length() > 1000f)
				{
					npc.ai[0] = 1f;
				}
			}
			if (npc.ai[0] == -1f)
			{
				Vector2 value50 = new Vector2(0f, -8f);
				npc.velocity = (npc.velocity * 9f + value50) / 10f;
				npc.noTileCollide = true;
				npc.dontTakeDamage = true;
				return;
			}
			if (npc.ai[0] == 0f)
			{
				npc.TargetClosest(true);
				if (npc.Center.X < player.Center.X - 2f)
				{
					npc.direction = 1;
				}
				if (npc.Center.X > player.Center.X + 2f)
				{
					npc.direction = -1;
				}
				npc.spriteDirection = npc.direction;
				npc.rotation = (npc.rotation * 9f + npc.velocity.X * 0.1f) / 10f;
				if (npc.collideX)
				{
					npc.velocity.X = npc.velocity.X * (-npc.oldVelocity.X * 0.5f);
					if (npc.velocity.X > 16f)
					{
						npc.velocity.X = 16f;
					}
					if (npc.velocity.X < -16f)
					{
						npc.velocity.X = -16f;
					}
				}
				if (npc.collideY)
				{
					npc.velocity.Y = npc.velocity.Y * (-npc.oldVelocity.Y * 0.5f);
					if (npc.velocity.Y > 16f)
					{
						npc.velocity.Y = 16f;
					}
					if (npc.velocity.Y < -16f)
					{
						npc.velocity.Y = -16f;
					}
				}
				Vector2 value51 = player.Center - npc.Center;
				value51.Y -= 200f;
				if (value51.Length() > 800f)
				{
					npc.ai[0] = 1f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
				}
				else if (value51.Length() > 80f)
				{
					float scaleFactor15 = 12f;
					float num1306 = 60f;
					value51.Normalize();
					value51 *= scaleFactor15;
					npc.velocity = (npc.velocity * (num1306 - 1f) + value51) / num1306;
				}
				else if (npc.velocity.Length() > 2f)
				{
					npc.velocity *= 0.95f;
				}
				else if (npc.velocity.Length() < 1f)
				{
					npc.velocity *= 1.05f;
				}
				npc.ai[1] += 1f;
				if (npc.justHit)
				{
					npc.ai[1] += Main.rand.Next(10, 30);
				}
				if (npc.ai[1] >= 180f && Main.netMode != 1)
				{
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
					npc.netUpdate = true;
					while (npc.ai[0] == 0f)
					{
						int num1307 = Main.rand.Next(3);
						if (num1307 == 0 && Collision.CanHit(npc.Center, 1, 1, player.Center, 1, 1))
						{
							npc.ai[0] = 2f;
						}
						else if (num1307 == 1)
						{
							npc.ai[0] = 3f;
						}
						else if (num1307 == 2 && NPC.CountNPCS(mod.NPCType("DesertPrincess2")) < num1305)
						{
							npc.ai[0] = 4f;
						}
					}
				}
			}
			else
			{
				if (npc.ai[0] == 1f)
				{
					npc.collideX = false;
					npc.collideY = false;
					npc.noTileCollide = true;
					if (npc.target < 0 || !player.active || player.dead)
					{
						npc.TargetClosest(true);
					}
					if (npc.velocity.X < 0f)
					{
						npc.direction = -1;
					}
					else if (npc.velocity.X > 0f)
					{
						npc.direction = 1;
					}
					npc.spriteDirection = npc.direction;
					npc.rotation = (npc.rotation * 9f + npc.velocity.X * 0.08f) / 10f;
					Vector2 value52 = player.Center - npc.Center;
					if (value52.Length() < 300f && !Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.ai[0] = 0f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.ai[3] = 0f;
					}
					float scaleFactor16 = 14f + value52.Length() / 100f;
					float num1308 = 25f;
					value52.Normalize();
					value52 *= scaleFactor16;
					npc.velocity = (npc.velocity * (num1308 - 1f) + value52) / num1308;
					return;
				}
				if (npc.ai[0] == 2f)
				{
					npc.damage = (int)(npc.defDamage * 0.85);
					if (npc.target < 0 || !player.active || player.dead)
					{
						npc.TargetClosest(true);
						npc.ai[0] = 0f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.ai[3] = 0f;
					}
					if (player.Center.X - 10f < npc.Center.X)
					{
						npc.direction = -1;
					}
					else if (player.Center.X + 10f > npc.Center.X)
					{
						npc.direction = 1;
					}
					npc.spriteDirection = npc.direction;
					npc.rotation = (npc.rotation * 4f + npc.velocity.X * 0.1f) / 5f;
					if (npc.collideX)
					{
						npc.velocity.X = npc.velocity.X * (-npc.oldVelocity.X * 0.5f);
						if (npc.velocity.X > 16f)
						{
							npc.velocity.X = 16f;
						}
						if (npc.velocity.X < -16f)
						{
							npc.velocity.X = -16f;
						}
					}
					if (npc.collideY)
					{
						npc.velocity.Y = npc.velocity.Y * (-npc.oldVelocity.Y * 0.5f);
						if (npc.velocity.Y > 16f)
						{
							npc.velocity.Y = 16f;
						}
						if (npc.velocity.Y < -16f)
						{
							npc.velocity.Y = -16f;
						}
					}
					Vector2 value53 = player.Center - npc.Center;
					value53.Y -= 20f;
					npc.ai[2] += 0.0222222228f;
					if (Main.expertMode)
					{
						npc.ai[2] += 0.0166666675f;
					}
					float scaleFactor17 = 4f + npc.ai[2] + value53.Length() / 120f;
					float num1309 = 20f;
					value53.Normalize();
					value53 *= scaleFactor17;
					npc.velocity = (npc.velocity * (num1309 - 1f) + value53) / num1309;
					npc.ai[1] += 1f;
					if (npc.ai[1] > 240f || !Collision.CanHit(npc.Center, 1, 1, player.Center, 1, 1))
					{
						npc.ai[0] = 0f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.ai[3] = 0f;
					}
				}
				else
				{
					if (npc.ai[0] == 3f)
					{
						npc.noTileCollide = true;
						if (npc.velocity.X < 0f)
						{
							npc.direction = -1;
						}
						else
						{
							npc.direction = 1;
						}
						npc.spriteDirection = npc.direction;
						npc.rotation = (npc.rotation * 4f + npc.velocity.X * 0.07f) / 5f;
						Vector2 value54 = player.Center - npc.Center;
						value54.Y -= 12f;
						if (npc.Center.X > player.Center.X)
						{
							value54.X += 400f;
						}
						else
						{
							value54.X -= 400f;
						}
						if (Math.Abs(npc.Center.X - player.Center.X) > 350f && Math.Abs(npc.Center.Y - player.Center.Y) < 20f)
						{
							npc.ai[0] = 3.1f;
							npc.ai[1] = 0f;
						}
						npc.ai[1] += 0.0333333351f;
						float scaleFactor18 = 8f + npc.ai[1];
						float num1310 = 8f;
						value54.Normalize();
						value54 *= scaleFactor18;
						npc.velocity = (npc.velocity * (num1310 - 1f) + value54) / num1310;
						return;
					}
					if (npc.ai[0] == 3.1f)
					{
						npc.noTileCollide = true;
						npc.rotation = (npc.rotation * 4f + npc.velocity.X * 0.07f) / 5f;
						Vector2 vector206 = player.Center - npc.Center;
						vector206.Y -= 12f;
						float scaleFactor19 = 16f;
						float num1311 = 32f;
						vector206.Normalize();
						vector206 *= scaleFactor19;
						npc.velocity = (npc.velocity * (num1311 - 1f) + vector206) / num1311;
						if (npc.velocity.X < 0f)
						{
							npc.direction = -1;
						}
						else
						{
							npc.direction = 1;
						}
						npc.spriteDirection = npc.direction;
						npc.ai[1] += 1f;
						if (npc.ai[1] > 10f)
						{
							npc.velocity = vector206;
							if (npc.velocity.X < 0f)
							{
								npc.direction = -1;
							}
							else
							{
								npc.direction = 1;
							}
							npc.ai[0] = 3.2f;
							npc.ai[1] = 0f;
							npc.ai[1] = npc.direction;
						}
					}
					else
					{
						if (npc.ai[0] == 3.2f)
						{
							npc.damage = (int)(npc.defDamage * 1.3);
							npc.collideX = false;
							npc.collideY = false;
							npc.noTileCollide = true;
							npc.ai[2] += 0.0333333351f;
							npc.velocity.X = (16f + npc.ai[2]) * npc.ai[1];
							if ((npc.ai[1] > 0f && npc.Center.X > player.Center.X + 260f) || (npc.ai[1] < 0f && npc.Center.X < player.Center.X - 260f))
							{
								if (!Collision.SolidCollision(npc.position, npc.width, npc.height))
								{
									npc.ai[0] = 0f;
									npc.ai[1] = 0f;
									npc.ai[2] = 0f;
									npc.ai[3] = 0f;
								}
								else if (Math.Abs(npc.Center.X - player.Center.X) > 800f)
								{
									npc.ai[0] = 1f;
									npc.ai[1] = 0f;
									npc.ai[2] = 0f;
									npc.ai[3] = 0f;
								}
							}
							npc.rotation = (npc.rotation * 4f + npc.velocity.X * 0.07f) / 5f;
							return;
						}
						if (npc.ai[0] == 4f)
						{
							npc.ai[0] = 0f;
							npc.TargetClosest(true);
							if (Main.netMode != 1)
							{
								npc.ai[1] = -1f;
								npc.ai[2] = -1f;
								for (int num1312 = 0; num1312 < 1000; num1312++)
								{
									int num1313 = (int)player.Center.X / 16;
									int num1314 = (int)player.Center.Y / 16;
									int num1315 = 30 + num1312 / 50;
									int num1316 = 20 + num1312 / 75;
									num1313 += Main.rand.Next(-num1315, num1315 + 1);
									num1314 += Main.rand.Next(-num1316, num1316 + 1);
									if (!WorldGen.SolidTile(num1313, num1314))
									{
										while (!WorldGen.SolidTile(num1313, num1314) && num1314 < Main.worldSurface)
										{
											num1314++;
										}
										if ((new Vector2(num1313 * 16 + 8, num1314 * 16 + 8) - player.Center).Length() < 600f)
										{
											npc.ai[0] = 4.1f;
											npc.ai[1] = num1313;
											npc.ai[2] = num1314;
											break;
										}
									}
								}
							}
							npc.netUpdate = true;
							return;
						}
						if (npc.ai[0] == 4.1f)
						{
							if (npc.velocity.X < -2f)
							{
								npc.direction = -1;
							}
							else if (npc.velocity.X > 2f)
							{
								npc.direction = 1;
							}
							npc.spriteDirection = npc.direction;
							npc.rotation = (npc.rotation * 9f + npc.velocity.X * 0.1f) / 10f;
							npc.noTileCollide = true;
							int num1317 = (int)npc.ai[1];
							int num1318 = (int)npc.ai[2];
							float x2 = num1317 * 16 + 8;
							float y2 = num1318 * 16 - 20;
							Vector2 vector207 = new Vector2(x2, y2);
							vector207 -= npc.Center;
							float num1319 = 6f + vector207.Length() / 150f;
							if (num1319 > 10f)
							{
								num1319 = 10f;
							}
							float num1320 = 40f;
							if (vector207.Length() < 10f)
							{
								npc.ai[0] = 4.2f;
							}
							vector207.Normalize();
							vector207 *= num1319;
							npc.velocity = (npc.velocity * (num1320 - 1f) + vector207) / num1320;
							return;
						}
						if (npc.ai[0] == 4.2f)
						{
							npc.rotation = (npc.rotation * 9f + npc.velocity.X * 0.1f) / 10f;
							npc.noTileCollide = true;
							int num1321 = (int)npc.ai[1];
							int num1322 = (int)npc.ai[2];
							float x3 = num1321 * 16 + 8;
							float y3 = num1322 * 16 - 20;
							Vector2 vector208 = new Vector2(x3, y3);
							vector208 -= npc.Center;
							float num1323 = 4f;
							float num1324 = 2f;
							if (Main.netMode != 1 && vector208.Length() < 4f)
							{
								int num1325 = 70;
								if (Main.expertMode)
								{
									num1325 = (int)(num1325 * 0.75);
								}
								npc.ai[3] += 1f;
								if (npc.ai[3] == num1325)
								{
									NPC.NewNPC(num1321 * 16 + 8, num1322 * 16, mod.NPCType("DesertPrincess2"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
								}
								else if (npc.ai[3] == num1325 * 2)
								{
									npc.ai[0] = 0f;
									npc.ai[1] = 0f;
									npc.ai[2] = 0f;
									npc.ai[3] = 0f;
									if (NPC.CountNPCS(mod.NPCType("DesertPrincess2")) < num1305 && Main.rand.Next(3) != 0)
									{
										npc.ai[0] = 4f;
									}
									else if (Collision.SolidCollision(npc.position, npc.width, npc.height))
									{
										npc.ai[0] = 1f;
									}
								}
							}
							if (vector208.Length() > num1323)
							{
								vector208.Normalize();
								vector208 *= num1323;
							}
							npc.velocity = (npc.velocity * (num1324 - 1f) + vector208) / num1324;
						}
					}
				}
			}
		}


		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.player.ZoneJungle && NPC.downedPlantBoss ? 0.001f : 0f;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void NPCLoot()
		{
			Helper.DropItems(npc.position, npc.Size, new Drop(mod.ItemType("DesertExplorerVisage"), 1, 1), new Drop(mod.ItemType("DesertExplorerGreaves"), 1, 2), new Drop(mod.ItemType("DesertExplorerBreastplate"), 1, 2));
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 500, Main.rand.Next(5, 15));
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(5, 15));
		}
	}
}