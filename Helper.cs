using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	public delegate void ExtraAction();

	public static class Helper
	{
		#region Spawn helpers
		public static bool NoInvasion(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.invasion && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);
		}

		public static bool NoBiome(NPCSpawnInfo spawnInfo)
		{
			Player player = spawnInfo.player;
			return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
		}

		public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
		}

		public static bool NoZone(NPCSpawnInfo spawnInfo)
		{
			return NoZoneAllowWater(spawnInfo) && !spawnInfo.water;
		}

		public static bool NormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerInTown && NoInvasion(spawnInfo);
		}

		public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoZone(spawnInfo);
		}

		public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);
		}

		public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);
		}
		#endregion

		public static Item SpawnItem(this ModNPC npc, short type, int stack = 1)
			=> SpawnItem(npc.npc, type, stack);

		public static Item SpawnItem(this NPC npc, short type, int stack = 1)
			=> Main.item[Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, type, stack)];

		public static Item SpawnItem(Vector2 position, Vector2 size, short type, int stack = 1)
			=> Main.item[Item.NewItem((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, type, stack)];

		public static Vector2 RandomPosition(Vector2 pos1, Vector2 pos2)
		{
			Random rnd = new Random();
			return new Vector2(rnd.Next((int)pos1.X, (int)pos2.X) + 1, rnd.Next((int)pos1.Y, (int)pos2.Y) + 1);
		}

		public static int GetNearestAlivePlayer(NPC npc)
		{
			float NearestPlayerDist = 4815162342f;
			int NearestPlayer = -1;
			foreach (Player player in Main.player)
			{
				if (player.Distance(npc.Center) < NearestPlayerDist && player.active)
				{
					NearestPlayerDist = player.Distance(npc.Center);
					NearestPlayer = player.whoAmI;
				}
			}
			return NearestPlayer;
		}

		public static Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			//speed2 = speed * 0.5;
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}

		/// <summary>
		/// *Используется для нахождения ID ближайшего NPC к точке*
		/// </summary>
		/// <param name="Point">Точка</param>
		/// <param name="Friendly">Считаются ли мирные NPC?</param>
		/// <param name="NoBoss">Не возвращять боссов</param>
		/// <returns>Возвращяет ID ближайшего NPC к точке с задаными параметрами</returns>
		public static int GetNearestNPC(Vector2 Point, bool Friendly = false, bool NoBoss = false)
		{
			float NearestNPCDist = -1;
			int NearestNPC = -1;
			foreach (NPC npc in Main.npc)
			{
				if (!npc.active)
					continue;
				if (NoBoss && npc.boss)
					continue;
				if (!Friendly && (npc.friendly || npc.lifeMax <= 5))
					continue;
				if (NearestNPCDist == -1 || npc.Distance(Point) < NearestNPCDist)
				{
					NearestNPCDist = npc.Distance(Point);
					NearestNPC = npc.whoAmI;
				}
			}
			return NearestNPC;
		}

		/// <summary>
		/// *Используется для нахождения ID ближайшего игрока к точке*
		/// </summary>
		/// <param name="Point">Точка</param>
		/// <param name="Alive">Нужны ли только живые игроки</param>
		/// <returns>Возвращяет ID ближайшего игрока к точке с задаными параметрами</returns>
		public static int GetNearestPlayer(Vector2 Point, bool Alive = false)
		{
			float NearestPlayerDist = -1;
			int NearestPlayer = -1;
			foreach (Player player in Main.player)
			{
				if (Alive && (!player.active || player.dead))
					continue;
				if (NearestPlayerDist == -1 || player.Distance(Point) < NearestPlayerDist)
				{
					NearestPlayerDist = player.Distance(Point);
					NearestPlayer = player.whoAmI;
				}
			}
			return NearestPlayer;
		}

		public static int GetNearestPlayer(this NPC npc)
		{
			float NearestPlayerDist = 4815162342f;
			int NearestPlayer = -1;
			foreach (Player player in Main.player)
			{
				if (player.Distance(npc.Center) < NearestPlayerDist)
				{
					NearestPlayerDist = player.Distance(npc.Center);
					NearestPlayer = player.whoAmI;
				}
			}
			return NearestPlayer;
		}


		/// <summary>
		/// *Используется для вычислиения инерции от точки до точки с заданой скоростью*
		/// </summary>
		/// <param name="A">Точка А</param>
		/// <param name="B">Точка В</param>
		/// <param name="Speed">Скорость</param>
		/// <returns>Возвращяет инерцию</returns>
		public static Vector2 VelocityToPoint(Vector2 A, Vector2 B, float Speed)
		{
			Vector2 Move = (B - A);
			return Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
		}

		/// <summary>
		/// *Вычесление случайной точки в прямоугольнике*
		/// </summary>
		/// <param name="A">Точка прямоугольника A</param>
		/// <param name="B">Точка прямоугольника B</param>
		/// <returns>Случайную точку в прямоугольнике из заданых точек</returns>
		public static Vector2 RandomPointInArea(Vector2 A, Vector2 B)
		{
			return new Vector2(Main.rand.Next((int)A.X, (int)B.X) + 1, Main.rand.Next((int)A.Y, (int)B.Y) + 1);
		}

		/// <summary>
		/// *Вычесление случайной точки в прямоугольнике*
		/// </summary>
		/// <param name="Area">Прямоугольник</param>
		/// <returns>Случайную точку в заданом прямоугольнике</returns>
		public static Vector2 RandomPointInArea(Rectangle Area)
		{
			return new Vector2(Main.rand.Next(Area.X, Area.X + Area.Width), Main.rand.Next(Area.Y, Area.Y + Area.Height));
		}

		/// <summary>
		/// *Используется для поворота объекта между двумя точками*
		/// </summary>
		/// <param name="A">Точка А</param>
		/// <param name="B">Точка B</param>
		/// <returns>Угол поворота между данными точками в раданах</returns>
		public static float rotateBetween2Points(Vector2 A, Vector2 B)
		{
			return (float)Math.Atan2(A.Y - B.Y, A.X - B.X);
		}

		/// <summary>
		/// *Вычисления позиции между двумя точками*
		/// </summary>
		/// <param name="A">Точка A</param>
		/// <param name="B">Точка B</param>
		/// <returns>Точку между точками A и B</returns>
		public static Vector2 CenterPoint(Vector2 A, Vector2 B)
		{
			return new Vector2((A.X + B.X) / 2.0f, (A.Y + B.Y) / 2.0f);
		}

		/// <summary>
		/// *Вычисление позици точки с полярным смещением от другой*
		/// </summary>
		/// <param name="Point">Начальная точка</param>
		/// <param name="Distance">Дистанция смещения</param>
		/// <param name="Angle">Угол смещения в радианах</param>
		/// <param name="XOffset">Смещение по X</param>
		/// <param name="YOffset">Смещение по Y</param>
		/// <returns>Возвращяет точку смещённую по заданым параметрам</returns>
		public static Vector2 PolarPos(Vector2 Point, float Distance, float Angle, int XOffset = 0, int YOffset = 0)
		{
			Vector2 returnedValue = new Vector2
			{
				X = (Distance * (float)Math.Sin(MathHelper.ToDegrees(Angle)) + Point.X) + XOffset,
				Y = (Distance * (float)Math.Cos(MathHelper.ToDegrees(Angle)) + Point.Y) + YOffset
			};
			return returnedValue;
		}

		/// <summary>*Вычисления того, произойдёт ли событие с заданым шансом в этот раз, или нет*</summary>
		/// <param name="chance">Шанс события</param>
		/// <returns>Произойдёт ли событие с заданым шансом, или нет</returns>
		public static bool Chance(float chance)
		{
			return (Main.rand.NextFloat() <= chance);
		}

		/// <summary>
		/// *Используется для плавного перехода одного вектора в другой*
		/// Добавляет во входящий вектор From разницу To и From делённую на Smooth
		/// </summary>
		/// <param name="From">Исходный вектор</param>
		/// <param name="To">Конечный вектор</param>
		/// <param name="Smooth">Плавность перехода</param>
		/// <returns>Возвращяет вектор From который был приближен к вектору To с плавностью Smooth</returns>
		public static Vector2 SmoothFromTo(Vector2 From, Vector2 To, float Smooth = 60f)
		{
			return From + ((To - From) / Smooth);
		}

		public static float DistortFloat(float Float, float Percent)
		{
			float DistortNumber = Float * Percent;
			int Counter = 0;
			while (DistortNumber.ToString().Split(',').Length > 1)
			{
				DistortNumber *= 10;
				Counter++;
			}
			return Float + ((Main.rand.Next(0, (int)DistortNumber + 1) / (float)(Math.Pow(10, Counter))) * ((Main.rand.Next(2) == 0) ? -1 : 1));
		}

		public static void Explode(int index, int sizeX, int sizeY, ExtraAction visualAction = null)
		{
			Projectile projectile = Main.projectile[index];
			if (!projectile.active)
			{
				return;
			}
			projectile.tileCollide = false;
			projectile.alpha = 255;
			projectile.position.X = projectile.position.X + projectile.width / 2;
			projectile.position.Y = projectile.position.Y + projectile.height / 2;
			projectile.width = sizeX;
			projectile.height = sizeY;
			projectile.position.X = projectile.position.X - projectile.width / 2;
			projectile.position.Y = projectile.position.Y - projectile.height / 2;
			projectile.Damage();
			Main.projectileIdentity[projectile.owner, projectile.identity] = -1;
			projectile.position.X = projectile.position.X + projectile.width / 2;
			projectile.position.Y = projectile.position.Y + projectile.height / 2;
			projectile.width = (int)(sizeX / 5.8f);
			projectile.height = (int)(sizeY / 5.8f);
			projectile.position.X = projectile.position.X - projectile.width / 2;
			projectile.position.Y = projectile.position.Y - projectile.height / 2;
			if (visualAction == null)
			{
				for (int i = 0; i < 30; i++)
				{
					int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num].velocity *= 1.4f;
				}
				for (int j = 0; j < 20; j++)
				{
					int num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3.5f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].velocity *= 7f;
					num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
					Main.dust[num2].velocity *= 3f;
				}
				for (int k = 0; k < 2; k++)
				{
					float scaleFactor = 0.4f;
					if (k == 1)
					{
						scaleFactor = 0.8f;
					}
					int num3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num3].velocity *= scaleFactor;
					Gore gore = Main.gore[num3];
					gore.velocity.X = gore.velocity.X + 1f;
					Gore gore2 = Main.gore[num3];
					gore2.velocity.Y = gore2.velocity.Y + 1f;
					num3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num3].velocity *= scaleFactor;
					Gore gore3 = Main.gore[num3];
					gore3.velocity.X = gore3.velocity.X - 1f;
					Gore gore4 = Main.gore[num3];
					gore4.velocity.Y = gore4.velocity.Y + 1f;
					num3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num3].velocity *= scaleFactor;
					Gore gore5 = Main.gore[num3];
					gore5.velocity.X = gore5.velocity.X + 1f;
					Gore gore6 = Main.gore[num3];
					gore6.velocity.Y = gore6.velocity.Y - 1f;
					num3 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num3].velocity *= scaleFactor;
					Gore gore7 = Main.gore[num3];
					gore7.velocity.X = gore7.velocity.X - 1f;
					Gore gore8 = Main.gore[num3];
					gore8.velocity.Y = gore8.velocity.Y - 1f;
				}
				return;
			}
			visualAction();
		}

		public static void DrawAroundOrigin(int index, Color lightColor)
		{
			Projectile projectile = Main.projectile[index];
			Texture2D texture2D = Main.projectileTexture[projectile.type];
			Vector2 origin = new Vector2(texture2D.Width * 0.5f, texture2D.Height / Main.projFrames[projectile.type] * 0.5f);
			SpriteEffects effects = (projectile.direction == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Main.spriteBatch.Draw(texture2D, projectile.Center - Main.screenPosition, texture2D.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame), lightColor, projectile.rotation, origin, projectile.scale, effects, 0f);
		}

		public static void DropItem(Rectangle Area, params Drop[] Drops)
		{
			List<Drop> Sh = new List<Drop>();
			Drops
			.ToList()
			.ForEach(drop =>
			{
				for (int index = 0; index < drop.Chance; index++)
					Sh.Add(drop);
			});
			Drop DroppedItem = Sh[Main.rand.Next(Sh.Count)];
			Item.NewItem(Area.X, Area.Y, Area.Height, Area.Width, DroppedItem.Item, DroppedItem.Count);
		}

	}

	public struct Drop
	{
		public int Item; public int Count; public int Chance;
		public Drop(int item, int count, int chance)
		{
			Item = item; Count = count; Chance = chance;
		}
	}
}