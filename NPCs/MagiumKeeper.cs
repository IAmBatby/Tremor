using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class MagiumKeeper : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magium Keeper");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 40;
			npc.defense = 25;
			npc.lifeMax = 3000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath42;
			npc.value = Item.buyPrice(0, 12, 12, 7);
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 482;
			animationType = 471;
			banner = npc.type;
			bannerItem = mod.ItemType("MagiumKeeperBanner");
		}


		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void AI()
		{
			if (npc.ai[3] < 0f)
			{
				npc.knockBackResist = 0f;
				npc.defense = (int)(npc.defDefense * 1.1);
				npc.noGravity = true;
				npc.noTileCollide = true;
				if (npc.velocity.X < 0f)
				{
					npc.direction = -1;
				}
				else if (npc.velocity.X > 0f)
				{
					npc.direction = 1;
				}
				npc.rotation = npc.velocity.X * 0.1f;
				if (Main.netMode != 1)
				{
					npc.localAI[3] += 1f;
					if (npc.localAI[3] > Main.rand.Next(20, 180))
					{
						npc.localAI[3] = 0f;
						Vector2 value3 = npc.position;
						value3 += npc.velocity;
						NPC.NewNPC((int)value3.X, (int)value3.Y, mod.NPCType("MagiumSword"), 0, 0f, 0f, 0f, 0f, 255);
					}
				}
			}
			else
			{
				npc.localAI[3] = 0f;
				npc.knockBackResist = 0.35f * Main.knockBackMultiplier;
				npc.rotation *= 0.9f;
				npc.defense = npc.defDefense;
				npc.noGravity = false;
				npc.noTileCollide = false;
			}
			if (npc.ai[3] == 1f)
			{
				npc.knockBackResist = 0f;
				npc.defense += 10;
			}
			if (npc.ai[3] == -1f)
			{
				npc.TargetClosest(true);
				float num46 = 8f;
				float num47 = 40f;
				Vector2 value4 = Main.player[npc.target].Center - npc.position;
				float num48 = value4.Length();
				num46 += num48 / 200f;
				value4.Normalize();
				value4 *= num46;
				npc.velocity = (npc.velocity * (num47 - 1f) + value4) / num47;
				if (num48 < 500f && !Collision.SolidCollision(npc.position, npc.width, npc.height))
				{
					npc.ai[3] = 0f;
					npc.ai[2] = 0f;
				}
				return;
			}
			if (npc.ai[3] == -2f)
			{
				npc.velocity.Y = npc.velocity.Y - 0.2f;
				if (npc.velocity.Y < -10f)
				{
					npc.velocity.Y = -10f;
				}
				if (Main.player[npc.target].Center.Y - npc.position.Y > 200f)
				{
					npc.TargetClosest(true);
					npc.ai[3] = -3f;
					if (Main.player[npc.target].Center.X > npc.position.X)
					{
						npc.ai[2] = 1f;
					}
					else
					{
						npc.ai[2] = -1f;
					}
				}
				npc.velocity.X = npc.velocity.X * 0.99f;
				return;
			}
			if (npc.ai[3] == -3f)
			{
				if (npc.direction == 0)
				{
					npc.TargetClosest(true);
				}
				if (npc.ai[2] == 0f)
				{
					npc.ai[2] = npc.direction;
				}
				npc.velocity.Y = npc.velocity.Y * 0.9f;
				npc.velocity.X = npc.velocity.X + npc.ai[2] * 0.3f;
				if (npc.velocity.X > 10f)
				{
					npc.velocity.X = 10f;
				}
				if (npc.velocity.X < -10f)
				{
					npc.velocity.X = -10f;
				}
				float num49 = Main.player[npc.target].Center.X - npc.position.X;
				if ((npc.ai[2] < 0f && num49 > 300f) || (npc.ai[2] > 0f && num49 < -300f))
				{
					npc.ai[3] = -4f;
					npc.ai[2] = 0f;
				}
			}
			else
			{
				if (npc.ai[3] == -4f)
				{
					npc.ai[2] += 1f;
					npc.velocity.Y = npc.velocity.Y + 0.1f;
					if (npc.velocity.Length() > 4f)
					{
						npc.velocity *= 0.9f;
					}
					int num50 = (int)npc.position.X / 16;
					int num51 = (int)(npc.position.Y + npc.height + 12f) / 16;
					bool flag4 = false;
					for (int num52 = num50 - 1; num52 <= num50 + 1; num52++)
					{
						if (Main.tile[num52, num51] == null)
						{
							Main.tile[num50, num51] = new Tile();
						}
						if (Main.tile[num52, num51].active() && Main.tileSolid[Main.tile[num52, num51].type])
						{
							flag4 = true;
						}
					}
					if (flag4 && !Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.ai[3] = 0f;
						npc.ai[2] = 0f;
					}
					else if (npc.ai[2] > 300f || npc.position.Y > Main.player[npc.target].Center.Y + 200f)
					{
						npc.ai[3] = -1f;
						npc.ai[2] = 0f;
					}
				}
				else
				{
					if (npc.ai[3] == 1f)
					{
						Vector2 center3 = npc.position;
						center3.Y -= 70f;
						npc.velocity.X = npc.velocity.X * 0.8f;
						npc.ai[2] += 1f;
						if (npc.ai[2] == 60f)
						{
							if (Main.netMode != 1)
							{
								NPC.NewNPC((int)center3.X, (int)center3.Y + 18, mod.NPCType("MagiumFlyer"), 0, 0f, 0f, 0f, 0f, 255);
							}
						}
						else if (npc.ai[2] >= 90f)
						{
							npc.ai[3] = -2f;
							npc.ai[2] = 0f;
						}
						for (int num53 = 0; num53 < 2; num53++)
						{
							Vector2 vector11 = center3;
							Vector2 value5 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
							value5.Normalize();
							value5 *= Main.rand.Next(0, 100) * 0.1f;
							vector11 += value5;
							value5.Normalize();
							value5 *= Main.rand.Next(50, 90) * 0.1f;
							int num54 = Dust.NewDust(vector11, 1, 1, 59, 0f, 0f, 0, default(Color), 3f);
							Main.dust[num54].velocity = -value5 * 0.3f;
							Main.dust[num54].alpha = 100;
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num54].noGravity = true;
								Main.dust[num54].scale += 0.3f;
							}
						}
						return;
					}
					npc.ai[2] += 1f;
					int num55 = 10;
					if (npc.velocity.Y == 0f && NPC.CountNPCS(472) < num55)
					{
						if (npc.ai[2] >= 180f)
						{
							npc.ai[2] = 0f;
							npc.ai[3] = 1f;
						}
					}
					else
					{
						if (NPC.CountNPCS(472) >= num55)
						{
							npc.ai[2] += 1f;
						}
						if (npc.ai[2] >= 360f)
						{
							npc.ai[2] = 0f;
							npc.ai[3] = -2f;
							npc.velocity.Y = npc.velocity.Y - 3f;
						}
					}
					if (npc.target >= 0 && !Main.player[npc.target].dead && (Main.player[npc.target].Center - npc.position).Length() > 800f)
					{
						npc.ai[3] = -1f;
						npc.ai[2] = 0f;
					}
				}
				if (Main.player[npc.target].dead)
				{
					npc.TargetClosest(true);
					if (Main.player[npc.target].dead && npc.timeLeft > 1)
					{
						npc.timeLeft = 1;
					}
				}
			}
		}


		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagiumShard"), Main.rand.Next(5, 12));
				};
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RuneBar"), Main.rand.Next(6, 16));
				};
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagiumGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagiumGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagiumGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagiumGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MagiumGore3"), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Helper.NoZoneAllowWater(spawnInfo)) && Main.hardMode && y > Main.rockLayer ? 0.0003f : 0f;
		}
	}
}
