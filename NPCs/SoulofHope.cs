using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class SoulofHope : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Hope");
		}

		const int NormalShootRate = 60;
		const int NormalLaserDamage = 10;
		const float NormalLaserKB = 1.0f;
		const float NormalLaserSpeed = 15.0f;
		const int NormalAiStyle = 2;

		const int PowerShootRate = 80;
		const int PowerLaserDamage = 24;
		const float PowerLaserKB = 2.0f;
		const float PowerLaserSpeed = 10.0f;
		const int PowerAiStyle = 5;

		const float DistantionToPower = 300f;
		const int BonusDefenseInPower = 5;
		const int BonusDamageInPower = 10;
		const int ShootType = 435;
		const float RotationSpeed = 0.3f;

		bool Power;
		bool OnlyPower;
		int TimeToShoot = NormalShootRate;
		float Rotation;
		Color TextColor = Color.Orange;
		bool StateFlag = true;

		Random rnd = new Random();

		public override void SetDefaults()
		{
			npc.lifeMax = 75000;
			npc.damage = 37;
			npc.defense = 150;
			npc.knockBackResist = 0.0f;
			npc.width = 200;
			npc.height = 194;
			npc.aiStyle = 5;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath10;
			//npc.boss = true;
			npc.value = Item.buyPrice(0, 1, 0, 0);
			bossBag = mod.ItemType("TrinityBag3");
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
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 5);
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

			if (Main.rand.Next(2500) == 0)
			{
				NPC.NewNPC((int)npc.position.X - 150, (int)npc.position.Y - 50, 420);
				NPC.NewNPC((int)npc.position.X + 150, (int)npc.position.Y - 50, 420);
			}

			if (npc.target != -1 && !RunAway)
				if (!Main.player[npc.target].active)
				{
					if (Helper.GetNearestAlivePlayer(npc) == -1)
						RunAway = true;
					else
					{
						if (Main.player[Helper.GetNearestAlivePlayer(npc)].Distance(npc.Center) > 2500f)
							RunAway = true;
						else
							npc.target = Helper.GetNearestAlivePlayer(npc);
					}
				}
			if (Main.dayTime || RunAway || npc.localAI[3] == 1)
			{
				npc.localAI[3] = 1;
				if (Main.npc[(int)npc.ai[2]].type == mod.NPCType("SoulofTrust") && Main.npc[(int)npc.ai[2]].active)
					Main.npc[(int)npc.ai[2]].localAI[3] = 1;
				if (Main.npc[(int)npc.ai[3]].type == mod.NPCType("SoulofTruth") && Main.npc[(int)npc.ai[3]].active)
					Main.npc[(int)npc.ai[3]].localAI[3] = 1;
				npc.life += 11;
				npc.aiStyle = 0;
				npc.rotation = 0;
				npc.velocity = Helper.VelocityFPTP(npc.Center, new Vector2(npc.Center.X, npc.Center.Y - 4815162342), 30.0f);
				CreateDust();
				return;
			}
			if (StateFlag)
				if (
					!((Main.npc[(int)npc.ai[2]].type == mod.NPCType("SoulofTrust") && Main.npc[(int)npc.ai[2]].active)) ||
					!((Main.npc[(int)npc.ai[3]].type == mod.NPCType("SoulofTruth") && Main.npc[(int)npc.ai[3]].active))
				   )
				{
					StateFlag = false;
					OnlyPower = true;
				}
			if (OnlyPower)
				SetStage(true);
			else
				SetStage(Main.player[Helper.GetNearestPlayer(npc)].Distance(npc.Center) <= DistantionToPower);
			SetRotation();
			CreateDust();
			TimeToShoot--;
			if (TimeToShoot <= 0)
			{
				TimeToShoot = (Power) ? PowerShootRate : NormalShootRate;
				Shoot();
			}
		}

		void CreateDust()
		{
			if (rnd.Next(3) == 0)
				Dust.NewDust(npc.position, npc.width, npc.height, 62);
		}

		void SetRotation()
		{
			if (Power)
			{
				Rotation += RotationSpeed;
				npc.rotation = Rotation;
			}
			else
			{
				while (Rotation - 36.0f >= 0.0f)
					Rotation -= 36.0f;
				if (Rotation != 0.0f)
				{
					Rotation -= (RotationSpeed * 2.0f);
					Vector2 velocity = Helper.VelocityFPTP(npc.Center, Helper.RandomPosition(new Vector2(npc.Center.X - 250, npc.Center.Y - 250), new Vector2(npc.Center.X + 250, npc.Center.Y + 250)), PowerLaserSpeed);
					int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, PowerLaserDamage, PowerLaserKB);
					Main.projectile[i].tileCollide = false;
				}
				if (Rotation < 0.0f)
					Rotation = 0.0f;
				npc.rotation = Rotation;
			}
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
				npc.aiStyle = PowerAiStyle;
			}
			else
			{
				npc.defense -= BonusDefenseInPower;
				npc.damage -= BonusDamageInPower;
				npc.aiStyle = NormalAiStyle;
			}
		}

		void Shoot()
		{
			if (Helper.GetNearestPlayer(npc) != -1)
			{
				npc.target = Helper.GetNearestPlayer(npc);
				Vector2 velocity = Helper.VelocityFPTP(npc.Center, Main.player[npc.target].Center, (Power) ? PowerLaserSpeed : NormalLaserSpeed);
				int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, (Power) ? PowerLaserDamage : NormalLaserDamage, (Power) ? PowerLaserKB : NormalLaserKB);
				Main.projectile[i].tileCollide = false;
				Main.projectile[i].friendly = false;
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HopeGore3"), 1f);
				if (!NPC.AnyNPCs(mod.NPCType("SoulofTruth")) && !NPC.AnyNPCs(mod.NPCType("SoulofTrust")))
				{
					Main.NewText("The Trinity has been defeated!", 175, 75, 255);
				}
			}
		}

		public override void NPCLoot()
		{

			if (Main.expertMode && !NPC.AnyNPCs(mod.NPCType("SoulofTruth")) && !NPC.AnyNPCs(mod.NPCType("SoulofTrust")))
			{
				npc.DropBossBags();
			}

			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;




				if (!NPC.AnyNPCs(mod.NPCType("SoulofTruth")) && !NPC.AnyNPCs(mod.NPCType("SoulofTrust")))
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

					if (!TremorWorld.Boss.Trinity.IsDowned())
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
						TremorWorld.Boss.Trinity.Downed();
					}

				}


				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HopeMask"));
				}

				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Banhammer"));
				}

				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BestNightmare"));
				}

			}
		}
	}
}