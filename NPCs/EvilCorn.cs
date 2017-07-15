using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

/*
1 состояние - парит на месте - при приближении игрока даёт ему оплеуху. 
Время от времени на пару секунд скрывается в своих "листьях" переводя весь полученный урон - в хил.
2 состояние - начинает лететь за игроком махая своими "листьями" и раздавая оплеухи уже всем подряд.
3 состояние - после полёта на несколько секунд зарывается в землю - после чего резко оттуда выпрыгивает нанося большой урон.
*/

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class EvilCorn : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evil Corn");
			Main.npcFrameCount[npc.type] = 22;
		}

		#region "Константы для настойки AI"
		const int simpleAttakStateTime = 120; // Время которое он будет стоять на месте и бить
		const int simpleDefenseStateTime = 120; // Время которое он будет стоять и хилится
		const int normalAttackStateTime = 180; // Время которое он будет летать за игроком и бить его
		const int normalDefenseStateTime = 45;

		const int simpleAttakAnimTime = 30; // Длительность анимации атаки (лучше не менять, а попросить меня...)
		const int simpleCangeLeversTime = 12; // Длительность анимации Листьем (тоже что и с атакой...)

		const float SimpleHitDist = 125f; // Дистанция обычного удара
		#endregion

		#region "Переменные для работы с AI"
		int State;
		// 0 - парит на месте, при приближении бьёт
		// 1 - парит на месте, скрыт в своих листьях
		// 2 - летает за игроком махая листьями
		int stateTime = simpleAttakStateTime;
		// Время до завершения текущего действия
		int nowHitPlayerLeft;
		// Время до завершения текущей анимации удара влево
		int nowHitPlayerRight;
		// Время до завершения текущей анимации удара вправо
		int nowCangeLeavs;
		// Время до завершения текушей анимации смены листьев
		#endregion

		public override void SetDefaults()
		{
			npc.lifeMax = 3000;
			npc.damage = 30;
			npc.defense = 12;
			npc.knockBackResist = 0f;
			npc.width = 155;
			npc.height = 93;
			npc.aiStyle = -1;
			npc.noGravity = false;
			npc.noTileCollide = false;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.boss = true;
			npc.value = Item.buyPrice(0, 3, 25, 0);
			music = 19;
			bossBag = mod.ItemType("EvilCornBag");
		}
		// ТУТ ЕЩЕ НАСТРОЙКИ !!!
		const int damage0 = 20; // Урон в первом состоянии
		const int defense0 = 2; // Броня в первом состоянии
		const int damage1 = 10; // Урон во втором состоянии
		const int defense1 = 4; // Броня во втором состоянии
		const int damage2 = 30; // Урон в 3 состоянии
		const int defense2 = 3; // Броня в 3 состоянии
		const int damage3 = 30; // Урон в 4 состоянии
		const int defense3 = 4; // Броня в 4 состоянии

		#region "Вылёт попкорна при ударе"
		public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Popcorn"), 0);
			base.OnHitByItem(player, item, damage, knockback, crit);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Popcorn"), 0);
			base.OnHitByProjectile(projectile, damage, knockback, crit);
		}
		#endregion

		#region "Работа с анимацией"
		int _2_Frame = 17;
		int FrameNow;
		bool needState3SetFrame = true;
		void PlayAnimation()
		{
			npc.rotation = 0;
			if (nowHitPlayerLeft > 0 || nowHitPlayerRight > 0)
			{
				if (nowHitPlayerLeft > 0)
					if (nowHitPlayerLeft % 6 == 0)
					{
						npc.frame = getFrame(nowHitPlayerLeft / 6 + 1);
						FrameNow = nowHitPlayerLeft / 6 + 1;
					}
				if (nowHitPlayerRight > 0)
					if (nowHitPlayerRight % 6 == 0)
					{
						npc.frame = getFrame(nowHitPlayerRight / 6 + 6);
						FrameNow = nowHitPlayerLeft / 6 + 6;
					}
				return;
			}
			if (nowCangeLeavs > 0)
			{
				if (State == 0 || State == 2)
				{
					if (nowCangeLeavs % 6 == 0)
					{
						if (nowCangeLeavs > 6)
						{
							npc.frame = getFrame(12);
							FrameNow = 12;
						}
						else
						{
							npc.frame = getFrame(13);
							FrameNow = 13;
						}
					}
				}
				else
				{
					if (nowCangeLeavs % 6 == 0)
					{
						if (nowCangeLeavs > 6)
						{
							npc.frame = getFrame(13);
							FrameNow = 13;
						}
						else
						{
							npc.frame = getFrame(12);
							FrameNow = 12;
						}
					}
				}
			}
			else
			{
				if (State == 0)
					if (nowHitPlayerLeft <= 0 && nowHitPlayerRight <= 0)
					{
						npc.frame = getFrame(1);
						FrameNow = 1;
					}
				if (State == 1)
				{
					npc.frame = getFrame(14);
					FrameNow = 14;
				}
				if (State == 2)
				{
					if (stateTime % 3 == 0)
					{
						npc.frame = getFrame(_2_Frame);
						FrameNow = _2_Frame;
						_2_Frame++;
						if (_2_Frame > 20)
							_2_Frame = 17;
					}
				}
				if (State == 3)
				{
					if (needState3SetFrame)
						npc.frame = getFrame(14);
					needState3SetFrame = false;
				}
			}
		}

		Rectangle getFrame(int Index)
		{
			Index--;
			Rectangle rect = new Rectangle(0, 93 * Index, 155, 93);
			if (++Index > 13)
				rect.Y += 2;
			else
				rect.Y += 1;
			return rect;
		}
		#endregion

		bool NeedPrepere = true;
		List<int> Stadyes = new List<int> { 0, 1, 2, 3 };
		int NextStady = -1;
		void RechangeStage()
		{
			if (NextStady == -1)
			{
				if (Stadyes.Contains(State))
					Stadyes.Remove(State);
				if (Stadyes.Count <= 0) { Stadyes = new List<int> { 0, 1, 2, 3 }; Stadyes.Remove(State); }
				int ID = Main.rand.Next(0, Stadyes.Count);
				NextStady = Stadyes[ID];
				Stadyes.RemoveAt(ID);
			}

			switch (State)
			{
				case 0:
					#region "Оброботка перехода с первой стадии"
					switch (NextStady)
					{
						case 1:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								npc.damage = damage1;
								npc.defense = defense1;
								State = 1;
								stateTime = simpleDefenseStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 2:
							npc.damage = damage2;
							npc.defense = defense2;
							npc.noGravity = true;
							npc.noTileCollide = true;
							npc.aiStyle = 5;
							State = 2;
							stateTime = normalAttackStateTime;
							NextStady = -1;
							break;
						case 3:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								npc.damage = damage3;
								npc.defense = defense3;
								State = 3;
								stateTime = normalDefenseStateTime;
								NeedPrepere = true;
								NextStady = -1;
								needState3SetFrame = true;
							}
							break;
					}
					#endregion
					break;
				case 1:
					#region "Оброботка перехода с второй стадии"
					switch (NextStady)
					{
						case 0:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								npc.damage = damage0;
								npc.defense = defense0;
								State = 0;
								stateTime = simpleAttakStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 2:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								npc.damage = damage2;
								npc.defense = defense2;
								npc.noGravity = true;
								npc.noTileCollide = true;
								npc.aiStyle = 5;
								State = 2;
								stateTime = normalAttackStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 3:
							npc.damage = damage3;
							npc.defense = defense3;
							State = 3;
							stateTime = normalDefenseStateTime;
							NextStady = -1;
							needState3SetFrame = true;
							break;
					}
					#endregion
					break;
				case 2:
					#region "Оброботка перехода с третьей стадии"
					switch (NextStady)
					{
						case 0:
							npc.velocity.X = 0;
							npc.damage = damage0;
							npc.defense = defense0;
							npc.noGravity = false;
							npc.noTileCollide = false;
							npc.aiStyle = -1;
							State = 0;
							stateTime = simpleAttakStateTime;
							NextStady = -1;
							break;
						case 1:
							if (NeedPrepere)
							{
								npc.velocity.X = 0;
								npc.noGravity = false;
								npc.noTileCollide = false;
								npc.aiStyle = -1;
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								npc.damage = damage1;
								npc.defense = defense1;
								State = 1;
								stateTime = simpleDefenseStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 3:
							if (NeedPrepere)
							{
								npc.velocity.X = 0;
								npc.noGravity = false;
								npc.noTileCollide = false;
								npc.aiStyle = -1;
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								npc.damage = damage3;
								npc.defense = defense3;
								State = 3;
								stateTime = normalDefenseStateTime;
								NeedPrepere = true;
								NextStady = -1;
								needState3SetFrame = true;
							}
							break;
					}
					#endregion
					break;
				case 3:
					#region "Оброботка перехода с четвёртой стадии"
					switch (NextStady)
					{
						case 0:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								npc.damage = damage0;
								npc.defense = defense0;
								State = 0;
								stateTime = simpleAttakStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
						case 1:
							npc.damage = damage1;
							npc.defense = defense1;
							State = 1;
							stateTime = simpleDefenseStateTime;
							NextStady = -1;
							break;
						case 2:
							if (NeedPrepere)
							{
								nowCangeLeavs = simpleCangeLeversTime;
								NeedPrepere = false;
								break;
							}
							if (--nowCangeLeavs <= 0)
							{
								npc.noGravity = true;
								npc.noTileCollide = true;
								npc.aiStyle = 5;
								npc.damage = damage2;
								npc.defense = defense2;
								State = 2;
								stateTime = normalAttackStateTime;
								NeedPrepere = true;
								NextStady = -1;
							}
							break;
					}
					#endregion
					break;
			}
		}

		#region "Урон в здоровье во время 2 стадии"
		public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			if (State == 1) // Если вторая стадия (в ней идёт конвертирование урона в хп), то
			{
				int hpBeforeHeal = npc.life; // Сохраняем в переменную текущее хп
				npc.life += damage; // Добавляем в хп моба урон который должны нанести
				if (npc.life > npc.lifeMax) // Если теперь хп больше макс. хп, уменьшаем до макс. хп
					npc.life = npc.lifeMax;
				if (npc.lifeMax - hpBeforeHeal > 0) // Если отхил произошол
					npc.HealEffect(npc.lifeMax - hpBeforeHeal); // Показываем эффект лечения на то хп, которое восстановил моб
				damage = 0; // Убираем урон
			}
			base.ModifyHitByItem(player, item, ref damage, ref knockback, ref crit);
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (State == 1) // Если вторая стадия (в ней идёт конвертирование урона в хп), то
			{
				npc.life += damage; // Добавляем в хп моба урон который должны нанести
				int hpBeforeHeal = npc.life; // Сохраняем в переменную текущее хп
				if (npc.life > npc.lifeMax) // Если теперь хп больше макс. хп, уменьшаем до макс. хп
					npc.life = npc.lifeMax;
				if (npc.lifeMax - hpBeforeHeal > 0) // Если отхил произошол
					npc.HealEffect(npc.lifeMax - hpBeforeHeal); // Показываем эффект лечения на то хп, которое восстановил моб
				damage = 0; // Убираем урон
			}
			base.ModifyHitByProjectile(projectile, ref damage, ref knockback, ref crit, ref hitDirection);
		}
		#endregion

		public override void AI()
		{
			if (Helper.GetNearestPlayer(npc.Center, true) != -1 && !Main.dayTime)
			{
				// В зависимости от состояния, вызываются разные методы AI
				switch (State)
				{
					case 0:
						SimpleAttak(); // парит на месте, при приближении бьёт
						break;
					case 1:
						SimpleDeffense(); // парит на месте, скрыт в своих листьях
						break;
					case 2:
						NormalAttak(); // летает за игроком махая листьями
						break;
					case 3:
						NormalDefense(); // летает за игроком махая листьями
						break;
				}
				PlayAnimation(); // Проигрываем анимацию
			}
			else
			{
				npc.velocity = new Vector2(0, -25);
				if (npc.Distance(Main.player[Helper.GetNearestPlayer(npc.Center)].position) > 2500f)
					npc.life = -1;
			}
		}

		#region "Методы работы первой стадии"
		void SimpleAttak() // парит на месте, при приближении бьёт
		{
			// Если время действия подошло к концу (тут его и уменьшаем) и не идёт анимации удара, то изменить стадию
			if (--stateTime <= 0 && nowHitPlayerLeft <= 0 && nowHitPlayerRight <= 0)
			{
				RechangeStage();
				return;
			}
			// Если анимаций нет (а значит стадия не меняется, так как переход на следующую стадию проходит с анимацией листьев) то пробуем ударить кого-то
			if (nowHitPlayerRight <= 0 && nowHitPlayerLeft <= 0 && nowCangeLeavs <= 0 && stateTime > 0)
				SimpleAttak_Hit();
			// Уменьшаем время до конца удара
			if (nowHitPlayerLeft > 0)
				nowHitPlayerLeft--;
			if (nowHitPlayerRight > 0)
				nowHitPlayerRight--;
		}

		void SimpleAttak_Hit()
		{
			// Получаем ближайшего живого игрока, и если таких нет, то прерываем метод
			int Target = Helper.GetNearestPlayer(npc.Center, true);
			if (Target == -1)
				return;
			// Если дистанция до ближайшего живого игрока нормальная для удара - бьём
			if (npc.Distance(Main.player[Target].Center) <= SimpleHitDist)
			{
				// Тут происходит выбор - в какую сторону бить.
				if (Main.player[Target].position.X < npc.position.X)
					nowHitPlayerLeft = simpleAttakAnimTime;
				else
					nowHitPlayerRight = simpleAttakAnimTime;
			}
		}
		#endregion // парит на месте, при приближении бьёт // парит на месте, при приближении бьёт// парит на месте, при приближении бьёт

		void SimpleDeffense() // парит на месте, скрыт в своих листьях
		{
			if (--stateTime <= 0)
			{
				RechangeStage();
			}
		}

		void NormalAttak() // летает за игроком махая листьями
		{
			if (--stateTime <= 0)
			{
				RechangeStage();
				return;
			}
			npc.position += npc.velocity; // Увеличиваем скорость вдвое
		}

		int FrameYOffset;
		bool FirstAction = true;
		bool needTP = true;
		int TimeToNS = 6;
		const int TimeToNSConst = 6;
		void NormalDefense()
		{
			if (stateTime > 30)
				--stateTime;
			if (stateTime <= 30)
			{
				npc.dontTakeDamage = true;
				if (stateTime <= 0)
				{
					npc.dontTakeDamage = false;
					NextStady = 2;
					RechangeStage();
					FrameYOffset = 0;
					FirstAction = true;
					needTP = true;
					return;
				}
				if (FirstAction)
				{
					if (npc.velocity.Y <= 0)
					{
						if (Main.rand.Next(6) == 0)
							for (int x = (int)npc.position.X; x < (npc.position.X + npc.width); x++)
								Dust.NewDust(new Vector2(x, npc.position.Y + npc.height), 1, 1, DustID.GoldCoin);
						npc.frame = getFrame(22);
						npc.frame.Y -= FrameYOffset;
						FrameYOffset += 4;
						if (FrameYOffset >= npc.height)
						{
							FirstAction = false;
							FrameYOffset = 0;
						}
					}
				}
				else
				{
					if (npc.velocity.Y > 0)
						return;
					if (needTP)
					{
						needTP = false;
						TeleportOnPlayer();
					}
					while (!WorldGen.SolidTile((int)npc.Center.X / 16, ((int)npc.position.Y + npc.height) / 16 + 1))
						npc.position.Y += 8;
					if (Main.rand.Next(6) == 0)
						for (int x = (int)npc.position.X; x < (npc.position.X + npc.width); x++)
							Dust.NewDust(new Vector2(x, npc.position.Y + npc.height), 1, 1, DustID.GoldCoin);
					npc.frame = getFrame(21);
					npc.frame.Y += FrameYOffset;
					FrameYOffset += 8;
					if (FrameYOffset >= npc.height)
					{
						npc.frame = getFrame(14);
						if (--TimeToNS >= 1)
							return;
						TimeToNS = TimeToNSConst;
						stateTime = -1;
					}
				}
			}
		}

		void TeleportOnPlayer()
		{
			npc.Teleport(new Vector2(Main.player[Helper.GetNearestPlayer(npc.Center, true)].position.X - npc.width / 2, Main.player[Helper.GetNearestPlayer(npc.Center, true)].position.Y - npc.height), -1);
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
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EvilCornMask"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EvilCornTrophy"));
				}
				if (!Main.expertMode && Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GrayKnightHelmet"));
				}
				if (!Main.expertMode && Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GrayKnightBreastplate"));
				}
				if (!Main.expertMode && Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KnightGreaves"));
				}
				if (!Main.expertMode && Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CornSword"));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Corn"), Main.rand.Next(25, 48));
				}
				if (!Main.expertMode && !Main.player[Main.myPlayer].HasItem(mod.ItemType("FarmerShovel")))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FarmerShovel"));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CornJavelin"), Main.rand.Next(15, 45));
				}
				TremorWorld.downedBoss[TremorWorld.Boss.EvilCorn] = true;

			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CornGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CornGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CornGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CornGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CornGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CornGore4"), 1f);
			}
		}
	}
}