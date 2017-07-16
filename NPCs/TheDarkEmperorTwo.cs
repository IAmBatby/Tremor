using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class TheDarkEmperorTwo : ModNPC
	{

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DEGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DETGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DETGore2"), 1f);
			}
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Dark Emperor");
			Main.npcFrameCount[npc.type] = 6;
		}


		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 95000;
			npc.damage = 180;
			npc.defense = 220;
			animationType = 345;
			npc.knockBackResist = 0f;
			npc.width = 130;
			npc.height = 140;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath10;
			music = 17;
			bossBag = mod.ItemType("DarkEmperorBag");
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.npcSlots = 10f;
		}


		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void AI()
		{

			Lighting.AddLight(npc.position, 1f, 0.3f, 0.3f);


			bool allDead = false;
			for (int i = 0; i < Main.player.Length; i++)
			{
				if (Main.player[i].dead) allDead = true;
			}

			if (allDead)
			{
				if (npc.velocity.X > 0f)
				{
					npc.velocity.X = npc.velocity.X + 0.75f;
				}
				else
				{
					npc.velocity.X = npc.velocity.X - 0.75f;
				}
				npc.velocity.Y = npc.velocity.Y - 0.1f;
				npc.rotation = npc.velocity.X * 0.05f;
			}
			else if (npc.ai[0] == 0f)
			{
				if (npc.ai[2] == 0f)
				{
					npc.TargetClosest(true);
					if (npc.Center.X < Main.player[npc.target].Center.X)
					{
						npc.ai[2] = 1f;
					}
					else
					{
						npc.ai[2] = -1f;
					}
				}
				npc.TargetClosest(true);
				int num1319 = 800;
				float num1320 = Math.Abs(npc.Center.X - Main.player[npc.target].Center.X);
				if (npc.Center.X < Main.player[npc.target].Center.X && npc.ai[2] < 0f && num1320 > num1319)
				{
					npc.ai[2] = 0f;
				}
				if (npc.Center.X > Main.player[npc.target].Center.X && npc.ai[2] > 0f && num1320 > num1319)
				{
					npc.ai[2] = 0f;
				}
				float num1321 = 0.45f;
				float num1322 = 7f;
				if (npc.life < npc.lifeMax * 0.75)
				{
					num1321 = 0.55f;
					num1322 = 8f;
				}
				if (npc.life < npc.lifeMax * 0.5)
				{
					num1321 = 0.7f;
					num1322 = 10f;
				}
				if (npc.life < npc.lifeMax * 0.25)
				{
					num1321 = 0.8f;
					num1322 = 11f;
				}
				npc.velocity.X = npc.velocity.X + npc.ai[2] * num1321;
				if (npc.velocity.X > num1322)
				{
					npc.velocity.X = num1322;
				}
				if (npc.velocity.X < -num1322)
				{
					npc.velocity.X = -num1322;
				}
				float num1323 = Main.player[npc.target].position.Y - (npc.position.Y + npc.height);
				if (num1323 < 150f)
				{
					npc.velocity.Y = npc.velocity.Y - 0.2f;
				}
				if (num1323 > 200f)
				{
					npc.velocity.Y = npc.velocity.Y + 0.2f;
				}
				if (npc.velocity.Y > 8f)
				{
					npc.velocity.Y = 8f;
				}
				if (npc.velocity.Y < -8f)
				{
					npc.velocity.Y = -8f;
				}
				npc.rotation = npc.velocity.X * 0.05f;
				if ((num1320 < 500f || npc.ai[3] < 0f) && npc.position.Y < Main.player[npc.target].position.Y)
				{
					npc.ai[3] += 1f;
					int num1324 = 13;
					if (npc.life < npc.lifeMax * 0.75)
					{
						num1324 = 12;
					}
					if (npc.life < npc.lifeMax * 0.5)
					{
						num1324 = 11;
					}
					if (npc.life < npc.lifeMax * 0.25)
					{
						num1324 = 10;
					}
					num1324++;
					if (npc.ai[3] > num1324)
					{
						npc.ai[3] = -(float)num1324;
					}
					if (npc.ai[3] == 0f && Main.netMode != 1)
					{
						Vector2 vector159 = new Vector2(npc.Center.X, npc.Center.Y);
						vector159.X += npc.velocity.X * 7f;
						float num1325 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector159.X;
						float num1326 = Main.player[npc.target].Center.Y - vector159.Y;
						float num1327 = (float)Math.Sqrt(num1325 * num1325 + num1326 * num1326);
						float num1328 = 6f;
						if (npc.life < npc.lifeMax * 0.75)
						{
							num1328 = 7f;
						}
						if (npc.life < npc.lifeMax * 0.5)
						{
							num1328 = 8f;
						}
						if (npc.life < npc.lifeMax * 0.25)
						{
							num1328 = 9f;
						}
						num1327 = num1328 / num1327;
						num1325 *= num1327;
						num1326 *= num1327;
						Projectile.NewProjectile(vector159.X, vector159.Y, num1325, num1326, mod.ProjectileType("FallingDarkServant"), 54, 0f, Main.myPlayer, 0f, 0f);
					}
				}
				else if (npc.ai[3] < 0f)
				{
					npc.ai[3] += 1f;
				}
				if (Main.netMode != 1)
				{
					npc.ai[1] += Main.rand.Next(1, 4);
					if (npc.ai[1] > 800f && num1320 < 600f)
					{
						npc.ai[0] = -1f;
					}
				}
			}
			else if (npc.ai[0] == 1f)
			{
				npc.TargetClosest(true);
				float num1329 = 0.15f;
				float num1330 = 7f;
				if (npc.life < npc.lifeMax * 0.75)
				{
					num1329 = 0.17f;
					num1330 = 8f;
				}
				if (npc.life < npc.lifeMax * 0.5)
				{
					num1329 = 0.2f;
					num1330 = 9f;
				}
				if (npc.life < npc.lifeMax * 0.25)
				{
					num1329 = 0.25f;
					num1330 = 10f;
				}
				num1329 -= 0.05f;
				num1330 -= 1f;
				if (npc.Center.X < Main.player[npc.target].Center.X)
				{
					npc.velocity.X = npc.velocity.X + num1329;
					if (npc.velocity.X < 0f)
					{
						npc.velocity.X = npc.velocity.X * 0.98f;
					}
				}
				if (npc.Center.X > Main.player[npc.target].Center.X)
				{
					npc.velocity.X = npc.velocity.X - num1329;
					if (npc.velocity.X > 0f)
					{
						npc.velocity.X = npc.velocity.X * 0.98f;
					}
				}
				if (npc.velocity.X > num1330 || npc.velocity.X < -num1330)
				{
					npc.velocity.X = npc.velocity.X * 0.95f;
				}
				float num1331 = Main.player[npc.target].position.Y - (npc.position.Y + npc.height);
				if (num1331 < 180f)
				{
					npc.velocity.Y = npc.velocity.Y - 0.1f;
				}
				if (num1331 > 200f)
				{
					npc.velocity.Y = npc.velocity.Y + 0.1f;
				}
				if (npc.velocity.Y > 6f)
				{
					npc.velocity.Y = 6f;
				}
				if (npc.velocity.Y < -6f)
				{
					npc.velocity.Y = -6f;
				}
				npc.rotation = npc.velocity.X * 0.01f;
				if (Main.netMode != 1)
				{
					npc.ai[3] += 1f;
					int num1332 = 15;
					if (npc.life < npc.lifeMax * 0.75)
					{
						num1332 = 14;
					}
					if (npc.life < npc.lifeMax * 0.5)
					{
						num1332 = 12;
					}
					if (npc.life < npc.lifeMax * 0.25)
					{
						num1332 = 10;
					}
					if (npc.life < npc.lifeMax * 0.1)
					{
						num1332 = 8;
					}
					num1332 += 3;
					if (npc.ai[3] >= num1332)
					{
						npc.ai[3] = 0f;
						Vector2 vector160 = new Vector2(npc.Center.X, npc.position.Y + npc.height - 14f);
						int i2 = (int)(vector160.X / 16f);
						int j2 = (int)(vector160.Y / 16f);
						if (!WorldGen.SolidTile(i2, j2))
						{
							float num1333 = npc.velocity.Y;
							if (num1333 < 0f)
							{
								num1333 = 0f;
							}
							num1333 += 3f;
							float speedX2 = npc.velocity.X * 0.25f;
							Projectile.NewProjectile(vector160.X, vector160.Y, speedX2, num1333, mod.ProjectileType("FallingDarkSlime"), 34, 0f, Main.myPlayer, Main.rand.Next(5), 0f);
						}
					}
				}
				if (Main.netMode != 1)
				{
					npc.ai[1] += Main.rand.Next(1, 4);
					if (npc.ai[1] > 600f)
					{
						npc.ai[0] = -1f;
					}
				}
			}
			else if (npc.ai[0] == 2f)
			{
				npc.TargetClosest(true);
				Vector2 vector161 = new Vector2(npc.Center.X, npc.Center.Y - 20f);
				float num1334 = Main.rand.Next(-1000, 1001);
				float num1335 = Main.rand.Next(-1000, 1001);
				float num1336 = (float)Math.Sqrt(num1334 * num1334 + num1335 * num1335);
				float num1337 = 15f;
				npc.velocity *= 0.95f;
				num1336 = num1337 / num1336;
				num1334 *= num1336;
				num1335 *= num1336;
				npc.rotation += 0.2f;
				vector161.X += num1334 * 4f;
				vector161.Y += num1335 * 4f;
				npc.ai[3] += 1f;
				int num1338 = 7;
				if (npc.life < npc.lifeMax * 0.75)
				{
					num1338--;
				}
				if (npc.life < npc.lifeMax * 0.5)
				{
					num1338 -= 2;
				}
				if (npc.life < npc.lifeMax * 0.25)
				{
					num1338 -= 3;
				}
				if (npc.life < npc.lifeMax * 0.1)
				{
					num1338 -= 4;
				}
				if (npc.ai[3] > num1338)
				{
					npc.ai[3] = 0f;
					Projectile.NewProjectile(vector161.X, vector161.Y, num1334, num1335, mod.ProjectileType("DarkBubblePro"), 40, 0f, Main.myPlayer, 0f, 0f);
				}
				if (Main.netMode != 1)
				{
					npc.ai[1] += Main.rand.Next(1, 4);
					if (npc.ai[1] > 500f)
					{
						npc.ai[0] = -1f;
					}
				}
			}
			if (npc.ai[0] == -1f)
			{
				int num1339 = Main.rand.Next(3);
				npc.TargetClosest(true);
				if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) > 1000f)
				{
					num1339 = 0;
				}
				npc.ai[0] = num1339;
				npc.ai[1] = 0f;
				npc.ai[2] = 0f;
				npc.ai[3] = 0f;
			}

		}

		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}

			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;


				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkEmperorMask"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkEmperorTrophy"));
				}
				if (!Main.expertMode && Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DrippingScythe"));
				}
				if (!Main.expertMode && Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DelightfulClump"));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NastyJavelin"), Main.rand.Next(30, 50));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkGel"), Main.rand.Next(50, 100));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulofFight"), Main.rand.Next(20, 30));
				}
				TremorWorld.downedDarkEmperor = true;
			}
		}
	}
}