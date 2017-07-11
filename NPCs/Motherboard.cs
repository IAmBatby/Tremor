using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class Motherboard : ModNPC
	{
		#region "Константы"
		const int stateOne_FollowPlayerTime = 120; // Время следования за игроком в первой стадии
		const int stateOne_DisappearingTime = 30; // Время исчезновения в первой стадии
		const int stateOne_AppearingTime = 30; // Время появления в первой стадии
		const int stateSecond_FollowPlayerTime = 90; // Время следования за игроком в второй стадии
		const int stateSecond_DisappearingTime = 30; // Время исчезновения в второй стадии
		const int stateSecond_AppearingTime = 30; // Время появления в второй стадии
		const int maxDrones = 20; // Макс. кол-во дронов
		const int DronSpawnAreaX = 300; // Размер площади, в которой может заспавнится дрон, по X
		const int DronSpawnAreaY = 300; // Размер площади, в которой может заспавнится дрон, по Y
		const int StartDronCount = 8; // Начальное кол-во дронов
		const int ShootRate = 150; // Скорость стрельбы (60ед. == 1сек.)
		const int LaserDamage = 40; // Урон от лазера
		const float LaserKB = 1; // Отброс от лазера
		const int LaserYOffset = 95; // Смещение точки спавна лазера по Y ( + значени это вниз, - значение это вверх)
		const int TimeToLaserRate = 3; // Скорость выстрелов лазером от дрона до дрона
		const int LaserType = ProjectileID.ShadowBeamHostile; // Тип выстрела по игроку
		const int AnimationRate = 6; // Скорость смены кадров
		const int SecondShootCount = 3;
		const float SecondShootSpeed = 15f;
		const int SecondShootDamage = 30;
		const float SecondShootKN = 1.0f;
		const int SecondShootRate = 60;
		const int SecondShootSpread = 65;
		const float SecondShootSpreadMult = 0.05f;
		#endregion

		#region "Переменные"
		bool FirstAI = true; // Первый ли раз вызван метод AI
		bool FirstState = true; // Первая ли стадия
		List<int> SignalDrones = new List<int>(); // ID сигнальных дронов
		int LastSignalDron = -1; // Последний дрон принимающий лазер
		int stateTime = stateOne_AppearingTime + stateOne_DisappearingTime + stateOne_FollowPlayerTime; // Время стадии
		bool ShootNow = false; // Происходит ли сейчас стрелба
		int TimeToNextDrone = 1; // Время до спавна следующего дрона
		int TimeToShoot = 60; // Время до следующего выстрела
		int TimeToLaser = 3; // Время до выстрела лазера от дрона до дрона
		int CurrentFrame = 0; // Содержит текущий кадр анимации
		int TimeToAnimation = 6; // Время до смены кадра
		List<int> Clampers = new List<int>(); // Список кламперов
		int SecondShootTime = 60;
		int ai = 0;

		int getStateTime { get { return getAppearingTimeNow + getDisappearingTimeNow + getFollowPlayerTimeNow; } } //-----
																												   // Получить время требуемое на полный цикл смены состояний
		int getTimeToNextDrone { get { return (Main.rand.Next(3, 6) * 60); } } // Получить время до следующего дрона

		//----- Методы получения времени на состояния в данный момент
		int getFollowPlayerTimeNow { get { return (FirstState) ? stateOne_FollowPlayerTime : stateSecond_FollowPlayerTime; } }
		int getDisappearingTimeNow { get { return (FirstState) ? stateOne_DisappearingTime : stateSecond_DisappearingTime; } }
		int getAppearingTimeNow { get { return (FirstState) ? stateOne_AppearingTime : stateSecond_AppearingTime; } }
		//-----
		#endregion

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Motherboard");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.dontTakeDamage = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.lifeMax = 45000;
			npc.damage = 30;
			npc.knockBackResist = 0f;
			npc.defense = 70;
			npc.width = 170;
			npc.height = 160;
			npc.aiStyle = 2;
			npc.boss = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
			music = 13;
			bossBag = mod.ItemType("MotherboardBag");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		void Teleport()
		{
			npc.aiStyle = 2;
			npc.position += npc.velocity * 2;
		}

		public override void AI()
		{
			Animation();
			if (Helper.GetNearestPlayer(npc.position, true) == -1 || Main.dayTime)
			{
				npc.aiStyle = 11;
				npc.damage = 1000;
				npc.ai[0] = 2;
			}
			if (npc.aiStyle == 11)
			{
				npc.rotation = 0;
				return;
			}
			if (FirstAI)
			{
				FirstAI = false;
				for (int i = 0; i < ((StartDronCount <= 0) ? 1 : StartDronCount); i++)
				{
					Vector2 SpawnPosition = Helper.RandomPointInArea(new Vector2(npc.Center.X - DronSpawnAreaX / 2, npc.Center.Y - DronSpawnAreaY / 2), new Vector2(npc.Center.X + DronSpawnAreaX / 2, npc.Center.Y + DronSpawnAreaY / 2));
					SignalDrones.Add(NPC.NewNPC((int)SpawnPosition.X, (int)SpawnPosition.Y, mod.NPCType("SignalDron"), 0, 0, 0, 0, npc.whoAmI));
				}
			}
			ChangeAI();
			if (FirstState)
			{
				Main.npcHeadBossTexture[NPCID.Sets.BossHeadTextures[npc.type]] = mod.GetTexture("NPCs/Motherboard_Head_Boss");
				Drones();
				npc.dontTakeDamage = true;
			}
			else
			{
				Main.npcHeadBossTexture[NPCID.Sets.BossHeadTextures[npc.type]] = mod.GetTexture("NPCs/Motherboard_Head_Boss2");
				Teleport();
				if (ai == 1)
				{
					npc.TargetClosest(true);
					Vector2 vector142 = new Vector2(npc.Center.X, npc.Center.Y);
					float num1243 = Main.player[npc.target].Center.X - vector142.X;
					float num1244 = Main.player[npc.target].Center.Y - vector142.Y;
					float num1245 = (float)Math.Sqrt((double)(num1243 * num1243 + num1244 * num1244));
					if (npc.ai[1] == 0f)
					{
						if (Main.netMode != 1)
						{
							npc.localAI[1] += 1f;
							if (npc.localAI[1] >= (float)(120 + Main.rand.Next(200)))
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
									if (!WorldGen.SolidTile(num1250, num1251) && Collision.CanHit(new Vector2((float)(num1250 * 16), (float)(num1251 * 16)), 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
									{
										break;
									}
									if (num1249 > 100)
									{
										return;
									}
								}
								npc.ai[1] = 1f;
								npc.ai[2] = (float)num1250;
								npc.ai[3] = (float)num1251;
								npc.netUpdate = true;
								return;
							}
						}
					}
					else if (npc.ai[1] == 1f)
					{
						npc.alpha += 3;
						if (npc.alpha >= 255)
						{
							npc.alpha = 255;
							npc.position.X = npc.ai[2] * 16f - (float)(npc.width / 2);
							npc.position.Y = npc.ai[3] * 16f - (float)(npc.height / 2);
							npc.ai[1] = 2f;
							return;
						}
					}
					else if (npc.ai[1] == 2f)
					{
						npc.alpha -= 3;
						if (npc.alpha <= 0)
						{
							npc.alpha = 0;
							npc.ai[1] = 0f;
							return;
						}
					}
				}
				CheckClampers();
				SecondShoot();
				npc.dontTakeDamage = false;
				return;
			}
			ChangeStady();
		}

		void Animation()
		{
			if (--TimeToAnimation <= 0)
			{

				if (++CurrentFrame > 3)
					CurrentFrame = 1;
				TimeToAnimation = AnimationRate;
				npc.frame = GetFrame(CurrentFrame + ((FirstState) ? 0 : 3));
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore4"), 1f);
			}
		}
		void SecondShoot()
		{
			for (int i = (int)npc.position.X - 8; i < (npc.position.X + 8 + npc.width); i += 8)
				for (int l = (int)npc.Center.Y + 90; l < (npc.Center.Y + 106); l += 8)
					if (WorldGen.SolidTile(i / 16, l / 16))
						return;
			if (--SecondShootTime <= 0)
			{
				SecondShootTime = SecondShootRate;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 95, 0, 0, mod.ProjectileType("projMotherboardSuperLaser"), SecondShootDamage, SecondShootKN, 0, npc.whoAmI, 0);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 95, 0, 0, mod.ProjectileType("projMotherboardSuperLaser"), SecondShootDamage, SecondShootKN, 0, npc.whoAmI, 1);
			}
		}

		void ChangeStady() // Попытка смены стадии
		{
			CheckDrones(); // Удаляем лишних дронов (мёртвых)
			if (SignalDrones.Count <= 0) // Если живих дронов нет
			{
				FirstState = false; // Выключаем первую стадию
				Clampers = new List<int> {
				NPC.NewNPC((int)npc.Center.X - 15, (int)npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
				NPC.NewNPC((int)npc.Center.X - 10, (int)npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
				NPC.NewNPC((int)npc.Center.X + 10, (int)npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
				NPC.NewNPC((int)npc.Center.X + 15, (int)npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI)};
				Main.npc[Clampers[0]].localAI[1] = 1;
				Main.npc[Clampers[1]].localAI[1] = 2;
				Main.npc[Clampers[2]].localAI[1] = 3;
				Main.npc[Clampers[3]].localAI[1] = 4;
			}
		}

		int AppearTime = 0;
		void ChangeAI() // Сменяет состояние (преследование/исчезновение/появление)
		{
			if (FirstState)
			{
				--stateTime; // Уменьшаем время состояний
				if (stateTime <= 0) // Если время состояния меньше или равно 0, то обновляем переменную
					stateTime = getStateTime; // Обновление
				for (int i = 0; i < Clampers.Count; i++)
					Main.npc[Clampers[i]].ai[2] = 1;
				if (stateTime <= getAppearingTimeNow) // Если у нас стадия появления
				{
					npc.ai[0] = -3; // То появляемся
					return; // Завершаем метод
				}
				if (stateTime <= getAppearingTimeNow + getDisappearingTimeNow) // Если у нас стадия исчезновения
				{
					npc.ai[0] = -2; // Исчезаем
					return; // Завершаем метод
				}
			}
			// Сюда процессор дойдёт только в том случаи, если сейчас стадия следования за игроком, по этому...
			if (npc.ai[0] == -2)
				AppearTime = getAppearingTimeNow;
			if (--AppearTime > 0)
			{
				npc.ai[0] = -3;
				return;
			}
			npc.ai[0] = -1; // Следуем за игроком
		}

		void CheckClampers()
		{
			for (int index = 0; index < Clampers.Count; index++) // Проходим по каждому элементу массива с id кламперов
				if (!Main.npc[Clampers[index]].active || Main.npc[Clampers[index]].type != mod.NPCType("Clamper")) // Если...
																												   // NPC с текущим ID из массива кламперов, не является клампером, или мёртв, то...
				{
					Clampers.RemoveAt(index); // Удаляем из списка кламперов ID данного NPC
					--index; // Уменьшаем индекс на 1, чтобы не перескочить через одно значение в массиве ID кламперов
				}
			foreach (int ID in Clampers)
			{
				int id = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + LaserYOffset, 0, 0, mod.ProjectileType("projClamperLaser"), LaserDamage, LaserKB, 0, npc.whoAmI, ID);
				Main.projectile[id].localAI[1] = stateTime;
			}
		}

		void Drones() // Работает с дронами (только в первой стадии)
		{
			CheckDrones(); // Удаляет из списка всех мёртвых дронов
			SpawnDrones(); // Спавнит дронов
			ShootDrones(); // Работа с лазерами
		}

		void CheckDrones() // Удаляет из списка всех мёртвых дронов
		{
			for (int index = 0; index < SignalDrones.Count; index++) // Проходим по каждому элементу массива с id дронов
				if (!Main.npc[SignalDrones[index]].active || Main.npc[SignalDrones[index]].type != mod.NPCType("SignalDron")) // Если...
																															  // NPC с текущим ID из массива дронов, не является дроном, или мёртв, то...
				{
					SignalDrones.RemoveAt(index); // Удаляем из списка дронов ID данного NPC
					--index; // Уменьшаем индекс на 1, чтобы не перескочить через одно значение в массиве ID дронов
				}
		}

		void SpawnDrones() // Если пришло время, спавнит дрона
		{
			if (SignalDrones.Count >= maxDrones) // Если текущее кол-во дронов равно или привышает лимит дронов, то...
				return; // Завершаем метод
			if (--TimeToNextDrone <= 0) // Уменьшаем время до спавна следующего дрона. Если время до следующего дрона меньше или равно 0, то...
			{
				TimeToNextDrone = getTimeToNextDrone; // Устанавливаем новое время для спавна дронов
				Vector2 SpawnPosition = Helper.RandomPointInArea(new Vector2(npc.Center.X - DronSpawnAreaX / 2, npc.Center.Y - DronSpawnAreaY / 2), new Vector2(npc.Center.X + DronSpawnAreaX / 2, npc.Center.Y + DronSpawnAreaY / 2));
				// С помощью хелпера определяем случайную позицию вокруг босса и записываем в переменную 01
				SignalDrones.Add(NPC.NewNPC((int)SpawnPosition.X, (int)SpawnPosition.Y + LaserYOffset, mod.NPCType("SignalDron"), 0, 0, 0, 0, npc.whoAmI));
				// Спавним дрона с координатами из переменной 01 и с ID данного босса в ai[3]
			}
		}

		void ShootDrones() // Если пришло время, начинает стрельбу
		{
			if (SignalDrones.Count <= 0) // Если нету дронов, то...
				return; // Завершаем метод
			if (--TimeToShoot <= 0 || ShootNow) // Если сейчас идёт стрельба, или настало её время (тут же это время изменяем), то
			{
				if (LastSignalDron == -1 && npc.ai[0] != -1)
					return;
				TimeToShoot = ShootRate; // Устанавливаем новое время выстрела
				ShootNow = true; // Сейчас стреляем
				if (--TimeToLaser <= 0) // Если время стрелять лазером от дрона до дрона
				{
					TimeToLaser = TimeToLaserRate; // Устанавливаем новое время
					if (LastSignalDron == -1) // Если нет последнего стрелявшего дрона, то...
					{
						LastSignalDron = 0; // Берём первого дрона из массива
						Main.projectile[Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("projMotherboardLaser"), LaserDamage, LaserKB, 0, npc.whoAmI, SignalDrones[LastSignalDron])].localAI[1] = 1;
						// Стреляем в него из босса
						return; // Выход из метода
					}
					++LastSignalDron; // Берём следующего дрона
					if (LastSignalDron < SignalDrones.Count) // Проверка на выход за пределы массива
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("projMotherboardLaser"), LaserDamage, LaserKB, 0, SignalDrones[LastSignalDron - 1], SignalDrones[LastSignalDron]);
					// Спавним лазер
					if (LastSignalDron + 1 >= SignalDrones.Count) // Если это замыкающий дрон, то...
					{
						Vector2 vel = Helper.VelocityToPoint(Main.npc[SignalDrones[SignalDrones.Count - 1]].Center, Main.player[npc.target].Center, 15f);
						for (int i = 0; i < SecondShootCount; i++)
						{
							Vector2 velocity = Helper.VelocityToPoint(Main.npc[SignalDrones[SignalDrones.Count - 1]].Center, Main.player[npc.target].Center, SecondShootSpeed);
							velocity.X = velocity.X + (float)Main.rand.Next(-SecondShootSpread, SecondShootSpread + 1) * SecondShootSpreadMult;
							velocity.Y = velocity.Y + (float)Main.rand.Next(-SecondShootSpread, SecondShootSpread + 1) * SecondShootSpreadMult;
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, LaserType, SecondShootDamage, SecondShootKN);
						}
						LastSignalDron = -1;
						ShootNow = false;
						// Стреляем в игрока другим лазером, устанавливаем последнего дрона на -1 и завершаем цикл стрельбы
					}
				}
			}
		}

		public override void NPCLoot()
		{
			NPC.downedMechBossAny = true;
			NPC.downedMechBoss1 = true;
			TremorWorld.downedMotherboard = true;
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (Main.expertMode)
				{
					npc.DropBossBags();
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulofMind"), Main.rand.Next(20, 40));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(5, 15));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1225, Main.rand.Next(15, 35));
				}
				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MotherboardMask"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MotherboardTrophy"));
				}
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BenderLegs"));
				}
				if (NPC.downedMoonlord && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CarbonSteel"), Main.rand.Next(6, 12));
				}
				if (NPC.downedMechBossAny && Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FlaskCore"));
				}
			}
		}
	}
}