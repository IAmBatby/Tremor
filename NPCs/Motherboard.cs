using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;

namespace Tremor.NPCs
{
	// TODO: fix Motherboard despawn on first hit
	// TODO: motherboard does not spawn in MP
	// TODO: rewrite this thing, lol
	[AutoloadBossHead]
	public class Motherboard : ModNPC
	{
		#region "Константы"

		private const int StateOneFollowPlayerTime = 120; // Время следования за игроком в первой стадии
		private const int StateOneDisappearingTime = 30; // Время исчезновения в первой стадии
		private const int StateOneAppearingTime = 30; // Время появления в первой стадии
		private const int StateSecondFollowPlayerTime = 90; // Время следования за игроком в второй стадии
		private const int StateSecondDisappearingTime = 30; // Время исчезновения в второй стадии
		private const int StateSecondAppearingTime = 30; // Время появления в второй стадии
		private const int MaxDrones = 20; // Макс. кол-во дронов
		private const int DronSpawnAreaX = 300; // Размер площади, в которой может заспавнится дрон, по X
		private const int DronSpawnAreaY = 300; // Размер площади, в которой может заспавнится дрон, по Y
		private const int StartDronCount = 8; // Начальное кол-во дронов
		private const int ShootRate = 150; // Скорость стрельбы (60ед. == 1сек.)
		private const int LaserDamage = 40; // Урон от лазера
		private const float LaserKb = 1; // Отброс от лазера
		private const int LaserYOffset = 95; // Смещение точки спавна лазера по Y ( + значени это вниз, - значение это вверх)
		private const int TimeToLaserRate = 3; // Скорость выстрелов лазером от дрона до дрона
		private const int LaserType = ProjectileID.ShadowBeamHostile; // Тип выстрела по игроку
		private const int AnimationRate = 6; // Скорость смены кадров
		private const int SecondShootCount = 3;
		private const float SecondShootSpeed = 15f;
		private const int SecondShootDamage = 30;
		private const float SecondShootKn = 1.0f;
		private const int SecondShootRate = 60;
		private const int SecondShootSpread = 65;
		private const float SecondShootSpreadMult = 0.05f;
		#endregion

		#region "Переменные"

		private int _appearTime;
		private bool _firstAi = true; // Первый ли раз вызван метод AI
		private bool _firstState = true; // Первая ли стадия
		private List<int> _signalDrones = new List<int>(); // ID сигнальных дронов
		private int _lastSignalDron = -1; // Последний дрон принимающий лазер
		private int _stateTime = StateOneAppearingTime + StateOneDisappearingTime + StateOneFollowPlayerTime; // Время стадии
		private bool _shootNow; // Происходит ли сейчас стрелба
		private int _timeToNextDrone = 1; // Время до спавна следующего дрона
		private int _timeToShoot = 60; // Время до следующего выстрела
		private int _timeToLaser = 3; // Время до выстрела лазера от дрона до дрона
		private int _currentFrame; // Содержит текущий кадр анимации
		private int _timeToAnimation = 6; // Время до смены кадра
		private List<int> _clampers = new List<int>(); // Список кламперов
		private int _secondShootTime = 60;
		private int _ai = 0;

		private int GetStateTime => GetAppearingTimeNow + GetDisappearingTimeNow + GetFollowPlayerTimeNow;
		//-----
		// Получить время требуемое на полный цикл смены состояний
		private int GetTimeToNextDrone => (Main.rand.Next(3, 6) * 60);
		// Получить время до следующего дрона

		//----- Методы получения времени на состояния в данный момент
		private int GetFollowPlayerTimeNow => (_firstState) ? StateOneFollowPlayerTime : StateSecondFollowPlayerTime;
		private int GetDisappearingTimeNow => (_firstState) ? StateOneDisappearingTime : StateSecondDisappearingTime;
		private int GetAppearingTimeNow => (_firstState) ? StateOneAppearingTime : StateSecondAppearingTime;
		//-----
		#endregion

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Motherboard");
			Main.npcFrameCount[npc.type] = 6;

			NPCID.Sets.MustAlwaysDraw[npc.type] = true;
			NPCID.Sets.NeedsExpertScaling[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 45000;
			npc.damage = 30;
			npc.knockBackResist = 0f;
			npc.defense = 70;
			npc.width = 170;
			npc.height = 160;
			npc.aiStyle = 2; // -1
			npc.npcSlots = 50f;
			music = MusicID.Boss3;

			npc.dontTakeDamage = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.boss = true;
			npc.lavaImmune = true;

			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;

			bossBag = mod.ItemType<MotherboardBag>();
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override bool UsesPartyHat() => false;

		// ?? Doesn't seem to fix much
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(_appearTime);
			writer.Write(_firstAi);
			writer.Write(_firstState);
			writer.Write(_signalDrones.Count);
			foreach (int drone in _signalDrones)
			{
				writer.Write(drone);
			}
			writer.Write(_lastSignalDron);
			writer.Write(_shootNow);
			writer.Write(_timeToNextDrone);
			writer.Write(_timeToShoot);
			writer.Write(_timeToLaser);
			writer.Write(_currentFrame);
			writer.Write(_timeToAnimation);
			writer.Write(_clampers.Count);
			foreach (int clamper in _clampers)
			{
				writer.Write(clamper);
			}
			writer.Write(_secondShootTime);
			writer.Write(_ai);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			_appearTime = reader.ReadInt32();
			_firstAi = reader.ReadBoolean();
			_firstState = reader.ReadBoolean();
			int c = reader.ReadInt32();
			_signalDrones = new List<int>();
			for (int i = 0; i < c; i++)
			{
				_signalDrones[i] = reader.ReadInt32();
			}
			_lastSignalDron = reader.ReadInt32();
			_shootNow = reader.ReadBoolean();
			_timeToNextDrone = reader.ReadInt32();
			_timeToShoot = reader.ReadInt32();
			_timeToLaser = reader.ReadInt32();
			_currentFrame = reader.ReadInt32();
			_timeToAnimation = reader.ReadInt32();
			c = reader.ReadInt32();
			for (int i = 0; i < c; i++)
			{
				_clampers[i] = reader.ReadInt32();
			}
			_secondShootTime = reader.ReadInt32();
			_ai = reader.ReadInt32();
		}

		private void Teleport()
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
			if (_firstAi)
			{
				_firstAi = false;
				for (int i = 0; i < ((StartDronCount <= 0) ? 1 : StartDronCount); i++)
				{
					Vector2 spawnPosition = Helper.RandomPointInArea(new Vector2(npc.Center.X - DronSpawnAreaX / 2, npc.Center.Y - DronSpawnAreaY / 2), new Vector2(npc.Center.X + DronSpawnAreaX / 2, npc.Center.Y + DronSpawnAreaY / 2));
					_signalDrones.Add(NPC.NewNPC((int)spawnPosition.X, (int)spawnPosition.Y, mod.NPCType("SignalDron"), 0, 0, 0, 0, npc.whoAmI));
				}
			}
			ChangeAi();
			if (_firstState)
			{
				Main.npcHeadBossTexture[NPCID.Sets.BossHeadTextures[npc.type]] = mod.GetTexture("NPCs/Motherboard_Head_Boss");
				Drones();
				npc.dontTakeDamage = true;
			}
			else
			{
				Main.npcHeadBossTexture[NPCID.Sets.BossHeadTextures[npc.type]] = mod.GetTexture("NPCs/Motherboard_Head_Boss2");
				Teleport();
				if (_ai == 1)
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
										return;
									}
								}
								npc.ai[1] = 1f;
								npc.ai[2] = num1250;
								npc.ai[3] = num1251;
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
							npc.position.X = npc.ai[2] * 16f - npc.width / 2;
							npc.position.Y = npc.ai[3] * 16f - npc.height / 2;
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

		private void Animation()
		{
			if (--_timeToAnimation <= 0)
			{

				if (++_currentFrame > 3)
					_currentFrame = 1;
				_timeToAnimation = AnimationRate;
				npc.frame = GetFrame(_currentFrame + ((_firstState) ? 0 : 3));
			}
		}

		private Rectangle GetFrame(int number)
		{
			return new Rectangle(0, npc.frame.Height * (number - 1), npc.frame.Width, npc.frame.Height);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore4"), 1f);
			}
		}

		private void SecondShoot()
		{
			for (int i = (int)npc.position.X - 8; i < (npc.position.X + 8 + npc.width); i += 8)
				for (int l = (int)npc.Center.Y + 90; l < (npc.Center.Y + 106); l += 8)
					if (WorldGen.SolidTile(i / 16, l / 16))
						return;
			if (--_secondShootTime <= 0)
			{
				_secondShootTime = SecondShootRate;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 95, 0, 0, mod.ProjectileType("projMotherboardSuperLaser"), SecondShootDamage, SecondShootKn, 0, npc.whoAmI, 0);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 95, 0, 0, mod.ProjectileType("projMotherboardSuperLaser"), SecondShootDamage, SecondShootKn, 0, npc.whoAmI, 1);
			}
		}

		private void ChangeStady() // Попытка смены стадии
		{
			CheckDrones(); // Удаляем лишних дронов (мёртвых)
			if (_signalDrones.Count <= 0) // Если живих дронов нет
			{
				_firstState = false; // Выключаем первую стадию
				_clampers = new List<int>
				{
					NPC.NewNPC((int) npc.Center.X - 15, (int) npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
					NPC.NewNPC((int) npc.Center.X - 10, (int) npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
					NPC.NewNPC((int) npc.Center.X + 10, (int) npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
					NPC.NewNPC((int) npc.Center.X + 15, (int) npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI)
				};
				Main.npc[_clampers[0]].localAI[1] = 1;
				Main.npc[_clampers[1]].localAI[1] = 2;
				Main.npc[_clampers[2]].localAI[1] = 3;
				Main.npc[_clampers[3]].localAI[1] = 4;
			}
		}

		private void ChangeAi() // Сменяет состояние (преследование/исчезновение/появление)
		{
			if (_firstState)
			{
				--_stateTime; // Уменьшаем время состояний
				if (_stateTime <= 0) // Если время состояния меньше или равно 0, то обновляем переменную
					_stateTime = GetStateTime; // Обновление
				for (int i = 0; i < _clampers.Count; i++)
					Main.npc[_clampers[i]].ai[2] = 1;
				if (_stateTime <= GetAppearingTimeNow) // Если у нас стадия появления
				{
					npc.ai[0] = -3; // То появляемся
					return; // Завершаем метод
				}
				if (_stateTime <= GetAppearingTimeNow + GetDisappearingTimeNow) // Если у нас стадия исчезновения
				{
					npc.ai[0] = -2; // Исчезаем
					return; // Завершаем метод
				}
			}
			// Сюда процессор дойдёт только в том случаи, если сейчас стадия следования за игроком, по этому...
			if (npc.ai[0] == -2)
				_appearTime = GetAppearingTimeNow;
			if (--_appearTime > 0)
			{
				npc.ai[0] = -3;
				return;
			}
			npc.ai[0] = -1; // Следуем за игроком
		}

		private void CheckClampers()
		{
			for (int index = 0; index < _clampers.Count; index++) // Проходим по каждому элементу массива с id кламперов
				if (!Main.npc[_clampers[index]].active || Main.npc[_clampers[index]].type != mod.NPCType("Clamper")) // Если...
																													 // NPC с текущим ID из массива кламперов, не является клампером, или мёртв, то...
				{
					_clampers.RemoveAt(index); // Удаляем из списка кламперов ID данного NPC
					--index; // Уменьшаем индекс на 1, чтобы не перескочить через одно значение в массиве ID кламперов
				}
			foreach (int ID in _clampers)
			{
				int id = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + LaserYOffset, 0, 0, mod.ProjectileType("projClamperLaser"), LaserDamage, LaserKb, 0, npc.whoAmI, ID);
				Main.projectile[id].localAI[1] = _stateTime;
			}
		}

		private void Drones() // Работает с дронами (только в первой стадии)
		{
			CheckDrones(); // Удаляет из списка всех мёртвых дронов
			SpawnDrones(); // Спавнит дронов
			ShootDrones(); // Работа с лазерами
		}

		private void CheckDrones() // Удаляет из списка всех мёртвых дронов
		{
			for (int index = 0; index < _signalDrones.Count; index++) // Проходим по каждому элементу массива с id дронов
				if (!Main.npc[_signalDrones[index]].active || Main.npc[_signalDrones[index]].type != mod.NPCType("SignalDron")) // Если...
																																// NPC с текущим ID из массива дронов, не является дроном, или мёртв, то...
				{
					_signalDrones.RemoveAt(index); // Удаляем из списка дронов ID данного NPC
					--index; // Уменьшаем индекс на 1, чтобы не перескочить через одно значение в массиве ID дронов
				}
		}

		private void SpawnDrones() // Если пришло время, спавнит дрона
		{
			if (_signalDrones.Count >= MaxDrones) // Если текущее кол-во дронов равно или привышает лимит дронов, то...
				return; // Завершаем метод
			if (--_timeToNextDrone <= 0) // Уменьшаем время до спавна следующего дрона. Если время до следующего дрона меньше или равно 0, то...
			{
				_timeToNextDrone = GetTimeToNextDrone; // Устанавливаем новое время для спавна дронов
				Vector2 spawnPosition = Helper.RandomPointInArea(new Vector2(npc.Center.X - DronSpawnAreaX / 2, npc.Center.Y - DronSpawnAreaY / 2), new Vector2(npc.Center.X + DronSpawnAreaX / 2, npc.Center.Y + DronSpawnAreaY / 2));
				// С помощью хелпера определяем случайную позицию вокруг босса и записываем в переменную 01
				_signalDrones.Add(NPC.NewNPC((int)spawnPosition.X, (int)spawnPosition.Y + LaserYOffset, mod.NPCType("SignalDron"), 0, 0, 0, 0, npc.whoAmI));
				// Спавним дрона с координатами из переменной 01 и с ID данного босса в ai[3]
			}
		}

		private void ShootDrones() // Если пришло время, начинает стрельбу
		{
			if (_signalDrones.Count <= 0) // Если нету дронов, то...
				return; // Завершаем метод
			if (--_timeToShoot <= 0 || _shootNow) // Если сейчас идёт стрельба, или настало её время (тут же это время изменяем), то
			{
				if (_lastSignalDron == -1 && npc.ai[0] != -1)
					return;
				_timeToShoot = ShootRate; // Устанавливаем новое время выстрела
				_shootNow = true; // Сейчас стреляем
				if (--_timeToLaser <= 0) // Если время стрелять лазером от дрона до дрона
				{
					_timeToLaser = TimeToLaserRate; // Устанавливаем новое время
					if (_lastSignalDron == -1) // Если нет последнего стрелявшего дрона, то...
					{
						_lastSignalDron = 0; // Берём первого дрона из массива
						Main.projectile[Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("projMotherboardLaser"), LaserDamage, LaserKb, 0, npc.whoAmI, _signalDrones[_lastSignalDron])].localAI[1] = 1;
						// Стреляем в него из босса
						return; // Выход из метода
					}
					++_lastSignalDron; // Берём следующего дрона
					if (_lastSignalDron < _signalDrones.Count) // Проверка на выход за пределы массива
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("projMotherboardLaser"), LaserDamage, LaserKb, 0, _signalDrones[_lastSignalDron - 1], _signalDrones[_lastSignalDron]);
					// Спавним лазер
					if (_lastSignalDron + 1 >= _signalDrones.Count) // Если это замыкающий дрон, то...
					{
						Vector2 vel = Helper.VelocityToPoint(Main.npc[_signalDrones[_signalDrones.Count - 1]].Center, Main.player[npc.target].Center, 15f);
						for (int i = 0; i < SecondShootCount; i++)
						{
							Vector2 velocity = Helper.VelocityToPoint(Main.npc[_signalDrones[_signalDrones.Count - 1]].Center, Main.player[npc.target].Center, SecondShootSpeed);
							velocity.X = velocity.X + Main.rand.Next(-SecondShootSpread, SecondShootSpread + 1) * SecondShootSpreadMult;
							velocity.Y = velocity.Y + Main.rand.Next(-SecondShootSpread, SecondShootSpread + 1) * SecondShootSpreadMult;
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, LaserType, SecondShootDamage, SecondShootKn);
						}
						_lastSignalDron = -1;
						_shootNow = false;
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

			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				if (Main.rand.NextBool())
				{
					this.SpawnItem((short) mod.ItemType<SoulofMind>(), Main.rand.Next(20, 40));
				}
				if (Main.rand.NextBool())
				{
					this.SpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 15));
				}
				if (Main.rand.NextBool())
				{
					this.SpawnItem(ItemID.HallowedBar, Main.rand.Next(15, 35));
				}
				if (Main.rand.Next(7) == 0)
				{
					this.SpawnItem((short) mod.ItemType<MotherboardMask>());
				}
			}

			if (Main.rand.Next(10) == 0)
			{
				this.SpawnItem((short) mod.ItemType<MotherboardTrophy>());
			}
			if (Main.rand.Next(3) == 0)
			{
				this.SpawnItem((short) mod.ItemType<BenderLegs>());
			}
			if (Main.rand.Next(10) == 0)
			{
				this.SpawnItem((short) mod.ItemType<FlaskCore>());
			}

			if (NPC.downedMoonlord && Main.rand.NextBool())
			{
				this.SpawnItem((short) mod.ItemType<CarbonSteel>(), Main.rand.Next(6, 12));
			}
		}
	}
}