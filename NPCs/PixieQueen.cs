using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class PixieQueen : ModNPC
	{
		#region "Константы"
		const int AnimationRate = 8; // Частота смены кадров (То, сколько кадров не будет сменятся кадр)
		const int FrameCount = 4; // Кол-во кадров

		const int ShootRate = 70; // Частота выстрела. Будет производить 60/ShootRate выстрелов в секунду
		const int ShootDamage = 15; // Урон от выстрела
		int ShootType = 100; // Тип выстрела (задаётся в SetDefaults())
		const float ShootKnockback = 1; // Отбрасование от выстрела
		const float ShootSpeed = 10; // Скорость выстрела

		const float DistortPercent = 0.15f; // Процент деформации статов (неточности) (1.0 == 100%)

		const int MinionsID = 61; // ID вуртулек
		const int MinionsCount = 4; // Кол-во вуртулек которых заспавнит

		const int StateTime_Flying = 600; // Сколько будет летать в воздухе до призыва миньонов
		const int StateTime_Minions = 120; // Сколько времени будет спавнить вуртулек

		const int FlyingAI = 2;
		const int MinionsAI = 0;

		const float MinionsState_XDeaccelerationPower = 0.05f; // Скорость замедления по X
		const float MinionsState_YMaxSpeed = 2.80f; // Макс. скорость взлёта во время спавна миньонов
		const float MinionsStete_YSpeedStep = 0.02f; // Скорость увеличения скорости по Y во время спавна миньонов

		const int States = 2;
		#endregion
		#region "Переменные"
		int TimeToAnimation = AnimationRate;
		int Frame = 0;
		bool Shoots = true;
		int TimeToShoot = ShootRate;
		int State = 0;
		int TimeToState = StateTime_Flying;
		bool runAway = false;
		#endregion

		int timer;
		int timer2;
		int timer3;
		int timer4;
		bool SpawnMinion = false;
		public static bool phase2;
		public static bool phase3;


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixie Queen");
			Main.npcFrameCount[npc.type] = 8;
		}


		public override void SetDefaults()
		{
			npc.aiStyle = 63;
			npc.lifeMax = 25000;
			npc.damage = 80;
			npc.defense = 35;
			npc.knockBackResist = 0f;
			//animationType = 75;
			npc.width = 122;
			npc.height = 122;
			npc.value = Item.buyPrice(0, 10, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.buffImmune[24] = true;
			music = 12;
			bossBag = mod.ItemType("PixieQueenBag");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void AI()
		{
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = 50;
				timer = 0;
				timer2 = 0;
				timer3 = 0;
				timer4 = 0;
			}
			timer++;
			if (timer <= 1000)
			{
				timer2++;
			}
			if (timer <= 1000)
			{
				timer3++;
			}
			if (timer >= 1000)
			{
				timer4++;
			}
			if (timer == 1500)
			{
				timer = 0;
			}
			if (timer >= 200 && timer <= 650)
			{
				Shoot();
				npc.position += npc.velocity * 1.2f;
			}
			if (timer >= 650 && timer <= 1000)
			{
				Shoot();
				int currentLifeP2 = npc.lifeMax * (2 / 3);
				int currentLifeP3 = npc.lifeMax * (1 / 3);
				if (npc.life <= currentLifeP2)
				{
					phase2 = true;
				}
				if (npc.life <= currentLifeP3)
				{
					phase3 = true;
				}
				if (Main.rand.Next(300) == 0)
				{
					Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 35);
				}
				//Player player = Main.player[npc.target];
				bool playerWet = player.wet;
				//Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0f, 0.25f, 0.15f);
				int num1038 = 0;
				for (int num1039 = 0; num1039 < 255; num1039++)
				{
					if (Main.player[num1039].active && !Main.player[num1039].dead && (npc.Center - Main.player[num1039].Center).Length() < 1000f)
					{
						num1038++;
					}
				}
				if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
				{
					npc.TargetClosest(true);
				}
				if (Main.player[npc.target].dead)
				{
					npc.TargetClosest(false);
					npc.velocity.Y = npc.velocity.Y + 1f;
					if (npc.position.Y > Main.worldSurface * 16.0)
					{
						npc.velocity.Y = npc.velocity.Y + 1f;
					}
					if (npc.position.Y > Main.rockLayer * 16.0)
					{
						for (int num957 = 0; num957 < 200; num957++)
						{
							if (Main.npc[num957].aiStyle == npc.aiStyle)
							{
								Main.npc[num957].active = false;
							}
						}
					}
				}
				else if (npc.ai[0] == -1f)
				{
					if (Main.netMode != 1)
					{
						float num1041 = npc.ai[1];
						int num1042;
						do
						{
							num1042 = Main.rand.Next(3);
							if (num1042 == 1)
							{
								num1042 = 2;
							}
							else if (num1042 == 2)
							{
								num1042 = 3;
							}
						}
						while (num1042 == num1041);
						npc.ai[0] = num1042;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						return;
					}
				}
				else if (npc.ai[0] == 0f)
				{
					int num1043 = 2; //2 not a prob
					if (npc.life < npc.lifeMax / 2)
					{
						num1043++;
					}
					if (npc.life < npc.lifeMax / 3)
					{
						num1043++;
					}
					if (npc.life < npc.lifeMax / 5)
					{
						num1043++;
					}
					if (npc.ai[1] > 2 * num1043 && npc.ai[1] % 2f == 0f)
					{
						npc.ai[0] = -1f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.netUpdate = true;
						return;
					}
					if (npc.ai[1] % 2f == 0f)
					{
						npc.TargetClosest(true);
						if (Math.Abs(npc.position.Y + npc.height / 2 - (Main.player[npc.target].position.Y + Main.player[npc.target].height / 2)) < 20f)
						{
							npc.localAI[0] = 1f;
							npc.ai[1] += 1f;
							npc.ai[2] = 0f;
							float num1044 = 16f; //16
							if (npc.life < npc.lifeMax * 0.75)
							{
								num1044 += 2f; //2 not a prob
							}
							if (npc.life < npc.lifeMax * 0.5)
							{
								num1044 += 2f; //2 not a prob
							}
							if (npc.life < npc.lifeMax * 0.25)
							{
								num1044 += 2f; //2 not a prob
							}
							if (npc.life < npc.lifeMax * 0.1)
							{
								num1044 += 2f; //2 not a prob
							}
							Vector2 vector117 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
							float num1045 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector117.X;
							float num1046 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector117.Y;
							float num1047 = (float)Math.Sqrt(num1045 * num1045 + num1046 * num1046);
							num1047 = num1044 / num1047;
							npc.velocity.X = num1045 * num1047;
							npc.velocity.Y = num1046 * num1047;
							npc.spriteDirection = npc.direction;
							Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 34);
							return;
						}
						npc.localAI[0] = 0f;
						float num1048 = 12f; //12 not a prob
						float num1049 = 0.15f; //0.15 not a prob
						if (npc.life < npc.lifeMax * 0.75)
						{
							num1048 += 1f; //1 not a prob
							num1049 += 0.05f; //0.05 not a prob
						}
						if (npc.life < npc.lifeMax * 0.5)
						{
							num1048 += 1f; //1 not a prob
							num1049 += 0.05f; //0.05 not a prob
						}
						if (npc.life < npc.lifeMax * 0.25)
						{
							num1048 += 2f; //2 not a prob
							num1049 += 0.05f; //0.05 not a prob
						}
						if (npc.life < npc.lifeMax * 0.1)
						{
							num1048 += 2f; //2 not a prob
							num1049 += 0.1f; //0.1 not a prob
						}
						if (npc.position.Y + npc.height / 2 < Main.player[npc.target].position.Y + Main.player[npc.target].height / 2)
						{
							npc.velocity.Y = npc.velocity.Y + num1049;
						}
						else
						{
							npc.velocity.Y = npc.velocity.Y - num1049;
						}
						if (npc.velocity.Y < -12f)
						{
							npc.velocity.Y = -num1048;
						}
						if (npc.velocity.Y > 12f)
						{
							npc.velocity.Y = num1048;
						}
						if (Math.Abs(npc.position.X + npc.width / 2 - (Main.player[npc.target].position.X + Main.player[npc.target].width / 2)) > 600f)
						{
							npc.velocity.X = npc.velocity.X + 0.15f * npc.direction;
						}
						else if (Math.Abs(npc.position.X + npc.width / 2 - (Main.player[npc.target].position.X + Main.player[npc.target].width / 2)) < 300f)
						{
							npc.velocity.X = npc.velocity.X - 0.15f * npc.direction;
						}
						else
						{
							npc.velocity.X = npc.velocity.X * 0.8f;
						}
						if (npc.velocity.X < -16f)
						{
							npc.velocity.X = -16f;
						}
						if (npc.velocity.X > 16f)
						{
							npc.velocity.X = 16f;
						}
						npc.spriteDirection = npc.direction;
						return;
					}
					if (npc.velocity.X < 0f)
					{
						npc.direction = -1;
					}
					else
					{
						npc.direction = 1;
					}
					npc.spriteDirection = npc.direction;
					int num1050 = 600; //600 not a prob
					if (!playerWet)
					{
						num1050 = 350;
					}
					else
					{
						num1050 = 600;
						if (npc.life < npc.lifeMax * 0.1)
						{
							num1050 = 800; //300 not a prob
						}
						else if (npc.life < npc.lifeMax * 0.25)
						{
							num1050 = 750; //450 not a prob
						}
						else if (npc.life < npc.lifeMax * 0.5)
						{
							num1050 = 700; //500 not a prob
						}
						else if (npc.life < npc.lifeMax * 0.75)
						{
							num1050 = 650; //550 not a prob
						}
					}
					int num1051 = 1;
					if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width / 2)
					{
						num1051 = -1;
					}
					if (npc.direction == num1051 && Math.Abs(npc.position.X + npc.width / 2 - (Main.player[npc.target].position.X + Main.player[npc.target].width / 2)) > num1050)
					{
						npc.ai[2] = 1f;
					}
					if (npc.ai[2] != 1f)
					{
						npc.localAI[0] = 1f;
						return;
					}
					npc.TargetClosest(true);
					npc.spriteDirection = npc.direction;
					npc.localAI[0] = 0f;
					npc.velocity *= 0.9f;
					float num1052 = 0.1f; //0.1
					if (npc.life < npc.lifeMax / 2)
					{
						npc.velocity *= 0.9f;
						num1052 += 0.05f; //0.05
					}
					if (npc.life < npc.lifeMax / 3)
					{
						npc.velocity *= 0.9f;
						num1052 += 0.05f; //0.05
					}
					if (npc.life < npc.lifeMax / 5)
					{
						npc.velocity *= 0.9f;
						num1052 += 0.05f; //0.05
					}
					if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num1052)
					{
						npc.ai[2] = 0f;
						npc.ai[1] += 1f;
						return;
					}
				}
				else if (npc.ai[0] == 2f)
				{
					npc.TargetClosest(true);
					npc.spriteDirection = npc.direction;
					float num1053 = 12f; //12 found one!  dictates speed during bee spawn
					float num1054 = 0.1f; //0.1 found one!  dictates speed during bee spawn
					Vector2 vector118 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
					float num1055 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector118.X;
					float num1056 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - 200f - vector118.Y;
					float num1057 = (float)Math.Sqrt(num1055 * num1055 + num1056 * num1056);
					if (num1057 < 800f)
					{
						npc.ai[0] = 1f;
						npc.ai[1] = 0f;
						npc.netUpdate = true;
						return;
					}
					num1057 = num1053 / num1057;
					if (npc.velocity.X < num1055)
					{
						npc.velocity.X = npc.velocity.X + num1054;
						if (npc.velocity.X < 0f && num1055 > 0f)
						{
							npc.velocity.X = npc.velocity.X + num1054;
						}
					}
					else if (npc.velocity.X > num1055)
					{
						npc.velocity.X = npc.velocity.X - num1054;
						if (npc.velocity.X > 0f && num1055 < 0f)
						{
							npc.velocity.X = npc.velocity.X - num1054;
						}
					}
					if (npc.velocity.Y < num1056)
					{
						npc.velocity.Y = npc.velocity.Y + num1054;
						if (npc.velocity.Y < 0f && num1056 > 0f)
						{
							npc.velocity.Y = npc.velocity.Y + num1054;
							return;
						}
					}
					else if (npc.velocity.Y > num1056)
					{
						npc.velocity.Y = npc.velocity.Y - num1054;
						if (npc.velocity.Y > 0f && num1056 < 0f)
						{
							npc.velocity.Y = npc.velocity.Y - num1054;
							return;
						}
					}
				}
				else if (npc.ai[0] == 1f)
				{
					npc.localAI[0] = 0f;
					npc.TargetClosest(true);
					Vector2 vector119 = new Vector2(npc.position.X + npc.width / 2 + Main.rand.Next(20) * npc.direction, npc.position.Y + npc.height * 0.8f);
					Vector2 vector120 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
					float num1058 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector120.X;
					float num1059 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector120.Y;
					float num1060 = (float)Math.Sqrt(num1058 * num1058 + num1059 * num1059);
					npc.ai[1] += 1f;
					npc.ai[1] += num1038 / 2;
					if (npc.life < npc.lifeMax * 0.75)
					{
						npc.ai[1] += 0.25f; //0.25 not a prob
					}
					if (npc.life < npc.lifeMax * 0.5)
					{
						npc.ai[1] += 0.25f; //0.25 not a prob
					}
					if (npc.life < npc.lifeMax * 0.25)
					{
						npc.ai[1] += 0.25f; //0.25 not a prob
					}
					if (npc.life < npc.lifeMax * 0.1)
					{
						npc.ai[1] += 0.25f; //0.25 not a prob
					}
					bool flag103 = false;
					if (npc.ai[1] > 40f) //changed from 40 not a prob
					{
						npc.ai[1] = 0f;
						npc.ai[2] += 1f;
						flag103 = true;
					}
					if (Collision.CanHit(vector119, 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height) && flag103)
					{
						Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 25);
						if (Main.netMode != 1)
						{
							int num1061;
							if (Main.rand.Next(4) == 0)
							{
								num1061 = mod.NPCType("AquaticAberration"); //Aquatic entity spawns
							}
							else
							{
								num1061 = mod.NPCType("Parasea");
							}
							int num1062 = NPC.NewNPC((int)vector119.X, (int)vector119.Y, num1061, 0, 0f, 0f, 0f, 0f, 255);
							Main.npc[num1062].velocity.X = Main.rand.Next(-200, 201) * 0.01f;
							Main.npc[num1062].velocity.Y = Main.rand.Next(-200, 201) * 0.01f;
							Main.npc[num1062].localAI[0] = 60f;
							Main.npc[num1062].netUpdate = true;
						}
					}
					if (num1060 > 400f || !Collision.CanHit(new Vector2(vector119.X, vector119.Y - 30f), 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
					{
						float num1063 = 14f; //changed from 14 not a prob
						float num1064 = 0.1f; //changed from 0.1 not a prob
						vector120 = vector119;
						num1058 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector120.X;
						num1059 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector120.Y;
						num1060 = (float)Math.Sqrt(num1058 * num1058 + num1059 * num1059);
						num1060 = num1063 / num1060;
						if (npc.velocity.X < num1058)
						{
							npc.velocity.X = npc.velocity.X + num1064;
							if (npc.velocity.X < 0f && num1058 > 0f)
							{
								npc.velocity.X = npc.velocity.X + num1064;
							}
						}
						else if (npc.velocity.X > num1058)
						{
							npc.velocity.X = npc.velocity.X - num1064;
							if (npc.velocity.X > 0f && num1058 < 0f)
							{
								npc.velocity.X = npc.velocity.X - num1064;
							}
						}
						if (npc.velocity.Y < num1059)
						{
							npc.velocity.Y = npc.velocity.Y + num1064;
							if (npc.velocity.Y < 0f && num1059 > 0f)
							{
								npc.velocity.Y = npc.velocity.Y + num1064;
							}
						}
						else if (npc.velocity.Y > num1059)
						{
							npc.velocity.Y = npc.velocity.Y - num1064;
							if (npc.velocity.Y > 0f && num1059 < 0f)
							{
								npc.velocity.Y = npc.velocity.Y - num1064;
							}
						}
					}
					else
					{
						npc.velocity *= 0.9f;
					}
					npc.spriteDirection = npc.direction;
					if (npc.ai[2] > 3f)
					{
						npc.ai[0] = -1f;
						npc.ai[1] = 1f;
						npc.netUpdate = true;
						return;
					}
				}
			}
			if (timer >= 1000 && timer <= 1250)
			{
				Shoot();
				npc.ai[0]++;
				if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
				{
					npc.TargetClosest(true);
				}
				npc.netUpdate = true;
				npc.ai[1]++;
				if (npc.ai[1] >= 100 && npc.ai[1] < 200)
				{
					if (Main.rand.Next(10) == 0)
					{
						npc.velocity.X *= 5.00f;
						npc.velocity.Y *= 5.00f;
						Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
						{
							float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
							npc.velocity.X = (float)(Math.Cos(rotation) * 12) * -1;
							npc.velocity.Y = (float)(Math.Sin(rotation) * 12) * -1;
						}
						return;
					}
				}
				if (npc.ai[1] >= 280 && npc.ai[1] < 320)
				{
					if (Main.rand.Next(5) == 0)
					{
						npc.velocity.X *= 10.00f;
						npc.velocity.Y *= 10.00f;
						Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
						{
							float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
							npc.velocity.X = (float)(Math.Cos(rotation) * 12) * -1;
							npc.velocity.Y = (float)(Math.Sin(rotation) * 12) * -1;
						}
						return;
					}
				}
				if (npc.ai[1] >= 450)
				{
					npc.ai[1] = 0;
				}
			}
			if (timer >= 1250)
			{
				npc.velocity.Y = 0;
				npc.velocity.X = 0;
				npc.rotation = 0f;
				if (Main.rand.Next(70) == 0)
				{
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("PixieQueenGuardian"));
				}
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool())
			{
				player.AddBuff(BuffID.Confused, 60, true);
			}

			if (Main.rand.NextBool())
			{
				player.AddBuff(BuffID.Slow, 60, true);
			}

			if (Main.rand.Next(3) == 0)
			{
				player.AddBuff(BuffID.Cursed, 60, true);
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/PixieQueenGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/PixieQueenGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/PixieQueenGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/PixieQueenGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("NPCs/PixieQueenGore5"), 1f);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			int frameWidth = 122;
			npc.spriteDirection = npc.direction;

			//Здесь делается процесс:
			npc.frameCounter++;
			if (npc.frameCounter >= 4)
			{
				if (timer > 200 && timer < 1250)
				{
					npc.frame.Y += 122;
					if (npc.frame.Y >= 976)
					{
						npc.frame.Y = 0;
						npc.frame.X = (npc.frame.X + (frameWidth * 2)) % (3 * frameWidth);
					}
				}
				if (timer <= 200)
				{
					npc.frame.Y += 122;
					if (npc.frame.Y >= 976)
					{
						npc.frame.Y = 0;
						npc.frame.X = 0;
					}
				}
				if (timer >= 1250)
				{
					npc.frame.Y += 122;
					if (npc.frame.Y >= 976)
					{
						npc.frame.Y = 0;
						npc.frame.X = (npc.frame.X + frameWidth) % (2 * frameWidth);
						///SpawnMinion = false;
					}
				}
				npc.frameCounter = 0;
			}
			npc.frame.Width = frameWidth;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
			npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
			npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, 0f, origin, npc.scale, effects, 0);

			return false;
		}

		void Shoot()
		{
			if (!Shoots && npc.target < 0) //если не время для не стрельбы, то вырубаем автоматом
				return;
			if (--TimeToShoot > 0) //если таймер меньше нуля, то вырубаем автоматом
				return;
			TimeToShoot = (int)Helper.DistortFloat(ShootRate, DistortPercent); //устанавливаем частоту выстрела
			for (int i = 0; i < ((Main.expertMode) ? 4 : 2); i++) //в цикле указываем кол-во перьев при выстреле
			{
				Player player = Main.player[Main.myPlayer];
				Vector2 position1 = player.Center;
				Vector2 vector2 = new Vector2(player.position.X + 75f * (float)Math.Cos(12), player.position.Y + 1075f * (float)Math.Sin(12));
				Vector2 Velocity = Helper.VelocityToPoint(vector2, Helper.RandomPointInArea(new Vector2(Main.player[npc.target].Center.X - 10, Main.player[npc.target].Center.Y - 10), new Vector2(Main.player[npc.target].Center.X + 20, Main.player[npc.target].Center.Y + 20)), ShootSpeed); //здесь устанавливаем позиции (здесь от перса в плеера)
				int Proj = Projectile.NewProjectile(vector2.X, vector2.Y, Velocity.X, Velocity.Y, 671, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent)); //подтверждаем все выше действие: от перса к мобу, от моба к персу (второе выстрел)
																																																					//Main.projectile[Proj].Center = npc.Center;
				Main.projectile[Proj].friendly = false;
				Main.projectile[Proj].damage = npc.damage;
			}
		}

		public static Vector2 VelocityToPoint2(Vector2 A, Vector2 B, float Speed)
		{
			Vector2 Move = (B - A);
			return Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
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
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PixieQueenMask"));
				}
				if (!Main.expertMode && Main.rand.Next(6) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EtherealFeather"));
				}
				if (!Main.expertMode && Main.rand.Next(6) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PixiePulse"));
				}
				if (!Main.expertMode && Main.rand.Next(6) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HeartMagnet"));
				}
				if (!Main.expertMode && Main.rand.Next(6) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DopelgangerCandle"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PixieQueenTrophy"));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosBar"), Main.rand.Next(25, 30));
				}
				TremorWorld.downedBoss[TremorWorld.Boss.PixieQueen] = true;
			}
		}
	}
}