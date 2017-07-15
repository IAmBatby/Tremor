using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class SoulofTrust : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Doom");
		}

		const int NormalShootRate = 142;
		const int NormalBulletDamage = 10;
		const float NormalBulletSpeed = 7.0f;
		const float NormalBulletKB = 1.0f;
		const int NormalShootType = 291;

		const int PowerBulletDamage = 20;
		const int PowerShootRate = 200;
		const float PowerBulletSpeed = 10.0f;
		const float PowerBulletKB = 2.0f;
		const int PowerShootType = 467;

		const int PowerTime = 300;
		const int BonusDefenseInPower = 5;
		const int BonusDamageInPower = 10;

		bool Power;
		bool OnlyPower;
		int TimeToShoot = NormalShootRate;
		int CurrentPower = PowerTime;
		int Step = -1;
		Color TextColor = Color.Orange;
		bool StateFlag = true;

		Random rnd = new Random();

		public override void SetDefaults()
		{
			npc.lifeMax = 100000;
			npc.damage = 134;
			npc.defense = 120;
			npc.knockBackResist = 0.0f;
			npc.width = 170;
			npc.height = 254;
			npc.aiStyle = 5;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath10;
			//npc.boss = true;
			npc.value = Item.buyPrice(0, 1, 0, 0);
			bossBag = mod.ItemType("TrinityBag2");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		bool RunAway;

		public override void AI()
		{
			npc.position += npc.velocity * 1.7f;
			if (Main.rand.Next(500) == 0 && Main.expertMode)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				npc.position.X = (Main.player[npc.target].position.X - 250) + Main.rand.Next(500);
				npc.position.Y = (Main.player[npc.target].position.Y - 250) + Main.rand.Next(500);
			}

			if (Main.rand.Next(500) == 0 && !Main.expertMode)
			{
				npc.TargetClosest(true);
				Vector2 vector142 = new Vector2(npc.Center.X, npc.Center.Y);
				float num1243 = Main.player[npc.target].Center.X - vector142.X;
				float num1244 = Main.player[npc.target].Center.Y - vector142.Y;
				float num1245 = (float)Math.Sqrt(num1243 * num1243 + num1244 * num1244);
				if (npc.ai[1] == 0f)
				{
					if (Main.netMode != 1)
					{
						npc.localAI[1] += 1f;
						if (npc.localAI[1] >= 120 + Main.rand.Next(200))
						{
							npc.localAI[1] = 0f;
							npc.TargetClosest(true);
							int num1249 = 0;
							int num1250;
							int num1251;
							while (true)
							{
								num1249++;
								num1250 = (int)Main.player[npc.target].Center.X / 16;
								num1251 = (int)Main.player[npc.target].Center.Y / 16;
								num1250 += Main.rand.Next(-50, 51);
								num1251 += Main.rand.Next(-50, 51);
								if (!WorldGen.SolidTile(num1250, num1251) && Collision.CanHit(new Vector2(num1250 * 16, num1251 * 16), 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
								{
									break;
								}
								if (num1249 > 100)
								{
									//return;
								}
							}
							npc.ai[1] = 1f;
							npc.ai[2] = num1250;
							npc.ai[3] = num1251;
							npc.netUpdate = true;
							//return;
						}
					}
				}
				else if (npc.ai[1] == 1f)
				{
					npc.alpha += 3;
					if (npc.alpha >= 255)
					{
						npc.alpha = 255;
						npc.position.X = npc.ai[2] * 16f - npc.width / 2;
						npc.position.Y = npc.ai[3] * 16f - npc.height / 2;
						npc.ai[1] = 2f;
						//return;
					}
				}
				else if (npc.ai[1] == 2f)
				{
					npc.alpha -= 3;
					if (npc.alpha <= 0)
					{
						npc.alpha = 0;
						npc.ai[1] = 0f;
						//return;
					}
				}
			}

			if (NPC.AnyNPCs(mod.NPCType("SoulofHope")) || NPC.AnyNPCs(mod.NPCType("SoulofTrust")))
			{
				npc.dontTakeDamage = true;
			}
			if (NPC.AnyNPCs(mod.NPCType("SoulofHope")) || NPC.AnyNPCs(mod.NPCType("SoulofTrust")))
			{
				npc.dontTakeDamage = false;
			}

			if (Main.expertMode && Main.rand.Next(4500) == 0)
			{
				NPC.NewNPC((int)npc.position.X - 100, (int)npc.position.Y - 50, 418);
				NPC.NewNPC((int)npc.position.X + 100, (int)npc.position.Y - 50, 418);
			}

			if (Main.rand.Next(2) == 0)
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 0.5f);
				Main.dust[num706].velocity *= 0.6f;
			}


			if (npc.target != -1 && !RunAway) //если(пнс.цель не варно -1 И не убегать)
				if (!Main.player[npc.target].active) //если (не мой.игрок[нпс.цель].активный)
				{
					if (Helper.GetNearestAlivePlayer(npc) == -1) //если (Помощьник.ПолучитьКоординатыИгрока(нпс) присвоить -1)
						RunAway = true; //Убегает = да
					else //или
					{
						if (Main.player[Helper.GetNearestAlivePlayer(npc)].Distance(npc.Center) > 2500f) //если(Мой.игрок[Помощьник.ПолучитьКоординатыИгрока(нпс)].Дистанция(нпс.Центр) больше 2500фунтов)
							RunAway = true; //Убегает = да
						else //или...
							npc.target = Helper.GetNearestAlivePlayer(npc); //нпс.цель равно Помощьник.ПолучитьКоординатыИгрока(нпс)
					}
				}
			if (Main.dayTime || RunAway || npc.localAI[3] == 1) //если(Мой.День или Убегать или нпс.местный ИИ 3 к 1)
			{
				npc.localAI[3] = 1; //нпс.местный ИИ[3] равен 3
				if (Main.npc[(int)npc.ai[2]].type == mod.NPCType("SoulofHope") && Main.npc[(int)npc.ai[2]].active) //если(Мой.нпс[(значение)нпс.ИИ[2]].тип равен мод.НПС Тип("МОБ") и Мой.нпс[(значение)нпс.ИИ[2]].активен равен да)
					Main.npc[(int)npc.ai[2]].localAI[3] = 1; //Мой.нпс[(значение)нпс.ИИ[2]].местный ИИ[3] варно 1
				if (Main.npc[(int)npc.ai[3]].type == mod.NPCType("SoulofTruth") && Main.npc[(int)npc.ai[3]].active) //если(Мой.нпс[(значение)нпс.ИИ[2]].тип равен мод.НПС Тип("МОБ") и Мой.нпс[(значение)нпс.ИИ[2]].активен равен да)
					Main.npc[(int)npc.ai[3]].localAI[3] = 1; //Мой.нпс[(значение)нпс.ИИ[2]].местный ИИ[3] варно 1
				npc.life += 11; //нпс.жизнь прибавить
				npc.aiStyle = 0; //нпс.ИИ Стиль - 0
				npc.rotation = 0;
				npc.velocity = Helper.VelocityFPTP(npc.Center, new Vector2(npc.Center.X, npc.Center.Y - 4815162342), 30.0f); //нпс.поворот = Помощьник.ПоворотФПТП(нпс.Центр, новый Вектор2(нпс.Центр.X, нпс.Центр.Y - 4815162342))
				CreateDust();
				return;
			}
			if (StateFlag)
				if (
					!((Main.npc[(int)npc.ai[2]].type == mod.NPCType("SoulofHope") && Main.npc[(int)npc.ai[2]].active)) ||
					!((Main.npc[(int)npc.ai[3]].type == mod.NPCType("SoulofTruth") && Main.npc[(int)npc.ai[3]].active))
				   )
				{
					StateFlag = false;
					OnlyPower = true;
				}
			if (OnlyPower)
				SetStage(true);
			else
			{
				CurrentPower += Step;
				if (CurrentPower <= 0 || CurrentPower >= PowerTime)
				{
					Step *= -1;
					SetStage(!Power);
				}
			}
			SetRotation();
			CreateDust();
			TimeToShoot--;
			if (TimeToShoot <= 0 && !Power)
			{
				TimeToShoot = NormalShootRate;
				Shoot();
				return;
			}
			if (TimeToShoot <= 0 && Power)
			{
				TimeToShoot = PowerShootRate;
				npc.target = Helper.GetNearestPlayer(npc);
				if (npc.target != -1)
				{
					for (int a = 0; a < 5; a++)
					{
						Vector2 velocity = Helper.VelocityFPTP(npc.Center, Main.player[npc.target].Center, PowerBulletSpeed);
						int spread = 65;
						float spreadMult = 0.05f;
						velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
						velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
						int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, PowerShootType, PowerBulletDamage, PowerBulletKB);
						Main.projectile[i].hostile = true;
						Main.projectile[i].friendly = true;
					}
				}
			}
		}

		void CreateDust()
		{
			if (rnd.Next(3) == 0)
				Dust.NewDust(npc.position, npc.width, npc.height, 6);
		}

		void SetRotation()
		{
			npc.rotation = 0;
		}

		void SetStage(bool stage)
		{
			if (Power == stage)
				return;
			Power = stage;
			if (Power)
			{
				npc.defense += BonusDefenseInPower;
				npc.damage += BonusDamageInPower;
			}
			else
			{
				npc.defense -= BonusDefenseInPower;
				npc.damage -= BonusDamageInPower;
			}
		}

		void Shoot()
		{
			npc.target = Helper.GetNearestPlayer(npc);
			if (npc.target != -1)
			{
				Vector2 velocity = Helper.VelocityFPTP(npc.Center, Main.player[npc.target].Center, NormalBulletSpeed);
				int spread = 95;
				float spreadMult = 0.075f;
				for (int l = 0; l < 2; l++)
				{
					velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
					velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
					int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, NormalShootType, NormalBulletDamage, NormalBulletKB);
					Main.projectile[i].hostile = true;
					Main.projectile[i].friendly = false;
				}
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TrustGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TrustGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TrustGore3"), 1f);

				if (!NPC.AnyNPCs(mod.NPCType("SoulofTruth")) && !NPC.AnyNPCs(mod.NPCType("SoulofHope")))
				{
					Main.NewText("The Trinity has been defeated!", 175, 75, 255);
				}
			}
		}

		public override void NPCLoot()
		{

			if (Main.expertMode && !NPC.AnyNPCs(mod.NPCType("SoulofTruth")) && !NPC.AnyNPCs(mod.NPCType("SoulofHope")))
			{
				npc.DropBossBags();
			}

			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;




				if (!NPC.AnyNPCs(mod.NPCType("SoulofHope")) && !NPC.AnyNPCs(mod.NPCType("SoulofTruth")))
				{

					if (!Main.expertMode && Main.rand.Next(10) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TrinityTrophy"));
					}

					if (!Main.expertMode && Main.rand.NextBool())
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OmnikronBar"), Main.rand.Next(9, 15));
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TrueEssense"), Main.rand.Next(10, 25));
					}

					if (!TremorWorld.downedTrinity)
					{
						Main.NewText("This world has been enlightened with Angelite!", 0, 191, 255);
						Main.NewText("This world has been attacked with Collapsium!", 255, 20, 147);

						for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
						{
							WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .65f)), WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(9, 15), mod.TileType("CollapsiumOreTile"), false, 0f, 0f, false, true);
						}
						for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
						{
							WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .65f)), WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(9, 15), mod.TileType("AngeliteOreTile"), false, 0f, 0f, false, true);
						}
						TremorWorld.downedTrinity = true;
					}

				}


				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrustMask"));
				}

				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Volcannon"));
				}

				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HonestBlade"));
				}

			}
		}
	}
}