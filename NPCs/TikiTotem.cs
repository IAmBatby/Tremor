using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class TikiTotem : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiki Totem");
			Main.npcFrameCount[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 2500;
			npc.damage = 12;
			npc.defense = 12;
			npc.knockBackResist = 0.02f;
			npc.width = 86;
			npc.height = 162;
			animationType = 325;
			npc.boss = true;
			music = 39;
			aiType = 77;
			npc.aiStyle = -1;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 60, 0);
			bossBag = mod.ItemType("TikiTotemBag");
			NPCID.Sets.TrailCacheLength[npc.type] = 5;
			npc.dontTakeDamage = true;
		}

		//Variables
		bool FirstState = true;
		bool SpawnTiki;
		int Timer;
		bool Flag1 = true;
		bool Flag2 = true;
		bool Flag3 = true;
		List<int> TikiSouls = new List<int>();
		public override void AI()
		{
			if (NPC.AnyNPCs(mod.NPCType("HappySoul")) || NPC.AnyNPCs(mod.NPCType("AngerSoul")) || NPC.AnyNPCs(mod.NPCType("IndifferenceSoul")))
			{
				npc.position += npc.velocity * 1f;
			}
			Timer++;
			for (int num74 = npc.oldPos.Length - 1; num74 > 0; num74--)
			{
				npc.oldPos[num74] = npc.oldPos[num74 - 1];
			}
			npc.oldPos[0] = npc.position;
			if (Main.time % 600 == 0)
			{
				npc.position.X = Main.player[npc.target].position.X;
				npc.position.Y = Main.player[npc.target].position.Y - 300f;
			}
			if (NPC.CountNPCS(mod.NPCType("TikiSoul")) <= ((Main.expertMode) ? 6 : 3) && Main.time % 60 == 0 && !SpawnTiki)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TikiSoul"));
			}
			if (NPC.CountNPCS(mod.NPCType("TikiSoul")) >= ((Main.expertMode) ? 6 : 3))
			{
				SpawnTiki = true;
			}
			if (NPC.CountNPCS(mod.NPCType("TikiSoul")) == 0 && Timer >= 200)
			{
				FirstState = false;
			}
			if (FirstState)
			{
				npc.aiStyle = 3;
			}
			else
			{
				npc.aiStyle = -1;
				npc.dontTakeDamage = false;
				if (Main.rand.Next(280) == 0 && NPC.CountNPCS(mod.NPCType("TikiWarrior")) < 7)
				{
					NPC.NewNPC((int)npc.Center.X - 70, (int)npc.Center.Y, mod.NPCType("TikiWarrior"));
				}

				if (Main.rand.Next(180) == 0 && NPC.CountNPCS(mod.NPCType("TikiWarrior")) < 4)
				{
					NPC.NewNPC((int)npc.Center.X + 30, (int)npc.Center.Y, mod.NPCType("TikiSorcerer"));
				}
				float num1263 = 2f;
				npc.noGravity = true;
				npc.noTileCollide = true;
				if (!Main.dayTime)
				{
					npc.TargetClosest(true);
				}
				bool flag116 = false;
				if (npc.life < npc.lifeMax * 0.75)
				{
					num1263 = 3f;
				}
				if (npc.life < npc.lifeMax * 0.5)
				{
					num1263 = 4f;
				}
				else if (npc.ai[0] == 0f)
				{
					npc.ai[1] += 1f;
					if (npc.life < npc.lifeMax * 0.5)
					{
						npc.ai[1] += 1f;
					}
					if (npc.life < npc.lifeMax * 0.25)
					{
						npc.ai[1] += 1f;
					}
					if (npc.ai[1] >= 300f && Main.netMode != 1)
					{
						npc.ai[1] = 0f;
						if (npc.life < npc.lifeMax * 0.25 && npc.type != 344)
						{
							npc.ai[0] = Main.rand.Next(3, 5);
						}
						else
						{
							npc.ai[0] = Main.rand.Next(1, 3);
						}
						npc.netUpdate = true;
					}
				}
				else if (npc.ai[0] == 1f)
				{
					if (npc.type == 344)
					{
						flag116 = true;
						npc.ai[1] += 1f;
						if (npc.ai[1] % 5f == 0f)
						{
							Vector2 vector146 = new Vector2(npc.position.X + 20f + Main.rand.Next(npc.width - 40), npc.position.Y + 20f + Main.rand.Next(npc.height - 40));
							float num1264 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector146.X;
							float num1265 = Main.player[npc.target].position.Y - vector146.Y;
							num1264 += Main.rand.Next(-50, 51);
							num1265 += Main.rand.Next(-50, 51);
							num1265 -= Math.Abs(num1264) * (Main.rand.Next(0, 21) * 0.01f);
							float num1266 = (float)Math.Sqrt(num1264 * num1264 + num1265 * num1265);
							float num1267 = 12.5f;
							num1266 = num1267 / num1266;
							num1264 *= num1266;
							num1265 *= num1266;
							num1264 *= 1f + Main.rand.Next(-20, 21) * 0.02f;
							num1265 *= 1f + Main.rand.Next(-20, 21) * 0.02f;
							Projectile.NewProjectile(vector146.X, vector146.Y, num1264, num1265, mod.ProjectileType("LizardPro"), 23, 0f, Main.myPlayer, Main.rand.Next(0, 31), 0f);
						}
						if (npc.ai[1] >= 180f)
						{
							npc.ai[1] = 0f;
							npc.ai[0] = 0f;
						}
					}
					else
					{
						flag116 = true;
						npc.ai[1] += 1f;
						if (npc.ai[1] % 15f == 0f)
						{
							Vector2 vector147 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f + 30f);
							float num1268 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector147.X;
							float num1269 = Main.player[npc.target].position.Y - vector147.Y;
							float num1270 = (float)Math.Sqrt(num1268 * num1268 + num1269 * num1269);
							float num1271 = 10f;
							num1270 = num1271 / num1270;
							num1268 *= num1270;
							num1269 *= num1270;
							num1268 *= 1f + Main.rand.Next(-20, 21) * 0.01f;
							num1269 *= 1f + Main.rand.Next(-20, 21) * 0.01f;
							Projectile.NewProjectile(vector147.X, vector147.Y, num1268, num1269, mod.ProjectileType("LizardPro"), 50, 0f, Main.myPlayer, 0f, 0f);
						}
						if (npc.ai[1] >= 120f)
						{
							npc.ai[1] = 0f;
							npc.ai[0] = 0f;
						}
					}
				}
				else if (npc.ai[0] == 2f)
				{
					if (npc.type == 344)
					{
						flag116 = true;
						npc.ai[1] += 1f;
						if (npc.ai[1] > 60f && npc.ai[1] < 240f && npc.ai[1] % 15f == 0f)
						{
							float num1272 = 4.5f;
							Vector2 vector148 = new Vector2(npc.position.X + 20f + Main.rand.Next(npc.width - 40), npc.position.Y + 60f + Main.rand.Next(npc.height - 80));
							float num1273 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector148.X;
							float num1274 = Main.player[npc.target].position.Y - vector148.Y;
							num1274 -= Math.Abs(num1273) * 0.3f;
							num1272 += Math.Abs(num1273) * 0.004f;
							num1273 += Main.rand.Next(-50, 51);
							num1274 -= Main.rand.Next(50, 201);
							float num1275 = (float)Math.Sqrt(num1273 * num1273 + num1274 * num1274);
							num1275 = num1272 / num1275;
							num1273 *= num1275;
							num1274 *= num1275;
							num1273 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
							num1274 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
							Projectile.NewProjectile(vector148.X, vector148.Y, num1273, num1274, mod.ProjectileType("LizardPro"), 23, 0f, Main.myPlayer, 0f, Main.rand.Next(2));
						}
						if (npc.ai[1] >= 300f)
						{
							npc.ai[1] = 0f;
							npc.ai[0] = 0f;
						}
					}
					else
					{
						flag116 = true;
						npc.ai[1] += 1f;
						if (npc.ai[1] > 60f && npc.ai[1] < 240f && npc.ai[1] % 8f == 0f)
						{
							float num1276 = 10f;
							Vector2 vector149 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f + 30f);
							float num1277 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector149.X;
							float num1278 = Main.player[npc.target].position.Y - vector149.Y;
							num1278 -= Math.Abs(num1277) * 0.3f;
							num1276 += Math.Abs(num1277) * 0.004f;
							if (num1276 > 14f)
							{
								num1276 = 14f;
							}
							num1277 += Main.rand.Next(-50, 51);
							num1278 -= Main.rand.Next(50, 61);
							float num1279 = (float)Math.Sqrt(num1277 * num1277 + num1278 * num1278);
							num1279 = num1276 / num1279;
							num1277 *= num1279;
							num1278 *= num1279;
							num1277 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
							num1278 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
							Projectile.NewProjectile(vector149.X, vector149.Y, num1277, num1278, 81, 23, 0f, Main.myPlayer, 0f, 0f);
						}
						if (npc.ai[1] >= 300f)
						{
							npc.ai[1] = 0f;
							npc.ai[0] = 0f;
						}
					}
				}
				else if (npc.ai[0] == 3f)
				{
					num1263 = 4f;
					npc.ai[1] += 1f;
					if (npc.ai[1] % 30f == 0f)
					{
						Vector2 vector150 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f + 30f);
						float num1280 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector150.X;
						float num1281 = Main.player[npc.target].position.Y - vector150.Y;
						float num1282 = (float)Math.Sqrt(num1280 * num1280 + num1281 * num1281);
						float num1283 = 16f;
						num1282 = num1283 / num1282;
						num1280 *= num1282;
						num1281 *= num1282;
						num1280 *= 1f + Main.rand.Next(-20, 21) * 0.001f;
						num1281 *= 1f + Main.rand.Next(-20, 21) * 0.001f;
						Projectile.NewProjectile(vector150.X, vector150.Y, num1280, num1281, mod.ProjectileType("LizardPro"), 23, 0f, Main.myPlayer, 0f, 0f);
					}
					if (npc.ai[1] >= 120f)
					{
						npc.ai[1] = 0f;
						npc.ai[0] = 0f;
					}
				}
				else if (npc.ai[0] == 4f)
				{
					num1263 = 4f;
					npc.ai[1] += 1f;
					if (npc.ai[1] % 10f == 0f)
					{
						float num1284 = 12f;
						Vector2 vector151 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f + 30f);
						float num1285 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector151.X;
						float num1286 = Main.player[npc.target].position.Y - vector151.Y;
						num1286 -= Math.Abs(num1285) * 0.2f;
						num1284 += Math.Abs(num1285) * 0.002f;
						if (num1284 > 16f)
						{
							num1284 = 16f;
						}
						num1285 += Main.rand.Next(-50, 51);
						num1286 -= Main.rand.Next(50, 71);
						float num1287 = (float)Math.Sqrt(num1285 * num1285 + num1286 * num1286);
						num1287 = num1284 / num1287;
						num1285 *= num1287;
						num1286 *= num1287;
						num1285 *= 1f + Main.rand.Next(-30, 31) * 0.005f;
						num1286 *= 1f + Main.rand.Next(-30, 31) * 0.005f;
						Projectile.NewProjectile(vector151.X, vector151.Y, num1285, num1286, 81, 23, 0f, Main.myPlayer, 0f, 0f);
					}
					if (npc.ai[1] >= 240f)
					{
						npc.ai[1] = 0f;
						npc.ai[0] = 0f;
					}
				}
				if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) < 50f)
				{
					flag116 = true;
				}
				if (flag116)
				{
					npc.velocity.X = npc.velocity.X * 0.9f;
					if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
					{
						npc.velocity.X = 0f;
					}
				}
				else
				{
					if (npc.direction > 0)
					{
						npc.velocity.X = (npc.velocity.X * 20f + num1263) / 21f;
					}
					if (npc.direction < 0)
					{
						npc.velocity.X = (npc.velocity.X * 20f - num1263) / 21f;
					}
				}
				int num1288 = 80;
				int num1289 = 20;
				Vector2 position7 = new Vector2(npc.Center.X - num1288 / 2, npc.position.Y + npc.height - num1289);
				bool flag117 = false;
				if (npc.position.X < Main.player[npc.target].position.X && npc.position.X + npc.width > Main.player[npc.target].position.X + Main.player[npc.target].width && npc.position.Y + npc.height < Main.player[npc.target].position.Y + Main.player[npc.target].height - 16f)
				{
					flag117 = true;
				}
				if (flag117)
				{
					npc.velocity.Y = npc.velocity.Y + 0.5f;
				}
				else if (Collision.SolidCollision(position7, num1288, num1289))
				{
					if (npc.velocity.Y > 0f)
					{
						npc.velocity.Y = 0f;
					}
					if (npc.velocity.Y > -0.2)
					{
						npc.velocity.Y = npc.velocity.Y - 0.025f;
					}
					else
					{
						npc.velocity.Y = npc.velocity.Y - 0.2f;
					}
					if (npc.velocity.Y < -4f)
					{
						npc.velocity.Y = -4f;
					}
				}
				else
				{
					if (npc.velocity.Y < 0f)
					{
						npc.velocity.Y = 0f;
					}
					if (npc.velocity.Y < 0.1)
					{
						npc.velocity.Y = npc.velocity.Y + 0.025f;
					}
					else
					{
						npc.velocity.Y = npc.velocity.Y + 0.5f;
					}
				}
				if (npc.velocity.Y > 10f)
				{
					npc.velocity.Y = 10f;
					return;
				}

				if (npc.life < npc.lifeMax * 0.5f && Flag1)
				{
					Flag1 = false;
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 95, mod.NPCType("HappySoul"));
				}
				if (npc.life < npc.lifeMax * 0.3f && Flag2)
				{
					Flag2 = false;
					NPC.NewNPC((int)npc.Center.X - 50, (int)npc.Center.Y + 110, mod.NPCType("AngerSoul"));
				}
				if (npc.life < npc.lifeMax * 0.1f && Flag3)
				{
					Flag3 = false;
					NPC.NewNPC((int)npc.Center.X + 50, (int)npc.Center.Y + 110, mod.NPCType("IndifferenceSoul"));
				}
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Timer = 0;
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/TikiTotemGore1"), 1f);
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/TikiTotemGore2"), 1f);
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/TikiTotemGore3"), 1f);
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width, Main.npcTexture[npc.type].Height * 0.8f);
			for (int k = 0; k < npc.oldPos.Length; k++)
			{
				Vector2 drawPos = npc.oldPos[k] - Main.screenPosition;
				Color color = npc.GetAlpha(lightColor) * ((npc.oldPos.Length - k) / (float)npc.oldPos.Length);
				Rectangle frame = new Rectangle(0, 0, 86, 162);
				frame.Y += 164 * (k / 60);

				spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, frame, color, 0, Vector2.Zero, npc.scale, SpriteEffects.None, 1f);
			}
			return true;
		}

		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.Center.X + npc.width / 2) / 16;
				int centerY = (int)(npc.Center.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("ToxicBlade"));
				};
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JungleAlloy"));
				};
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("PickaxeofBloom"));
				};
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("ToxicHilt"));
				};
				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("AngryTotemMask"));
				}
				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("HappyTotemMask"));
				}
				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("IndifferentTotemMask"));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, 188, Main.rand.Next(6, 18));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, 189, Main.rand.Next(6, 18));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("TikiTotemTrophy"));
				}
				if (!TremorWorld.downedTikiTotem)
				{
					Main.NewText("Ghosts are returning to ruins...", 193, 139, 77);
					TremorWorld.downedTikiTotem = true;
				}
			}
		}
	}
}