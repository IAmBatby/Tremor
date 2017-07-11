using Terraria.ID;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
    public class CyberKing : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyber King");
			Main.npcFrameCount[npc.type] = 6;
		}
 

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyberKingGore3"), 1f);
        }
}

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 60000;
            npc.damage = 80;
            npc.defense = 65;
            npc.knockBackResist = 0f;
            npc.width = 70;
            npc.height = 68;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath6;
            music = MusicID.Boss2;
            bossBag = mod.ItemType("CyberKingBag");
        }


        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override void AI()
        {

Lighting.AddLight(npc.position, 1f, 0.3f, 0.3f);

        if(Main.rand.Next(900) == 0)
        {
            NPC.NewNPC((int)npc.position.X + 60, (int)npc.position.Y, mod.NPCType("Cybermite"));
            NPC.NewNPC((int)npc.position.X - 60, (int)npc.position.Y, mod.NPCType("Cybermite"));
            NPC.NewNPC((int)npc.position.X, (int)npc.position.Y+60, mod.NPCType("Cybermite"));
            NPC.NewNPC((int)npc.position.X, (int)npc.position.Y-60, mod.NPCType("Cybermite"));
        }


bool allDead = false;
for(int i = 0; i < Main.player.Length; i++)
{
    if(Main.player[i].dead) allDead = true;
}

									if (Main.dayTime || allDead)
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
										if (npc.Center.X < Main.player[npc.target].Center.X && npc.ai[2] < 0f && num1320 > (float)num1319)
										{
											npc.ai[2] = 0f;
										}
										if (npc.Center.X > Main.player[npc.target].Center.X && npc.ai[2] > 0f && num1320 > (float)num1319)
										{
											npc.ai[2] = 0f;
										}
										float num1321 = 0.45f;
										float num1322 = 7f;
										if ((double)npc.life < (double)npc.lifeMax * 0.75)
										{
											num1321 = 0.55f;
											num1322 = 8f;
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.5)
										{
											num1321 = 0.7f;
											num1322 = 10f;
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.25)
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
										float num1323 = Main.player[npc.target].position.Y - (npc.position.Y + (float)npc.height);
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
											if ((double)npc.life < (double)npc.lifeMax * 0.75)
											{
												num1324 = 12;
											}
											if ((double)npc.life < (double)npc.lifeMax * 0.5)
											{
												num1324 = 11;
											}
											if ((double)npc.life < (double)npc.lifeMax * 0.25)
											{
												num1324 = 10;
											}
											num1324++;
											if (npc.ai[3] > (float)num1324)
											{
												npc.ai[3] = (float)(-(float)num1324);
											}
											if (npc.ai[3] == 0f && Main.netMode != 1)
											{
												Vector2 vector159 = new Vector2(npc.Center.X, npc.Center.Y);
												vector159.X += npc.velocity.X * 7f;
												float num1325 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector159.X;
												float num1326 = Main.player[npc.target].Center.Y - vector159.Y;
												float num1327 = (float)Math.Sqrt((double)(num1325 * num1325 + num1326 * num1326));
												float num1328 = 6f;
												if ((double)npc.life < (double)npc.lifeMax * 0.75)
												{
													num1328 = 7f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.5)
												{
													num1328 = 8f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.25)
												{
													num1328 = 9f;
												}
												num1327 = num1328 / num1327;
												num1325 *= num1327;
												num1326 *= num1327;
										Projectile.NewProjectile(vector159.X, vector159.Y, num1325, num1326, mod.ProjectileType("CyberRingPro"), 42, 0f, Main.myPlayer, 0f, 0f);	
											}
										}
										else if (npc.ai[3] < 0f)
										{
											npc.ai[3] += 1f;
										}
										if (Main.netMode != 1)
										{
											npc.ai[1] += (float)Main.rand.Next(1, 4);
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
										if ((double)npc.life < (double)npc.lifeMax * 0.75)
										{
											num1329 = 0.17f;
											num1330 = 8f;
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.5)
										{
											num1329 = 0.2f;
											num1330 = 9f;
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.25)
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
										float num1331 = Main.player[npc.target].position.Y - (npc.position.Y + (float)npc.height);
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
											if ((double)npc.life < (double)npc.lifeMax * 0.75)
											{
												num1332 = 14;
											}
											if ((double)npc.life < (double)npc.lifeMax * 0.5)
											{
												num1332 = 12;
											}
											if ((double)npc.life < (double)npc.lifeMax * 0.25)
											{
												num1332 = 10;
											}
											if ((double)npc.life < (double)npc.lifeMax * 0.1)
											{
												num1332 = 8;
											}
											num1332 += 3;
											if (npc.ai[3] >= (float)num1332)
											{
												npc.ai[3] = 0f;
												Vector2 vector160 = new Vector2(npc.Center.X, npc.position.Y + (float)npc.height - 14f);
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
													Projectile.NewProjectile(vector160.X, vector160.Y, speedX2, num1333, mod.ProjectileType("RedPulsePro"), 42, 0f, Main.myPlayer, (float)Main.rand.Next(5), 0f);
												}
											}
										}
										if (Main.netMode != 1)
										{
											npc.ai[1] += (float)Main.rand.Next(1, 4);
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
										float num1334 = (float)Main.rand.Next(-1000, 1001);
										float num1335 = (float)Main.rand.Next(-1000, 1001);
										float num1336 = (float)Math.Sqrt((double)(num1334 * num1334 + num1335 * num1335));
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
										if ((double)npc.life < (double)npc.lifeMax * 0.75)
										{
											num1338--;
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.5)
										{
											num1338 -= 2;
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.25)
										{
											num1338 -= 3;
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.1)
										{
											num1338 -= 4;
										}
										if (npc.ai[3] > (float)num1338)
										{
											npc.ai[3] = 0f;
											Projectile.NewProjectile(vector161.X, vector161.Y, num1334, num1335, mod.ProjectileType("PurplePulsePro"), 30, 0f, Main.myPlayer, 0f, 0f);
										}
										if (Main.netMode != 1)
										{
											npc.ai[1] += (float)Main.rand.Next(1, 4);
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
										npc.ai[0] = (float)num1339;
										npc.ai[1] = 0f;
										npc.ai[2] = 0f;
										npc.ai[3] = 0f;
										return;
									}

        }

    public override void NPCLoot()
    {
        if(Main.expertMode)
        {
            npc.DropBossBags();
        }
        if (Main.netMode != 1)
        {
            int CenterX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int CenterY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int halfLength = npc.width / 2 / 16 + 1;

        if(!Main.expertMode && Main.rand.Next(1) == 0)
        {
        Helper.DropItem(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Drop(mod.ItemType("RedStorm"), 1, 1), new Drop(mod.ItemType("ShockwaveClaymore"), 1, 1), new Drop(mod.ItemType("CyberCutter"), 1, 1)); 
        }
        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(6,25));
        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 500, Main.rand.Next(6,25));

        if(Main.rand.Next(10) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CyberKingTrophy"));
        }
        if(!Main.expertMode && Main.rand.Next(7) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CyberKingMask"));
        }
	    TremorWorld.downedCyberKing = true;
        }
    }
    }
}