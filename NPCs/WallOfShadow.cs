using Terraria.ID;
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

// Main.wofB = Wall of Flesh bottom
// Main.wofT = Wall of flesh Top

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class WallOfShadow : ModNPC
	{
		#region "Константы"
		const int AnimationRate = 8; // Частота смены кадров (То, сколько кадров не будет сменятся кадр)
		const int FrameCount = 4; // Кол-во кадров

		const int ShootRate = 70; // Частота выстрела. Будет производить 60/ShootRate выстрелов в секунду
		const int ShootDamage = 15; // Урон от выстрела
		int ShootType; // Тип выстрела (задаётся в SetDefaults())
		const float ShootKnockback = 1; // Отбрасование от выстрела
		float ShootSpeed = 20; // Скорость выстрела

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

		int MagicBoltCooldown
		{
			get { return (int)npc.ai[2]; }
			set { npc.ai[2] = value; }
		}

		int LaserCooldown
		{
			get { return (int)npc.ai[0]; }
			set { npc.ai[0] = value; }
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Shadows");
		}


		public override void SetDefaults()
		{
			npc.width = 100;
			npc.height = 100;
			npc.value = Item.buyPrice(0, 17, 0, 0);
			npc.damage = 64;
			npc.defense = 57;
			npc.lifeMax = 36000;
			npc.knockBackResist = 0f;
			npc.npcSlots = 10;
			npc.boss = true;
			npc.scale = 1.2f;
			npc.noGravity = true;
			npc.lavaImmune = true;
			npc.behindTiles = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit8;
			npc.DeathSound = SoundID.NPCDeath10;
			music = MusicID.Boss4;
			Main.npcFrameCount[npc.type] = 2;
			bossBag = mod.ItemType("WallofShadowBag");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			if (Main.expertMode)
				target.AddBuff(153, 240);
		}

		void ShootBall()
		{
			MagicBoltCooldown--;
			if (MagicBoltCooldown <= 60 && MagicBoltCooldown % ((Main.expertMode) ? 12 : 20) == 0 && Main.netMode != 1)
			{
				var targetPos = npc.HasPlayerTarget ? Main.player[npc.target].Center : Main.npc[npc.target].Center;
				var shootPos = (npc.Top + new Vector2(0, 60)).RotatedBy(npc.rotation, npc.Center);
				float inaccuracy = 3f * (npc.life / npc.lifeMax);
				var shootVel = targetPos - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
				shootVel.Normalize();
				shootVel *= 10f;
				int proj = Projectile.NewProjectile(shootPos, shootVel, 290, npc.damage, 5f, Main.myPlayer);
			}
			if (MagicBoltCooldown <= 0)
			{
				MagicBoltCooldown = 100 + (int)(60 * (float)npc.life / npc.lifeMax);
			}
		}

		void Shoot()
		{
			if (!Shoots && npc.target < 0) //если не время для не стрельбы, то вырубаем автоматом
				return;
			if (--TimeToShoot > 0) //если таймер меньше нуля, то вырубаем автоматом
				return;
			TimeToShoot = (int)Helper.DistortFloat(ShootRate, DistortPercent); //устанавливаем частоту выстрела
			for (int i = 0; i < ((Main.expertMode) ? 3 : 1); i++) //в цикле указываем кол-во перьев при выстреле
			{
				if (Main.expertMode)
				{
					ShootSpeed = 25;
				}
				Vector2 Velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(new Vector2(Main.player[npc.target].Center.X - 10, Main.player[npc.target].Center.Y - 10), new Vector2(Main.player[npc.target].Center.X + 20, Main.player[npc.target].Center.Y + 20)), ShootSpeed); //здесь устанавливаем позиции (здесь от перса в плеера)
				int Proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, 83, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent)); //подтверждаем все выше действие: от перса к мобу, от моба к персу (второе выстрел)
				Main.projectile[Proj].Center = npc.Center;
			}
		}

		void ShootSuper()
		{
			LaserCooldown--;
			if (LaserCooldown <= 60 && LaserCooldown % ((Main.expertMode) ? 4 : 7) == 0 && Main.netMode != 1)
			{
				Vector2 Velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(new Vector2(Main.player[npc.target].Center.X - 100, Main.player[npc.target].Center.Y - 100), new Vector2(Main.player[npc.target].Center.X + 20, Main.player[npc.target].Center.Y + 20)), ((Main.expertMode) ? 20 : 15)); //здесь устанавливаем позиции (здесь от перса в плеера)
				int Proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, 83, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent)); //подтверждаем все выше действие: от перса к мобу, от моба к персу (второе выстрел)
				Main.projectile[Proj].Center = npc.Center;
			}
			if (LaserCooldown <= 0)
			{
				LaserCooldown = 100 + (int)(600 * (float)npc.life / npc.lifeMax);
			}
		}

		public override bool PreAI()
		{
			Player player = Main.player[npc.target];
			npc.position.Y = player.position.Y;
			player.AddBuff(22, 1);
			if (player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = npc.velocity.Y + 1f;
				if ((double)npc.position.Y > Main.worldSurface * 16.0)
				{
					npc.velocity.Y = npc.velocity.Y + 1f;
				}
				if ((double)npc.position.Y > Main.rockLayer * 16.0)
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

			ShootBall();
			ShootSuper();
			if (npc.life < npc.lifeMax * 0.5f)
			{
				Main.npcHeadBossTexture[NPCID.Sets.BossHeadTextures[npc.type]] = mod.GetTexture("NPCs/WallOfShadow_Head_Boss1");
				Shoot();

				if ((int)(Main.time % 360) == 0)
				{
					int index = NPC.NewNPC((int)(npc.position.X + (npc.width / 2)), (int)(npc.position.Y + (npc.height / 2) + 20.0), mod.NPCType("ShadowSteed"), 1, 0.0f, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
					Main.npc[index].velocity.X = npc.direction * 6;
				}

				if (npc.localAI[0] == 0.0)
				{
					npc.localAI[0] = 1f;
					Main.wofB = -1;
					Main.wofT = -1;
				}

				npc.ai[1]++;
				if (npc.ai[2] == 0)
				{
					if (npc.life < npc.lifeMax * 0.5F)
						npc.ai[1]++;
					if (npc.life < npc.lifeMax * 0.2F)
						npc.ai[1]++;
					if (npc.ai[1] > 2700.0)
						npc.ai[2] = 1f;
				}
				if (npc.ai[2] > 0 && npc.ai[1] > 60)
				{
					int spawnCooldown = 3;
					if (npc.life < npc.lifeMax * 0.3)
						++spawnCooldown;
					npc.ai[2]++;
					npc.ai[1] = 0;
					if (npc.ai[2] > spawnCooldown)
						npc.ai[2] = 0;

					if (Main.netMode != 1)
					{
						// Spawn... a Shadow Steed?
						//int index = NPC.NewNPC((int)(npc.position.X + (npc.width / 2)), (int)(npc.position.Y + (npc.height / 2) + 20.0), mod.NPCType("ShadowSteed"), 1, 0.0f, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
						//int index2 = NPC.NewNPC((int)(npc.position.X + (npc.width / 2)), (int)(npc.position.Y + (npc.height / 2) + 20.0), mod.NPCType("ShadowSteed"), 1, 0.0f, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
						//NPC.NewNPC((int)(npc.position.X + (npc.width / 2)), (int)(npc.position.Y + (npc.height / 2) + 10.0), mod.NPCType("ShadowSteed"), 1, 0.0f, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
						//NPC.NewNPC((int)(npc.position.X + (npc.width / 2)), (int)(npc.position.Y + (npc.height / 2) + 30.0), mod.NPCType("ShadowSteed"), 1, 0.0f, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
						//Main.npc[index].velocity.X = npc.direction * 6;
						//Main.npc[index2].velocity.X = npc.direction * 6;
					}
				}



				Main.wof = npc.whoAmI;
				int npcTileX = (int)(npc.position.X / 16);
				int npcRightXTile = (int)((npc.position.X + npc.width) / 16);
				int npcCenterYTile = (int)((npc.position.Y + (npc.height / 2)) / 16);
				int solidTiles = 0;
				int npcBottom = npcCenterYTile + 7;
				while (solidTiles < 15 && npcBottom > Main.maxTilesY - 200)
				{
					++npcBottom;
					for (int i = npcTileX; i <= npcRightXTile; ++i)
					{
						try
						{
							if (!WorldGen.SolidTile(i, npcBottom))
							{
								if ((int)Main.tile[i, npcBottom].liquid <= 0)
									continue;
							}
							++solidTiles;
						}
						catch
						{
							solidTiles += 15;
						}
					}
				}
				int num5 = npcBottom + 4;
				if (Main.wofB == -1)
					Main.wofB = num5 * 16;
				else if (Main.wofB > num5 * 16)
				{
					--Main.wofB;
					if (Main.wofB < num5 * 16)
						Main.wofB = num5 * 16;
				}
				else if (Main.wofB < num5 * 16)
				{
					++Main.wofB;
					if (Main.wofB > num5 * 16)
						Main.wofB = num5 * 16;
				}

				int num6 = 0;
				int j2 = npcCenterYTile - 7;
				while (num6 < 15 && j2 < Main.maxTilesY - 10)
				{
					--j2;
					for (int i = npcTileX; i <= npcRightXTile; ++i)
					{
						try
						{
							if (!WorldGen.SolidTile(i, j2))
							{
								if ((int)Main.tile[i, j2].liquid <= 0)
									continue;
							}
							++num6;
						}
						catch
						{
							num6 += 15;
						}
					}
				}
				int num7 = j2 - 4;
				if (Main.wofT == -1)
					Main.wofT = num7 * 16;
				else if (Main.wofT > num7 * 16)
				{
					--Main.wofT;
					if (Main.wofT < num7 * 16)
						Main.wofT = num7 * 16;
				}
				else if (Main.wofT < num7 * 16)
				{
					++Main.wofT;
					if (Main.wofT > num7 * 16)
						Main.wofT = num7 * 16;
				}

				#region Movement
				float num8 = ((Main.wofB + Main.wofT) / 2 - npc.height / 2);
				if (npc.position.Y > num8 + 1.0)
					npc.velocity.Y = -1f;
				else if (npc.position.Y < num8 - 1.0)
					npc.velocity.Y = 1f;
				npc.velocity.Y = 0.0f;
				npc.position.Y = num8;
				float speed = 1.5f;
				if (npc.life < npc.lifeMax * 0.75)
					speed += 0.25f;
				if (npc.life < npc.lifeMax * 0.5)
					speed += 0.4f;
				if (npc.life < npc.lifeMax * 0.25)
					speed += 0.5f;
				if (npc.life < npc.lifeMax * 0.1)
					speed += 0.6f;
				if (npc.life < npc.lifeMax * 0.66 && Main.expertMode)
					speed += 0.3f;
				if (npc.life < npc.lifeMax * 0.33 && Main.expertMode)
					speed += 0.3f;
				if (npc.life < npc.lifeMax * 0.05 && Main.expertMode)
					speed += 0.6f;
				if (npc.life < npc.lifeMax * 0.035 && Main.expertMode)
					speed += 0.6f;
				if (npc.life < npc.lifeMax * 0.025 && Main.expertMode)
					speed += 0.6f;
				if (Main.expertMode)
					speed = speed * 1.35f + 0.35f;
				if (npc.velocity.X == 0.0)
				{
					npc.TargetClosest(true);
					npc.velocity.X = npc.direction;
				}
				if (npc.velocity.X < 0.0)
				{
					npc.velocity.X = -speed;
					npc.direction = -1;
				}
				else
				{
					npc.velocity.X = speed;
					npc.direction = 1;
				}
				#endregion

				#region Mouth Rotation
				npc.spriteDirection = npc.direction;
				Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
				float num10 = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) - vector2.X;
				float num11 = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - vector2.Y;
				float num12 = (float)Math.Sqrt(num10 * num10 + num11 * num11);
				float num13 = num10 * num12;
				float num14 = num11 * num12;
				npc.rotation = npc.direction <= 0 ? (Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) >= npc.position.X + (npc.width / 2) ? 0 : (float)Math.Atan2(num14, num13) + 3.14f) : (Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) <= npc.position.X + (npc.width / 2) ? 0 : (float)Math.Atan2(-num14, -num13) + 3.14f);
				#endregion

				for (int i = 0; i < 255; ++i)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						if (Main.player[i].Center.X > npc.Center.X && Main.player[i].direction == -1 && npc.direction == -1 && Vector2.Distance(Main.player[i].Center, npc.Center) <= 480f)
						{
							Main.player[i].AddBuff(BuffID.TheTongue, 600);
						}
					}
				}

				for (int i = 0; i < 255; ++i)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						if (Main.player[i].Center.X < npc.Center.X && Main.player[i].direction == 1 && npc.direction == 1 && Vector2.Distance(Main.player[i].Center, npc.Center) <= 480f)
						{
							Main.player[i].AddBuff(BuffID.TheTongue, 600);
						}
					}
				}


				if (npc.localAI[0] != 1.0 || Main.netMode == 1)
					return false;
				npc.localAI[0] = 2f;
			}

			if (npc.life > npc.lifeMax * 0.5f)
			{
				Main.npcHeadBossTexture[NPCID.Sets.BossHeadTextures[npc.type]] = mod.GetTexture("NPCs/WallOfShadow_Head_Boss");
				Shoot();
				if (npc.position.X < 160 || npc.position.X > (Main.maxTilesX - 10) * 16)
					npc.active = false;
				if (npc.localAI[0] == 0.0)
				{
					npc.localAI[0] = 1f;
					Main.wofB = -1;
					Main.wofT = -1;
				}

				npc.ai[1]++;
				if (npc.ai[2] == 0)
				{
					if (npc.life < npc.lifeMax * 0.5F)
						npc.ai[1]++;
					if (npc.life < npc.lifeMax * 0.2F)
						npc.ai[1]++;
					if (npc.ai[1] > 2700.0)
						npc.ai[2] = 1f;
				}
				if (npc.ai[2] > 0 && npc.ai[1] > 60)
				{
					int spawnCooldown = 3;
					if (npc.life < npc.lifeMax * 0.3)
						++spawnCooldown;
					npc.ai[2]++;
					npc.ai[1] = 0;
					if (npc.ai[2] > spawnCooldown)
						npc.ai[2] = 0;

					if (Main.netMode != 1)
					{

					}
				}



				Main.wof = npc.whoAmI;
				int npcTileX = (int)(npc.position.X / 16);
				int npcRightXTile = (int)((npc.position.X + npc.width) / 16);
				int npcCenterYTile = (int)((npc.position.Y + (npc.height / 2)) / 16);
				int solidTiles = 0;
				int npcBottom = npcCenterYTile + 7;
				while (solidTiles < 15 && npcBottom > Main.maxTilesY - 200)
				{
					++npcBottom;
					for (int i = npcTileX; i <= npcRightXTile; ++i)
					{
						try
						{
							if (!WorldGen.SolidTile(i, npcBottom))
							{
								if ((int)Main.tile[i, npcBottom].liquid <= 0)
									continue;
							}
							++solidTiles;
						}
						catch
						{
							solidTiles += 15;
						}
					}
				}
				int num5 = npcBottom + 4;
				if (Main.wofB == -1)
					Main.wofB = num5 * 16;
				else if (Main.wofB > num5 * 16)
				{
					--Main.wofB;
					if (Main.wofB < num5 * 16)
						Main.wofB = num5 * 16;
				}
				else if (Main.wofB < num5 * 16)
				{
					++Main.wofB;
					if (Main.wofB > num5 * 16)
						Main.wofB = num5 * 16;
				}

				int num6 = 0;
				int j2 = npcCenterYTile - 7;
				while (num6 < 15 && j2 < Main.maxTilesY - 10)
				{
					--j2;
					for (int i = npcTileX; i <= npcRightXTile; ++i)
					{
						try
						{
							if (!WorldGen.SolidTile(i, j2))
							{
								if ((int)Main.tile[i, j2].liquid <= 0)
									continue;
							}
							++num6;
						}
						catch
						{
							num6 += 15;
						}
					}
				}
				int num7 = j2 - 4;
				if (Main.wofT == -1)
					Main.wofT = num7 * 16;
				else if (Main.wofT > num7 * 16)
				{
					--Main.wofT;
					if (Main.wofT < num7 * 16)
						Main.wofT = num7 * 16;
				}
				else if (Main.wofT < num7 * 16)
				{
					++Main.wofT;
					if (Main.wofT > num7 * 16)
						Main.wofT = num7 * 16;
				}

				#region Movement
				float num8 = ((Main.wofB + Main.wofT) / 2 - npc.height / 2);
				if (npc.position.Y > num8 + 1.0)
					npc.velocity.Y = -1f;
				else if (npc.position.Y < num8 - 1.0)
					npc.velocity.Y = 1f;
				npc.velocity.Y = 0.0f;
				npc.position.Y = num8;
				float speed = 1.5f;
				if (npc.life < npc.lifeMax * 0.75)
					speed += 0.25f;
				if (npc.life < npc.lifeMax * 0.5)
					speed += 0.4f;
				if (npc.life < npc.lifeMax * 0.25)
					speed += 0.5f;
				if (npc.life < npc.lifeMax * 0.1)
					speed += 0.6f;
				if (npc.life < npc.lifeMax * 0.66 && Main.expertMode)
					speed += 0.3f;
				if (npc.life < npc.lifeMax * 0.33 && Main.expertMode)
					speed += 0.3f;
				if (npc.life < npc.lifeMax * 0.05 && Main.expertMode)
					speed += 0.6f;
				if (npc.life < npc.lifeMax * 0.035 && Main.expertMode)
					speed += 0.6f;
				if (npc.life < npc.lifeMax * 0.025 && Main.expertMode)
					speed += 0.6f;
				if (Main.expertMode)
					speed = speed * 1.35f + 0.35f;
				if (npc.velocity.X == 0.0)
				{
					npc.TargetClosest(true);
					npc.velocity.X = npc.direction;
				}
				if (npc.velocity.X < 0.0)
				{
					npc.velocity.X = -speed;
					npc.direction = -1;
				}
				else
				{
					npc.velocity.X = speed;
					npc.direction = 1;
				}
				#endregion

				#region Mouth Rotation
				npc.spriteDirection = npc.direction;
				Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
				float num10 = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) - vector2.X;
				float num11 = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - vector2.Y;
				float num12 = (float)Math.Sqrt(num10 * num10 + num11 * num11);
				float num13 = num10 * num12;
				float num14 = num11 * num12;
				npc.rotation = npc.direction <= 0 ? (Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) >= npc.position.X + (npc.width / 2) ? 0 : (float)Math.Atan2(num14, num13) + 3.14f) : (Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) <= npc.position.X + (npc.width / 2) ? 0 : (float)Math.Atan2(-num14, -num13) + 3.14f);
				#endregion

				for (int i = 0; i < 255; ++i)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						if (Main.player[i].Center.X > npc.Center.X && Main.player[i].direction == -1 && npc.direction == -1 && Vector2.Distance(Main.player[i].Center, npc.Center) <= 480f)
						{
							Main.player[i].AddBuff(BuffID.TheTongue, 600);
						}
					}
				}

				for (int i = 0; i < 255; ++i)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						if (Main.player[i].Center.X < npc.Center.X && Main.player[i].direction == 1 && npc.direction == 1 && Vector2.Distance(Main.player[i].Center, npc.Center) <= 480f)
						{
							Main.player[i].AddBuff(BuffID.TheTongue, 600);
						}
					}
				}

				//if (Main.expertMode && Main.netMode != 1)
				//{
				int num15 = (int)(1.0 + npc.life / npc.lifeMax * 10.0);
				int num16 = num15 * num15;
				if (num16 < 400)
					num16 = (num16 * 19 + 400) / 20;
				if (num16 < 60)
					num16 = (num16 * 3 + 60) / 4;
				if (num16 < 20)
					num16 = (num16 + 20) / 2;
				int maxValue1 = (int)((double)num16 * 0.7);
				if (Main.rand.Next(maxValue1) == 0)
				{
					int index1 = 0;
					float[] numArray = new float[10];
					for (int index2 = 0; index2 < 200; ++index2)
					{
						if (index1 < 10 && Main.npc[index2].active && Main.npc[index2].type == mod.NPCType("ShadowHand"))
						{
							numArray[index1] = Main.npc[index2].ai[0];
							++index1;
						}
					}
					int maxValue2 = 1 + index1 * 2;
					if (index1 < 10 && Main.rand.Next(maxValue2) <= 1)
					{
						int num17 = -1;
						for (int index2 = 0; index2 < 1000; ++index2)
						{
							int num18 = Main.rand.Next(20);
							float num19 = (float)((double)num18 * 0.100000001490116 - 0.0500000007450581);
							bool flag = true;
							for (int index3 = 0; index3 < index1; ++index3)
							{
								if ((double)num19 == (double)numArray[index3])
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								num17 = num18;
								break;
							}
						}
						if (num17 >= 0)
						{
							int index2 = NPC.NewNPC((int)npc.position.X, (int)num8, mod.NPCType("ShadowHand"), npc.whoAmI, 0.0f, 0.0f, 0.0f, 0.0f, 255);
							Main.npc[index2].ai[0] = (num17 * 0.100000001490116F - 0.0500000007450581F);
						}
					}
				}
				//}
				if (npc.localAI[0] != 1.0 || Main.netMode == 1)
					return false;
				npc.localAI[0] = 2f;

				float num20 = ((((Main.wofB + Main.wofT) / 2) + Main.wofB) / 2.0F);
				for (int index1 = 0; index1 < 11; ++index1)
				{
					int index2 = NPC.NewNPC((int)npc.position.X, (int)num20, mod.NPCType("ShadowHand"), npc.whoAmI, 0.0f, 0.0f, 0.0f, 0.0f, 255);
					Main.npc[index2].ai[0] = (index1 * 0.100000001490116F - 0.0500000007450581F);
				}

			}

			return false;
		}

		public override void FindFrame(int frameHeight)
		{
			///---------------------------------------------------------------------------------------------------------------
			int frameWidth = 96; // I'm just hardcoding this, since this is the frame width of one frame along the X axis.
			npc.spriteDirection = npc.direction;

			// Now if you want to animate, you can do:
			npc.frameCounter++;
			if (npc.frameCounter >= 12)
			{

				if (npc.life > npc.lifeMax * 0.5f)
				{
					npc.frame.Y += 98;
					if (npc.frame.Y >= 196)
					{
						npc.frame.Y = 0;
						npc.frame.X = 0;
					}
				}

				if (npc.life < npc.lifeMax * 0.5f)
				{
					npc.frame.Y += 98;
					if (npc.frame.Y >= 196)
					{
						npc.frame.Y = 0;
						npc.frame.X = 96;
					}

				}

				npc.frameCounter = 0;
			}

			npc.frame.Width = frameWidth;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 5f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 5f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WallOfShadowGore2"), 1f);
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
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (!Main.expertMode)
				{
					Helper.DropItem(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Drop(mod.ItemType("HeavyBeamCannon"), 1, 1), new Drop(mod.ItemType("Bolter"), 1, 1), new Drop(mod.ItemType("StrikerBlade"), 1, 1), new Drop(0, 0, 0));
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(5, 15));
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarknessCloth"), Main.rand.Next(8, 15));
					if (Main.rand.Next(7) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WallofShadowMask"));
					}
				}

				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WallofShadowTrophy"));
				}
			}

			if (Main.netMode != 1)
			{
				int num1 = (int)(npc.position.X + (npc.width / 2)) / 16;
				int num2 = (int)(npc.position.Y + (npc.height / 2)) / 16;
				int num5 = npc.width / 2 / 16 + 1;
				for (int index2 = num1 - num5; index2 <= num1 + num5; ++index2)
				{
					for (int index3 = num2 - num5; index3 <= num2 + num5; ++index3)
					{
						if ((index2 == num1 - num5 || index2 == num1 + num5 || (index3 == num2 - num5 || index3 == num2 + num5)) && !Main.tile[index2, index3].active())
						{
							Main.tile[index2, index3].type = 140;
							Main.tile[index2, index3].active(true);
						}
						Main.tile[index2, index3].lava(false);
						Main.tile[index2, index3].liquid = 0;
						if (Main.netMode == 2)
							NetMessage.SendTileSquare(-1, index2, index3, 1);
						else
							WorldGen.SquareTileFrame(index2, index3, true);
					}
				}

				//NetMessage.SendData(7, -1, -1, "", 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
			}
		}



		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D shadowChain = mod.GetTexture("NPCs/WallOfShadowChain");
			Texture2D shadowWall = mod.GetTexture("NPCs/WallOfShadow_Wall");
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && Main.player[i].tongued && !Main.player[i].dead)
				{
					float num = npc.position.X + (npc.width / 2);
					float num2 = npc.position.Y + (npc.height / 2);
					Vector2 vector = new Vector2(Main.player[i].position.X + Main.player[i].width * 0.5f, Main.player[i].position.Y + Main.player[i].height * 0.5f);
					float num3 = num - vector.X;
					float num4 = num2 - vector.Y;
					float rotation = (float)Math.Atan2(num4, num3) - 1.57f;
					bool flag = true;
					while (flag)
					{
						float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
						if (num5 < 40f)
						{
							flag = false;
						}
						else
						{
							num5 = shadowChain.Height / num5;
							num3 *= num5;
							num4 *= num5;
							vector.X += num3;
							vector.Y += num4;
							num3 = num - vector.X;
							num4 = num2 - vector.Y;
							Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
							spriteBatch.Draw(shadowChain, new Vector2(vector.X - Main.screenPosition.X, vector.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, shadowChain.Width, shadowChain.Height)), color, rotation, new Vector2(shadowChain.Width * 0.5f, shadowChain.Height * 0.5f), 1f, SpriteEffects.None, 0f);
						}
					}
				}
			}
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].active && Main.npc[j].type == mod.NPCType("ShadowHand"))
				{
					float num6 = npc.position.X + (npc.width / 2);
					float num7 = npc.position.Y;
					float num8 = (Main.wofB - Main.wofT);
					bool flag2 = false;
					if (Main.npc[j].frameCounter > 7.0)
					{
						flag2 = true;
					}
					num7 = Main.wofT + num8 * Main.npc[j].ai[0];
					Vector2 vector2 = new Vector2(Main.npc[j].position.X + (Main.npc[j].width / 2), Main.npc[j].position.Y + (Main.npc[j].height / 2));
					float num9 = num6 - vector2.X;
					float num10 = num7 - vector2.Y;
					float rotation2 = (float)Math.Atan2(num10, num9) - 1.57f;
					bool flag3 = true;
					while (flag3)
					{
						SpriteEffects effects1 = SpriteEffects.None;
						if (flag2)
						{
							effects1 = SpriteEffects.FlipHorizontally;
							flag2 = false;
						}
						else
						{
							flag2 = true;
						}
						int height = 28;
						float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
						if (num11 < 40f)
						{
							height = (int)num11 - 40 + 28;
							flag3 = false;
						}
						num11 = 28f / num11;
						num9 *= num11;
						num10 *= num11;
						vector2.X += num9;
						vector2.Y += num10;
						num9 = num6 - vector2.X;
						num10 = num7 - vector2.Y;
						Color color2 = Lighting.GetColor((int)vector2.X / 16, (int)(vector2.Y / 16f));
						spriteBatch.Draw(shadowChain, new Vector2(vector2.X - Main.screenPosition.X, vector2.Y - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, 0, shadowChain.Width, height)), color2, rotation2, new Vector2(shadowChain.Width * 0.5f, shadowChain.Height * 0.5f), 1f, effects1, 0f);
					}
				}
			}
			int num12 = 140;
			float num13 = (float)Main.wofT;
			float num14 = (float)Main.wofB;
			num14 = Main.screenPosition.Y + Main.screenHeight;
			float num15 = (float)((int)((num13 - Main.screenPosition.Y) / (float)num12) + 1);
			num15 *= num12;
			if (num15 > 0f)
			{
				num13 -= num15;
			}
			float num16 = num13;
			float num17 = npc.position.X;
			float num18 = num14 - num13;
			bool flag4 = true;
			SpriteEffects effects2 = SpriteEffects.None;
			if (npc.spriteDirection == 1)
			{
				effects2 = SpriteEffects.FlipHorizontally;
			}
			if (npc.direction > 0)
			{
				num17 -= 80f;
			}
			int num19 = 0;
			if (!Main.gamePaused)
			{
				Main.wofF++;
			}
			if (Main.wofF > 12)
			{
				num19 = 280;
				if (Main.wofF > 17)
				{
					Main.wofF = 0;
				}
			}
			else if (Main.wofF > 6)
			{
				num19 = 140;
			}
			while (flag4)
			{
				num18 = num14 - num16;
				if (num18 > (float)num12)
				{
					num18 = (float)num12;
				}
				bool flag5 = true;
				int num20 = 0;
				while (flag5)
				{
					int x = (int)(num17 + (float)(shadowWall.Width / 2)) / 16;
					int y = (int)(num16 + (float)num20) / 16;
					Main.spriteBatch.Draw(shadowWall, new Vector2(num17 - Main.screenPosition.X, num16 + (float)num20 - Main.screenPosition.Y), new Rectangle?(new Rectangle(0, num19 + num20, shadowWall.Width, 16)), Lighting.GetColor(x, y), 0f, default(Vector2), 1f, effects2, 0f);
					num20 += 16;
					if ((float)num20 >= num18)
					{
						flag5 = false;
					}
				}
				num16 += (float)num12;
				if (num16 >= num14)
				{
					flag4 = false;
				}
			}

			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
			npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
			npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, drawColor, npc.rotation, origin, npc.scale, effects, 0);


			return false;
		}
	}
}
