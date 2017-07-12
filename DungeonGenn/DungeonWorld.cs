using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace Tremor.DungeonGenn
{
	public class DungeonWorld : ModWorld
	{
		private const int saveVersion = 0;

		static public bool debuging = false;
		static public bool debugingOcean = false;
		static public bool showLog = false;

		static public Dungeon[] dungeon;
		static public int spawnTileX;
		static public int spawnTileY;
		static public int rockLayerFat;
		static public int lavaLayer = 0;
		static public int densityDivider;
		//public DungeonGen(ModBase modBase) : base(modBase){ }
		static public bool[] zoneFleshRuin = new bool[256];
		static public bool[] zoneLavaRuin = new bool[256];
		static bool small, medium, large;
		public int tick = 2147483647;
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				// Shinies pass removed by some other mod.
				return;
			}
			tasks.Insert(ShiniesIndex + 1, new PassLegacy("Generating dungeon", delegate (GenerationProgress progress)
			{
				progress.Message = "Generating ruines...";
				SetVars();
				GenerateLayout();
				GenerateOffset();
				Draw();
			}));
		}

		static public void SetVars()
		{
			//kiek sugeneruoti dungeon'su
			//size Small-4200x1200, Medium-6400x1800, Large-8400x2400
			//rock Small~390, Medium~778 638, Large~900
			//old x*y = small-504, medium-1152, large-2016
			//x*(y-rock) = small~336, medium~640, large~1260
			small = Main.maxTilesY < 1500;
			large = Main.maxTilesY > 2300;
			medium = !small && !large;
			rockLayerFat = Main.maxTilesY - (int)Main.rockLayer;
			//if(small) densityDivider = 50;
			densityDivider = 35;
			//with old 32 = small-15, medium-36, large-63
			//with new 32 = small~10, medium~20, large~39
		}
		static public void GenerateLayout()
		{
			int dungeonNum = (int)(Main.maxTilesX / 100 * (Main.maxTilesY - Main.rockLayer) / 100 / densityDivider);
			dungeon = new Dungeon[dungeonNum];
			for (int i = 0; i < dungeon.Length; i++)
			{
				if (i < dungeonNum * 0.2f)
				{
					dungeon[i] = new Dungeon(60);
					DungeonSetting(i);
					dungeon[i].GenerateTraitRich(); //lava layer
				}
				else if (i < dungeonNum * 0.4f)
				{
					dungeon[i] = new Dungeon(30);
					DungeonSetting(i);
					dungeon[i].GenerateTraitRich(); //mid rock layer
				}
				else
				{
					dungeon[i] = new Dungeon(10);
					DungeonSetting(i);
					dungeon[i].GenerateTraitRich(); //top rock layer
				}
			}
		}
		static public void DungeonSetting(int index)
		{
			if (small)
			{
				dungeon[index].sizeAddX = 100;
				dungeon[index].sizeAddY = 20;
			}
		}
		static public void GenerateOffset()
		{
			int dungeonNum = dungeon.Length;
			int noDungeonZone = 0;
			int DungeonZone = Main.maxTilesX - noDungeonZone * 2;
			//int diff=350;//Main.maxTilesX/dungeon.Length/2;
			for (int i = 0; i < dungeon.Length; i++)
			{
				bool TouchesDungeon = false;
				bool repeat;
				int loop = 0;
				int curZone = DungeonZone / (dungeon.Length) * i + noDungeonZone;
				do
				{
					TouchesDungeon = false;
					if (loop++ > 100)
					{
						dungeon[i].isOk = false;
						break;
					}
					//big
					if (i < dungeonNum * 0.2f)
					{
						dungeon[i].GenerateOffset((int)(Main.maxTilesX * 0.05), (int)(Main.maxTilesX * 0.95), (int)(Main.rockLayer + rockLayerFat * 0.4), (int)Main.rockLayer + rockLayerFat);
					}
					//medium
					else if (i < dungeonNum * 0.6f)
					{
						dungeon[i].GenerateOffset(0, Main.maxTilesX, (int)(Main.rockLayer + rockLayerFat * 0.1), (int)(Main.rockLayer + rockLayerFat * 0.6));
					}
					//small
					else
					{
						dungeon[i].GenerateOffset(0, Main.maxTilesX, (int)Main.worldSurface, (int)(Main.rockLayer + rockLayerFat * 0.1));
					}
					for (int j = 0; j < i; j++)
					{
						if (dungeon[i].TouchesDungeon(dungeon[j]))
						{
							TouchesDungeon = true;
							break;
						}
					}
					bool offsetFits = dungeon[i].OffsetFits();
					//Log.WriteLine("offsetFits", offsetFits);
					repeat = TouchesDungeon || !offsetFits;
					//repeat = !dungeon[i].OffsetFits();
				}
				while (repeat);
			}
			if (debuging)
			{
				int goTo = 3;
				dungeon[goTo].room[0].SetAsPlayerSpawnRoom(dungeon[goTo].offsetX, dungeon[goTo].offsetY);
				dungeon[goTo].isOk = true;
			}
		}
		static public void Draw()
		{
			for (int i = 0; i < dungeon.Length; i++) dungeon[i].Fill();
			for (int i = 0; i < dungeon.Length; i++) dungeon[i].Carve();
			for (int i = 0; i < dungeon.Length; i++)
			{
				dungeon[i].FillWithBridges();
				dungeon[i].FillWithFurniture();
				dungeon[i].FillWithChests();
			}
		}
	}

	public class Dungeon
	{
		public ushort type = 120;
		public ushort wall = 24;
		private int roomNum = 5;

		public Trait[] trait;
		public int changeTraitChance = 35;
		public int minTrait = 1;
		public int maxTrait = 4;

		public int spawnRoomChance = 20;
		public int itemType = 0;
		public int chestRoomChance = 1;
		public int MinChestRoomNum = 2;//2
		public int MaxChestRoomNum = 4;//4
		public int connectChance = 75;//out
		public int steepness = 50;
		public int destroyedChance = 25;

		public int maxH = 15;
		public int minH = 6;
		public int maxW = 25;
		public int minW = 10;
		public int maxDistBeetweenRooms = 15;
		public int corridorSize = 4;
		public int modifyChance = 2;
		public int modifyLimit = 2;
		//}
		//{architecture context
		public int lowestId;
		public int pickedCenter;
		public bool madeBelow = false;
		public bool madeOnTop = false;
		//}
		//{other
		public int dungeonSizeX1;
		public int dungeonSizeY1;
		public int dungeonSizeX2;
		public int dungeonSizeY2;
		public int sizeAddX = 150;
		public int sizeAddY = 100;

		public int offsetX = Main.spawnTileX - 10;
		public int offsetY = Main.spawnTileY - 5;

		public Room[] room;
		public Room[] corridor;
		public Graph graph;
		public int CorridorNum;

		public bool isOk = true;

		public Dungeon(int newRoomNum)
		{
			roomNum = newRoomNum;
			AfterContructor();
		}
		public Dungeon()
		{
			AfterContructor();
		}
		public void AfterContructor()
		{
			room = new Room[roomNum];
			for (int i = 0; i < room.Length; i++)
			{
				room[i] = new Room();
			}
			graph = new Graph(roomNum);
			TileList.PickRandom(this);
			GenerateTraits();
		}
		public void GenerateTraits()
		{
			trait = new Trait[WorldGen.genRand.Next(minTrait, maxTrait)];
			for (int i = 0; i < trait.Length; i++)
			{
				trait[i] = new Trait();
			}
		}
		//}
		//{DUNGEON TYPE METHODS
		public void MutateAllTraits()
		{
			for (int i = 0; i < trait.Length; i++)
			{
				trait[i].Mutate();
			}
		}
		public void GenerateTraitRich()
		{
			int currentTrait = WorldGen.genRand.Next(trait.Length);
			for (int i = 0; i < room.Length; i++)
			{
				if (HitChance(changeTraitChance)) currentTrait = WorldGen.genRand.Next(trait.Length);
				GenerateSproutRoom(i, currentTrait);
				//trait[currentTrait].Mutate();
			}
			AfterGenerate();
		}

		public static bool HitChance(int chance)
		{
			return (WorldGen.genRand.Next(100) < chance);
		}

		public void GenerateOcean()
		{
			/*maxDistBeetweenRooms/=2;
    for(int i=0; i<floorNum; i++)
				for(int j=0; j<roomNum; j++)
				{
            if(i<=1)
            {
                room[i,j]=new Room();
                if(i==0 && j==0)
                {
                    room[i,j].GenerateRoom(minW, maxW, minH, maxH);
                    room[i,j].isDestroyed=true;
                    room[i,j].wallState=2;
                }
                else if(j==0)
                {
                    room[i,j].GenerateUnder(room[i-1, roomNum-1], minW/2, maxW/2, minH, maxH, maxDistBeetweenRooms/2);
                    graph[GetRoomFullId(i, j), GetRoomFullId(i-1, roomNum-1)]=true;
                }
                else
                {
                    room[i,j].GenerateUnder(room[i, j-1], minW/2, maxW/2, minH, maxH, maxDistBeetweenRooms/2);
                    graph[GetRoomFullId(i, j), GetRoomFullId(i, j-1)]=true;
                }
            }
					else GenerateSparseRoom(i,j);
            room[i,j].isFlooded=true;
            if(i!=0)room[i,j].isAroundSand=true;
            if(HitChance(80))room[i,j].wallState=0;
        }
			AfterGenerate();*/
		}
		private void AfterGenerate()
		{
			GenerateCorridors();
			DetermineSize();
			FixRoomPositions();
		}
		//}
		//{ROOM LAYOUT METHODS
		public void GeneratePureRandomRoom(int i, int traitId)
		{
			bool TouchesRoom;
			int direction;
			int sproutRoom;
			int looped = 0;
			do
			{
				TouchesRoom = false;
				sproutRoom = WorldGen.genRand.Next(i);
				direction = WorldGen.genRand.Next(4);
				if (direction == 0)
				{
					room[i].GenerateRightTo(room[sproutRoom], trait[traitId]);
				}
				else if (direction == 1)
				{
					room[i].GenerateLeftTo(room[sproutRoom], trait[traitId]);
				}
				else if (direction == 2)
				{
					room[i].GenerateUnder(room[sproutRoom], trait[traitId]);
				}
				else if (direction == 3)
				{
					room[i].GenerateOnTopOf(room[sproutRoom], trait[traitId]);
				}
				//tikrinama ar kambariia lieciasi
				for (int j = 0; j < i; j++)
				{
					if (room[i].TouchesRoom(room[j]))
					{
						TouchesRoom = true;
						break;
					}
				}
				looped++;
			}
			while (TouchesRoom && looped < 10);
			graph.Connect(i, sproutRoom);
		}
		public void GenerateSproutRoom(int i, int traitId)
		{
			bool TouchesRoom;
			int direction;
			int sproutRoom = i - 1;
			if (sproutRoom < 0) sproutRoom = 0;
			int looped = 0;
			do
			{
				TouchesRoom = false;
				if (looped > 0) sproutRoom = WorldGen.genRand.Next(i);
				direction = WorldGen.genRand.Next(4);
				if (direction == 0)
				{
					room[i].GenerateRightTo(room[sproutRoom], trait[traitId]);
				}
				else if (direction == 1)
				{
					room[i].GenerateLeftTo(room[sproutRoom], trait[traitId]);
				}
				else if (direction == 2)
				{
					room[i].GenerateUnder(room[sproutRoom], trait[traitId]);
				}
				else if (direction == 3)
				{
					room[i].GenerateOnTopOf(room[sproutRoom], trait[traitId]);
				}
				//tikrinama ar kambariia lieciasi
				for (int j = 0; j < i; j++)
				{
					if (room[i].TouchesRoom(room[j]))
					{
						TouchesRoom = true;
						break;
					}
				}
				looped++;
			}
			while (TouchesRoom && looped < 10);
			graph.Connect(i, sproutRoom);
		}
		public void GenerateTraitRichRoom(int i, int traitId)
		{
			/*room[i,j] = new Room();
			bool TouchesRoom=false;
			int debugI=0;
			if(HitChance(trait[traitId].destroyedChance)) room[i,j].isDestroyed = true;
			if(HitChance(25)) room[i,j].wallState = 0;
			do
			{
			    TouchesRoom=false;
				debugI++;
				if(j==0 || j==roomNum-1) room[i,j].isDestroyed = true;
				//pirmas aukstas
				if(i==0)
				{
					//jei nevienas nesukurtas
					if(j==0)
					{
						room[i,j].GenerateRoom(trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH);
					}
					//iprastas kambariu kurimas
					else
					{
						if(HitChance(steepness))
						{
							if(HitChance(50)) room[i,j].GenerateUnder(room[i, j-1], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms);
							else room[i,j].GenerateOnTopOf(room[i, j-1], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms);
						}
						else
						{
							room[i,j].GenerateRightTo(room[i, j-1], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms*2, 5, 25);
						}
						graph[GetRoomFullId(i, j), GetRoomFullId(i, j-1)]=true;
					}
				}
				//kiti aukstai
				else
				{
					//jei ne pirmo auksto pirmas kambarys
					if(j==0)
					{
						findLowestIdInFloor(i-1);
						//replaced from findLowestIdInFloor;
						lowestId=WorldGen.genRand.Next(roomNum);
						room[i,j].GenerateUnder(room[i-1, lowestId], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms);
						graph[GetRoomFullId(i, j), GetRoomFullId(i-1, lowestId)]=true;
						pickedCenter=WorldGen.genRand.Next(roomNum);
					}
					//iprastas kambariu kurimas
					else
					{
						if(HitChance(steepness))
						{
							if(HitChance(50)) room[i,j].GenerateUnder(room[i, j-1], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms);
							else room[i,j].GenerateOnTopOf(room[i, j-1], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms);
							graph[GetRoomFullId(i, j), GetRoomFullId(i, j-1)]=true;
						}
						else
						{
							if(j<pickedCenter)
							{
								room[i,j].GenerateRightTo(room[i, j-1], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms, 5, 25);
								graph[GetRoomFullId(i, j), GetRoomFullId(i, j-1)]=true;
							}
							else if(j==pickedCenter)
                            {
                                room[i,j].GenerateLeftTo(room[i, 0], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms, 5, 25);
                                graph[GetRoomFullId(i, j), GetRoomFullId(i, 0)]=true;
                            }
                            else
                            {
                                room[i,j].GenerateLeftTo(room[i, j-1], trait[traitId].minW, trait[traitId].maxW, trait[traitId].minH, trait[traitId].maxH, trait[traitId].maxDistBeetweenRooms, 5, 25);
                                graph[GetRoomFullId(i, j), GetRoomFullId(i, j-1)]=true;
							}
						}
					}
				}
				//tikrinama ar kambariia lieciasi
				for(int m=0; m<=i; m++)
				{
					for(int n=0; n<j; n++)
						if(room[i,j].TouchesRoom(room[m,n]))
						{
							TouchesRoom=true;
							break;
						}
					if (TouchesRoom) break;
				}
			}
			while(TouchesRoom && debugI<10);*/
		}
		//}
		//{CORRIDOR BUILDING METHODS
		public void GenerateCorridors()
		{
			corridor = new Room[graph.Count() * 2];
			while (graph.Next())
			{
				bool roomX;//vertikalus koridorius
				bool roomY;//hotizontalus koridorius

				roomX = room[graph.room1].IsLeftTo(room[graph.room2]) || room[graph.room2].IsLeftTo(room[graph.room1]);
				roomY = room[graph.room1].IsBelowTo(room[graph.room2]) || room[graph.room2].IsBelowTo(room[graph.room1]);

				if (roomX && roomY)
				{
					//vertikalus koridorius
					corridor[CorridorNum] = new Room();
					corridor[CorridorNum].isDestroyed = true;
					corridor[CorridorNum].GenerateBetweenX(room[graph.room1], room[graph.room2], corridorSize);
					corridor[CorridorNum].AddLength(room[graph.room1], room[graph.room2], 15);
					CorridorNum++;

					//hotizontalus koridorius
					corridor[CorridorNum] = new Room();
					corridor[CorridorNum].isDestroyed = true;
					corridor[CorridorNum].isBridged = true;
					if (room[graph.room1].IsBelowTo(room[graph.room2])) corridor[CorridorNum].GenerateBetweenY(room[graph.room1], corridor[CorridorNum - 1], corridorSize);
					else corridor[CorridorNum].GenerateBetweenY(room[graph.room2], corridor[CorridorNum - 1], corridorSize);
					if (corridor[CorridorNum].h > 70 || corridor[CorridorNum - 1].w > 70)
					{
						corridor[CorridorNum].isFake = true;
						corridor[CorridorNum - 1].isFake = true;
					}
					CorridorNum++;
				}
				else if (roomX)
				{
					corridor[CorridorNum] = new Room();
					corridor[CorridorNum].isDestroyed = true;
					corridor[CorridorNum].GenerateBetweenX(room[graph.room1], room[graph.room2], corridorSize);
					if (corridor[CorridorNum].w > 70) corridor[CorridorNum].isFake = true;
					CorridorNum++;
				}
				else if (roomY)
				{
					corridor[CorridorNum] = new Room();
					corridor[CorridorNum].isDestroyed = true;
					corridor[CorridorNum].isBridged = true;
					corridor[CorridorNum].GenerateBetweenY(room[graph.room1], room[graph.room2], corridorSize);
					if (corridor[CorridorNum].h > 70) corridor[CorridorNum].isFake = true;
					CorridorNum++;
				}
			}
		}
		//}
		//{OFFSET METHODS
		public void DetermineSize()
		{
			for (int i = 0; i < room.Length; i++)
			{
				if (room[i].x < dungeonSizeX1) dungeonSizeX1 = room[i].x;
				if (room[i].y < dungeonSizeY1) dungeonSizeY1 = room[i].y;
				if (room[i].x + room[i].w > dungeonSizeX2) dungeonSizeX2 = room[i].x + room[i].w;
				if (room[i].y + room[i].h > dungeonSizeY2) dungeonSizeY2 = room[i].y + room[i].h;
			}
			for (int i = 0; i < CorridorNum; i++)
			{
				if (corridor[i].x < dungeonSizeX1) dungeonSizeX1 = corridor[i].x;
				if (corridor[i].y < dungeonSizeY1) dungeonSizeY1 = corridor[i].x;
				if (corridor[i].x + corridor[i].w > dungeonSizeX2) dungeonSizeX2 = corridor[i].x + corridor[i].w;
				if (corridor[i].y + corridor[i].h > dungeonSizeY2) dungeonSizeY2 = corridor[i].y + corridor[i].h;
			}
		}
		public void FixRoomPositions()
		{
			for (int i = 0; i < room.Length; i++)
			{
				room[i].x -= dungeonSizeX1;
				room[i].y -= dungeonSizeY1;
			}
			for (int i = 0; i < CorridorNum; i++)
			{
				corridor[i].x -= dungeonSizeX1;
				corridor[i].y -= dungeonSizeY1;
			}
			dungeonSizeX2 = dungeonSizeX2 - dungeonSizeX1 + sizeAddX;
			dungeonSizeY2 = dungeonSizeY2 - dungeonSizeY1 + sizeAddY;
			dungeonSizeX1 = 0 - sizeAddX;
			dungeonSizeY1 = 0 - sizeAddY;
		}
		public void GenerateOffsetBeach()
		{
			int side;//=WorldGen.genRand.Next(2);
			if (WorldGen.dungeonX > Main.maxTilesX / 2) side = 0;
			else side = 1;
			int oceanLevel = -1;
			int oceanEndX = -1;
			if (side == 0)
			{
				//find ocean level
				for (int i = 0; i <= Main.rockLayer; i++)
				{
					if (Main.tile[0, i].liquid == 255)
					{
						oceanLevel = i;
						break;
					}
				}
				//find ocean size
				for (int i = 0; i < Main.maxTilesX / 2; i++)
				{
					if (Main.tile[i, oceanLevel].liquid != 255)
					{
						oceanEndX = i;
						break;
					}
				}
				offsetX = WorldGen.genRand.Next(oceanEndX / 10, oceanEndX - 30);
			}
			else if (side == 1)
			{
				//find ocean level
				for (int i = 0; i <= Main.rockLayer; i++)
				{
					if (Main.tile[Main.maxTilesX - 1, i].liquid == 255)
					{
						oceanLevel = i;
						break;
					}
				}
				//find ocean size
				for (int i = Main.maxTilesX - 1; i > Main.maxTilesX / 2; i--)
				{
					if (Main.tile[i, oceanLevel].liquid != 255)
					{
						oceanEndX = i;
						break;
					}
				}
				int oceanSize = Main.maxTilesX - oceanEndX;
				offsetX = WorldGen.genRand.Next(oceanEndX + 30, oceanEndX + oceanSize - oceanSize / 10);
			}
			//find ocean bootom
			for (int i = oceanLevel; i < Main.rockLayer; i++)
			{
				if (Main.tile[offsetX, i].type == 53)
				{
					offsetY = i - 5;
					break;
				}
			}
			if (DungeonWorld.debugingOcean)
			{
				DungeonWorld.spawnTileX = oceanEndX;
				DungeonWorld.spawnTileY = oceanLevel - 2;
			}
			if (oceanLevel == Main.rockLayer) isOk = false;
		}
		public void GenerateOffset(int minX, int maxX, int minY, int maxY)
		{
			offsetX = WorldGen.genRand.Next(minX, maxX);
			offsetY = WorldGen.genRand.Next(minY, maxY);
		}
		public void GenerateOffset(int maxX, int maxY)
		{
			offsetX = maxX;
			offsetY = maxY;
		}
		public bool OffsetFits()
		{
			for (int i = offsetX + dungeonSizeX1; i <= offsetX + dungeonSizeX2; i++)
				for (int j = offsetY + dungeonSizeY1; j <= offsetY + dungeonSizeY2; j++)
				{
					//jei nuejo i sona tada offset netinka
					if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) return false;
					//jei rastas dungeon tile arba mushroom biome tada offset netinka
					if (Main.tile[i, j].type == 41//dungeon brick
|| Main.tile[i, j].type == 43//dungeon brick
|| Main.tile[i, j].type == 44//dungeon brick
|| Main.tile[i, j].type == 57//underworld
|| Main.tile[i, j].type == 225//bees?
|| Main.tile[i, j].type == 229//bees?
|| Main.tile[i, j].type == 226)//jungle temple?
							   //|| Main.tile[i,j].wall==15)//jungle
							   //|| AmountOfTilesFound(59, 200))
							   //|| Main.tile[i,j].type==70//mushroom world
							   //|| Main.tile[i,j].type==71//mushroom world
							   //|| Main.tile[i,j].type==72)//mushroom world
					{
						//Log.WriteLine("Main.tile[i,j].type", Main.tile[i,j].type);
						return false;
					}
				}
			return true;
		}
		public bool AmountOfTilesFound(byte tile, int minTileNum)
		{
			int n = 0;
			for (int i = offsetX + dungeonSizeX1; i <= offsetX + dungeonSizeX2; i += 10)
				for (int j = offsetY + dungeonSizeY1; j <= offsetY + dungeonSizeY2; j += 10)
				{
					if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) continue;
					if (Main.tile[i, j].type == tile)
					{
						if (n++ > minTileNum) return true;
					}
				}
			return false;
		}
		public bool TouchesDungeon(Dungeon dungeon)
		{
			if (!dungeon.isOk) return false;
			bool xAxis;
			bool yAxis;
			xAxis = dungeon.offsetX + dungeon.dungeonSizeX1 < offsetX + dungeonSizeX1 && offsetX + dungeonSizeX1 < dungeon.offsetX + dungeon.dungeonSizeX2
				|| dungeon.offsetX + dungeon.dungeonSizeX1 < offsetX + dungeonSizeX2 && offsetX + dungeonSizeX2 < dungeon.offsetX + dungeon.dungeonSizeX2;
			yAxis = dungeon.offsetY + dungeon.dungeonSizeY1 < offsetY + dungeonSizeY1 && offsetY + dungeonSizeY1 < dungeon.offsetY + dungeon.dungeonSizeY2
				|| dungeon.offsetY + dungeon.dungeonSizeY1 < offsetY + dungeonSizeY2 && offsetY + dungeonSizeY2 < dungeon.offsetY + dungeon.dungeonSizeY2;
			bool flag = xAxis && yAxis;
			return (flag);
		}
		//}
		//{ANALIZE
		public void Analize()
		{
			for (int i = 0; i < room.Length; i++)
			{
				int prec = room[i].CouldBeDestroyedBy(offsetX, offsetY);
				if (prec > 45 && prec < 50)
				{
					room[i].isDestroyed = true;
					/*for(int m=0; m<floorNum; m++)
                        for(int n=0; n<roomNum; n++)
                        {
                            if(m==i && n==j) continue;
                            bool destroy = room[i,j].IsNear(room[m,n], 5);
                            if(destroy)room[m,n].isDestroyed = true;
                        }*/
				}
			}
		}
		public bool IsInDungeon(int x, int y)
		{
			for (int i = 0; i < room.Length; i++)
			{
				if (room[i].IsInRoom(x, y, offsetX, offsetY)) return true;
			}
			for (int i = 0; i < CorridorNum; i++)
			{
				if (corridor[i].IsInRoom(x, y, offsetX, offsetY)) return true;
			}
			return false;
		}
		//}
		//{DUNGEON DRAWING METHODS
		//kambarys pilnai uzpildomas blokais
		public void Fill()
		{
			if (!isOk) return;
			for (int i = 0; i < room.Length; i++)
			{
				room[i].FillRoom(type, wall, offsetX, offsetY);
			}
			for (int i = 0; i < CorridorNum; i++)
			{
				corridor[i].FillRoom(type, wall, offsetX, offsetY);
			}
		}
		//kambario vidurys iskarvinamas
		public void Carve()
		{
			if (!isOk) return;
			for (int i = 0; i < room.Length; i++)
			{
				room[i].CarveRoom(offsetX, offsetY);
			}
			for (int i = 0; i < CorridorNum; i++)
			{
				corridor[i].CarveRoom(offsetX, offsetY);
			}
		}
		public void FillWithChests()
		{
			if (!isOk) return;
			for (int i = 0; i < room.Length; i++)
			{
				room[i].FillWithChests(offsetX, offsetY);
			}
		}
		public void FillWithBridges()
		{
			if (!isOk) return;
			for (int i = 0; i < room.Length; i++)
			{
				room[i].FillWithBridges(offsetX, offsetY);
			}
			for (int i = 0; i < CorridorNum; i++)
			{
				corridor[i].FillWithBridges(offsetX, offsetY);
			}
		}
		public void FillWithFurniture()
		{
			if (!isOk) return;
			for (int i = 0; i < room.Length; i++)
			{
				room[i].FillWithFurniture(offsetX, offsetY);
			}
		}
	}

	public class Trait
	{
		public int style = 0;
		public int maxH = 15;
		public int minH = 6;
		public int maxW = 25;
		public int minW = 10;
		public int steepness = 50;
		public int destroyedChance = 25;
		public int maxDistBeetweenRooms = 15;
		public int maxWalkDif1 = 5;
		public int maxWalkDif2 = 20;

		//for Mutate()
		public int mutateChance = 2;
		public int mutateLimit = 2;
		public int mutated;

		//for Fix()
		public int maxHLimit = 40;
		public int minHLimit = 5;
		public int maxWLimit = 40;
		public int minWLimit = 5;
		public int[] steepnessLimit = { 0, 100 };
		public int[] destroyedChanceLimit = { 0, 100 };
		public int[] maxDistBeetweenRoomsLimit = { 0, 50 };
		public int[] corridorSizeLimit = { 4, 5 };

		public static bool HitChance(int chance)
		{
			return (WorldGen.genRand.Next(100) < chance);
		}

		public Trait(int style)
		{
			Main.statusText = ("called Trait");
			steepness = WorldGen.genRand.Next(30, 40);

			if (HitChance(80)) destroyedChance = WorldGen.genRand.Next(10, 35);
			else destroyedChance = WorldGen.genRand.Next(35, 60);

			if (HitChance(70)) maxH = WorldGen.genRand.Next(5, 15);
			else maxH = WorldGen.genRand.Next(15, 25);
			minH = WorldGen.genRand.Next(5, maxH) / 2;

			if (HitChance(70)) maxW = WorldGen.genRand.Next(10, 20);
			else maxW = WorldGen.genRand.Next(20, 30);
			minW = WorldGen.genRand.Next(10, maxW) / 2;

			maxDistBeetweenRooms = WorldGen.genRand.Next(5, 30);
			Fix();
			Main.statusText = ("end Trait");
		}
		public Trait()
		{
			Main.statusText = ("called Trait");
			steepness = WorldGen.genRand.Next(30, 40);

			if (HitChance(70)) destroyedChance = WorldGen.genRand.Next(10, 45);
			else destroyedChance = WorldGen.genRand.Next(45, 60);

			if (HitChance(70)) maxH = WorldGen.genRand.Next(5, 15);
			else maxH = WorldGen.genRand.Next(15, 25);
			minH = WorldGen.genRand.Next(5, maxH) / 2;

			if (HitChance(70)) maxW = WorldGen.genRand.Next(10, 20);
			else maxW = WorldGen.genRand.Next(20, 30);
			minW = WorldGen.genRand.Next(10, maxW) / 2;

			maxDistBeetweenRooms = WorldGen.genRand.Next(5, 30);
			Fix();
			Main.statusText = ("end Trait");
		}
		public Trait(bool exaggerate)
		{
			Main.statusText = ("called Trait");
			steepness = WorldGen.genRand.Next(25, 75);
			if (!exaggerate) destroyedChance = WorldGen.genRand.Next(10, 25);
			else destroyedChance = WorldGen.genRand.Next(25, 60);
			if (!exaggerate) maxH = WorldGen.genRand.Next(8, 15);
			else maxH = WorldGen.genRand.Next(15, 25);
			minH = WorldGen.genRand.Next(8, maxH) / 2;
			if (!exaggerate) maxW = WorldGen.genRand.Next(10, 25);
			else maxW = WorldGen.genRand.Next(25, 30);
			minW = WorldGen.genRand.Next(10, maxW) / 2;
			maxDistBeetweenRooms = WorldGen.genRand.Next(5, 20);
			Fix();
			Main.statusText = ("end Trait");
		}
		public void Mutate()
		{
			Main.statusText = ("called Mutate");
			if (mutated > mutateLimit) return;
			if (HitChance(mutateChance))
			{
				if (HitChance(50)) steepness += 5;
				else steepness -= 5;
				mutated++;
			}
			if (HitChance(mutateChance))
			{
				if (HitChance(50)) destroyedChance += 5;
				else destroyedChance -= 5;
				mutated++;
			}
			if (HitChance(mutateChance))
			{
				if (HitChance(50))
				{
					maxH += 5;
				}
				else
				{
					maxH -= 5;
					if (maxH < minH) maxH = minH;
				}
				mutated++;
			}
			if (HitChance(mutateChance))
			{
				if (HitChance(50))
				{
					maxW += 5;
					minW += 5;
				}
				else
				{
					maxW -= 5;
					if (maxW < minW) maxW = minW;
				}
				mutated++;
			}
			if (HitChance(mutateChance))
			{
				if (HitChance(50)) maxDistBeetweenRooms += 5;
				else maxDistBeetweenRooms -= 5;
				mutated++;
			}
			Fix();
			Main.statusText = ("end Mutate");
		}
		public void Fix()
		{
			Main.statusText = ("called Fix");
			if (maxH > maxHLimit) maxH = maxHLimit;
			if (minH < minHLimit) minH = minHLimit;
			if (maxW > maxWLimit) maxW = maxWLimit;
			if (minW < minWLimit) minW = minWLimit;
			if (maxH < minH) maxH = minH;
			if (minH > maxH) minH = maxH;
			if (maxW < minW) maxW = minW;
			if (minW > maxW) minW = maxW;
			if (steepness < steepnessLimit[0]) steepness = steepnessLimit[0];
			else if (steepness > steepnessLimit[1]) steepness = steepnessLimit[1];
			if (destroyedChance < destroyedChanceLimit[0]) destroyedChance = destroyedChanceLimit[0];
			else if (destroyedChance > destroyedChanceLimit[1]) destroyedChance = destroyedChanceLimit[1];
			if (maxDistBeetweenRooms < maxDistBeetweenRoomsLimit[0]) maxDistBeetweenRooms = maxDistBeetweenRoomsLimit[0];
			else if (maxDistBeetweenRooms > maxDistBeetweenRoomsLimit[1]) maxDistBeetweenRooms = maxDistBeetweenRoomsLimit[1];
			Main.statusText = ("called Fix");
		}
	}

	public class Room
	{
		//{VARS
		public int x;//active part
		public int y;//active part
		public int w;
		public int h;
		public int wallState = 1; //0 full wall, 1 destroyed, 2 no wall
		public bool isTreasureRoom = false;
		public bool isSpawnRoom = false;
		public bool isCorridor = false;
		public bool isDestroyed;
		public bool isFake;
		public bool isBridged;
		public bool isFlooded = false;
		public bool isAroundSand = false;
		public bool canConnectBetweenFloors = true;
		//}
		//{ROOM COMPARING METHODS
		//object is in right to room
		public bool IsRightTo(Room room)
		{
			if (room.x + room.w <= x) return true;
			return false;
		}
		public bool IsLeftTo(Room room)
		{
			if (x + w <= room.x) return true;
			return false;
		}
		public bool IsBelowTo(Room room)
		{
			if (room.y + room.h <= y) return true;
			return false;
		}
		public bool FundationHigherThen(Room room)
		{
			if (y + h <= room.y + room.h) return true;
			return false;
		}
		public bool RightWallFurtherThen(Room room)
		{
			if (x + w >= room.x + room.w) return true;
			return false;
		}
		public bool LeftWallFurtherThen(Room room)
		{
			if (x <= room.x) return true;
			return false;
		}
		public bool TouchesRoom(Room room)
		{
			bool xAxis;
			bool yAxis;
			xAxis = room.x < x && x < room.x + room.w
			|| room.x < x + w && x + w < room.x + room.w;
			yAxis = room.y < y && y < room.y + room.h
			|| room.y < y + h && y + h < room.y + room.h;
			return (xAxis && yAxis);
		}
		public bool IsNear(Room room, int maxDist = 10)
		{
			bool nearByX;
			bool nearByY;
			nearByX = x + w < room.x - maxDist || room.x + room.w < x - maxDist;
			nearByY = y + h < room.y - maxDist || room.y + room.h < y - maxDist;
			return (nearByX && nearByY);
		}
		public int CouldBeDestroyedBy(int offsetX, int offsetY, int wallSize = 8)
		{
			int destroyedTiles = 0;
			int tileCount = 0;
			for (int i = x + offsetX - wallSize; i < x + w + offsetX + wallSize; i++)
			{
				if (x + offsetX < i && i < x + offsetX + w) continue;
				for (int j = y + offsetY - wallSize; j < y + h + offsetY + wallSize; j++)
				{
					//prieiti prie kito x ir y jei dabartiniai uz mapo ribu
					if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) continue;
					if (y + offsetY < j && j < y + offsetY + h) continue;
					if (!Main.tile[i, j].active()) destroyedTiles++;
					tileCount++;
				}
			}
			return ((int)(destroyedTiles / (float)tileCount * 100));
		}
		public bool IsInRoom(int posX, int posY, int offsetX, int offsetY)
		{
			bool inX = posX >= x + offsetX - 5 && posX <= x + w + offsetX + 5;
			bool inY = posY >= y + offsetY - 5 && posY <= y + h + offsetY + 5;
			return (inX && inY);
		}
		//}
		//{ROOM GENERATING METHODS
		public void GenerateRoom(int minW, int maxW, int minH, int maxH, int X = 0, int Y = 0)
		{
			x = X;
			y = Y;
			w = WorldGen.genRand.Next(minW, maxW);
			h = WorldGen.genRand.Next(minH, maxH);
		}

		public void GenerateRightTo(Room room, Trait trait)
		{
			//generuojamas platformos skirtumas
			int maxWalkDif;
			if (WorldGen.genRand.Next(0, 2) == 0) maxWalkDif = trait.maxWalkDif2;
			else maxWalkDif = trait.maxWalkDif1;
			int WalkDif = WorldGen.genRand.Next(maxWalkDif / 2, maxWalkDif);
			int i = WorldGen.genRand.Next(3);
			if (i == 0) WalkDif *= 1;
			else if (i == 1) WalkDif *= -1;
			else WalkDif *= 0;

			h = WorldGen.genRand.Next(trait.minH, trait.maxH);
			y = room.h - h + room.y + WalkDif;
			x = room.x + room.w + WorldGen.genRand.Next(trait.maxDistBeetweenRooms);
			//if(x-2 < room.x + room.w) x=room.x + room.w;
			w = WorldGen.genRand.Next(trait.minW, trait.maxW);
		}

		public void GenerateLeftTo(Room room, Trait trait)
		{
			//generuojamas platformos skirtumas
			int maxWalkDif;
			if (WorldGen.genRand.Next(0, 2) == 0) maxWalkDif = trait.maxWalkDif2;
			else maxWalkDif = trait.maxWalkDif1;
			int WalkDif = WorldGen.genRand.Next(maxWalkDif / 2, maxWalkDif);
			int i = WorldGen.genRand.Next(3);
			if (i == 0) WalkDif *= 1;
			else if (i == 1) WalkDif *= -1;
			else WalkDif *= 0;

			h = WorldGen.genRand.Next(trait.minH, trait.maxH);
			y = room.h - h + room.y + WalkDif;
			w = WorldGen.genRand.Next(trait.minW, trait.maxW);
			x = room.x - WorldGen.genRand.Next(trait.maxDistBeetweenRooms) - w;
			//if(room.x-2 < x + w) w+=2;
		}

		public void GenerateBetweenX(Room room1, Room room2, int newH = 3)
		{
			// kuris kurioje puseje
			if (room1.IsLeftTo(room2))//room1.x<room2.x)
			{
				x = room1.x + room1.w - 1;
				w = room2.x - (room1.x + room1.w);
			}
			else
			{
				x = room2.x + room2.w - 1;
				w = room1.x - (room2.x + room2.w);
			}
			h = newH;
			//kurio pagrindas auksciau
			//jei room1 y+h mazesnis uz room2 y+h (auksciau)
			if (room1.FundationHigherThen(room2))
			{
				y = room1.h - h + room1.y;
			}
			else
			{
				y = room2.h - h + room2.y;
			}
		}

		public void AddLength(Room room1, Room room2, int add)
		{
			int add2 = WorldGen.genRand.Next(add) + 5;

			if (room1.IsLeftTo(room2))//room1.x<room2.x)
			{
				if (room1.y < room2.y)
				{
					w += add2;
				}
				else
				{
					x -= add2;
					w += add2;
				}
			}
			//i desine
			else if (room2.IsLeftTo(room1))
			{
				if (room1.y < room2.y)
				{
					x -= add2;
					w += add2;
				}
				else
				{
					w += add2;
				}
			}
		}

		public void GenerateUnder(Room room, Trait trait)
		{
			y = room.y + room.h + WorldGen.genRand.Next(trait.maxDistBeetweenRooms);
			if (y - 2 < room.y + room.h) y = room.y + room.h;
			h = WorldGen.genRand.Next(trait.minH, trait.maxH);
			w = WorldGen.genRand.Next(trait.minW, trait.maxW);
			x = WorldGen.genRand.Next(room.x - w - trait.maxDistBeetweenRooms, room.x + room.w + trait.maxDistBeetweenRooms);
		}

		public void GenerateUnderTouch(Room room, int minW, int maxW, int minH, int maxH)
		{
			y = room.y + room.h;
			h = WorldGen.genRand.Next(minH, maxH);
			if (room.y - 2 < y + h) h += 2;
			w = WorldGen.genRand.Next(minW, maxW);
			x = WorldGen.genRand.Next(room.x - (room.w / 4), room.x + (room.w / 4));
		}

		public void GenerateBetweenY(Room room1, Room room2, int newW = 3)
		{
			if (room1.y < room2.y)
			{
				y = room1.y + room1.h - 1;
				h = room2.y - (room1.y + room1.h);
			}
			else
			{
				y = room2.y + room2.h - 1;
				h = room1.y - (room2.y + room2.h);
			}
			w = newW;
			if (room2.RightWallFurtherThen(room1))//room1.x+room1.w < room2.x+room2.w)
			{
				x = room1.x + room1.w - w;
				//random judinamas x po pagrindiniu pagrindu
				if (room1.LeftWallFurtherThen(room2))//room1.x<room2.x) case1
				{
					//x-=WorldGen.genRand.Next(room2.w - 3 - (room2.w-(room1.x-room2.x+room1.w)));
					if (room2.x < x) x = WorldGen.genRand.Next(room2.x, x);
				}
				else if (room2.LeftWallFurtherThen(room1))//case2
				{
					//x-=WorldGen.genRand.Next(room1.w-3);
					if (room1.x < x) x = WorldGen.genRand.Next(room1.x, x);
				}
			}
			else if (room1.RightWallFurtherThen(room2))
			{
				x = room2.x + room2.w - w;
				//random judinamas x po pagrindiniu pagrindu
				if (room1.LeftWallFurtherThen(room2))
				{
					//x-=WorldGen.genRand.Next(room2.w-3);//case3
					if (room2.x < x) x = WorldGen.genRand.Next(room2.x, x);
				}
				else if (room2.LeftWallFurtherThen(room1))
				{
					//x-=WorldGen.genRand.Next(room1.w - 3 - (room1.w-(room2.x-room1.x+room2.w)));//case4
					if (room1.x < x) x = WorldGen.genRand.Next(room1.x, x);
				}
			}
		}

		//not tested
		public void GenerateOnTopOf(Room room, Trait trait)
		{
			h = WorldGen.genRand.Next(trait.minH, trait.maxH);
			y = room.y - WorldGen.genRand.Next(trait.maxDistBeetweenRooms) - h;
			w = WorldGen.genRand.Next(trait.minW, trait.maxW);
			x = WorldGen.genRand.Next(room.x - w - trait.maxDistBeetweenRooms, room.x + room.w + trait.maxDistBeetweenRooms);
		}

		public static bool HitChance(int chance)
		{
			return (WorldGen.genRand.Next(100) < chance);
		}

		//}
		//{DRAW METHODS
		public void SetAsPlayerSpawnRoom(int offsetX, int offsetY)
		{
			DungeonWorld.spawnTileX = offsetX + x + w / 2;
			DungeonWorld.spawnTileY = offsetY + y + h;
			//Main.spawnTileX = DungeonGen.spawnTileX;
			//Main.spawnTileY = DungeonGen.spawnTileY;
		}

		public void FillRoom(ushort type, ushort wall, int offsetX, int offsetY, int wallSize = 8)
		{
			if (isFake) return;
			bool lowDensWall = WorldGen.genRand.Next(5) == 1;
			for (int i = x - wallSize + offsetX; i <= x + w + wallSize + offsetX; i++)
				for (int j = y - wallSize + offsetY; j <= y + h + wallSize + offsetY; j++)
				{
					//prieiti prie kito x ir y jei dabartiniai uz mapo ribu
					if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) continue;
					bool active = true;
					if (isDestroyed)
						active =
							Main.tile[i, j].active()
							&& Main.tile[i, j].type != 5
							&& Main.tile[i, j].type != 30
							&& Main.tile[i, j].type != 53
							&& Main.tile[i, j].type != 52
							&& Main.tile[i, j].type != 51
							&& Main.tile[i, j].type != 62
							&& Main.tile[i, j].type != 72;
					if (active)
					{
						Main.tile[i, j].active(true);
						Main.tile[i, j].type = type;
					}

					//avoid background wall outside box
					if (i != x - wallSize - 1 + offsetX && i != i + w + wallSize + 1 + offsetX && j != y - wallSize - 1 + offsetY && j != y + h + wallSize + 1 + offsetY)
					{
						if (wallState == 0) Main.tile[i, j].wall = wall;
						else if (wallState == 1)
						{
							if (lowDensWall)
							{
								if (HitChance(20)) Main.tile[i, j].wall = wall;
							}
							else
							{
								if (HitChance(50)) Main.tile[i, j].wall = wall;
							}
						}
					}
				}
			if (isAroundSand)
				for (int i = x - wallSize + offsetX - 50; i <= x + w + wallSize + offsetX + 50; i++)
					for (int j = y - wallSize + offsetY - 50; j <= y + h + wallSize + offsetY + 50; j++)
					{
						if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) continue;
						if (!Main.tile[i, j].active())
						{
							WorldGen.PlaceTile(i, j, 53, true, true);//sand
						}
					}
		}

		public void CarveRoom(int offsetX, int offsetY)
		{
			if (isFake) return;
			bool placeCandle = HitChance(10);
			bool candleIsPlaced = false;
			for (int i = x + offsetX; i <= x + w + offsetX; i++)
				for (int j = y + offsetY; j <= y + h + offsetY; j++)
				{
					//prieiti prie kito x ir y jei dabartiniai uz mapo ribu
					if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) continue;
					Main.tile[i, j].active(false);
					Main.tile[i, j].slope(0);
					if (isFlooded) Main.tile[i, j].liquid = 255;
					if (j - 5 > y + offsetY && placeCandle && !candleIsPlaced)
					{
						if (HitChance(2))
						{
							WorldGen.PlaceTile(i, j, 19);
							WorldGen.PlaceTile(i, j - 1, 49, true, false, -1, 0);
							candleIsPlaced = true;
						}
					}
				}
		}

		public void FillWithOrbs(byte orb, int offsetX, int offsetY)
		{
			if (isFake) return;
			if (!isSpawnRoom) return;
			int X = offsetX + x + (w / 2);
			int Y;
			if (WorldGen.genRand.Next(5) != 1) Y = offsetY + y + h - 3;
			else Y = offsetY + y + 3;
			WorldGen.PlaceTile(X, Y, orb, true, true);
		}

		public void FillWithBridges(int offsetX, int offsetY)
		{
			if (isFake) return;
			if (!isBridged) return;
			int X = offsetX + x;
			int newY = offsetY + y;
			for (int Y = newY + 2; Y < newY + 10; Y++)
			{
				try
				{
					//jei randama patogi vieta pastatomas tiltas ir return
					//kiru atveju neradus patogios vietos ciklas pasibaigs ir metodas baigsis
					if (X - 1 < 0 || X - 1 >= Main.maxTilesX) return;
					if (X + w + 1 < 0 || X + w + 1 >= Main.maxTilesX) return;
					if (Main.tile[X - 1, Y].active() || Main.tile[X + w + 1, Y].active())
					{
						for (int i = X; i <= X + w; i++)
						{
							//prieiti prie kito x ir y jei dabartiniai uz mapo ribu
							if (i < 0 || Y < 0 || i >= Main.maxTilesX || Y >= Main.maxTilesY) continue;
							WorldGen.PlaceTile(i, Y, 19, true, false, -1, 9);//Wood Platform
						}
						return;
					}
				}
				catch { };
			}
		}

		public static int AddChestInCube(int x, int y, int w = 50, int h = 20)
		{
			for (int i = x; i <= x + w; i++)
			{
				for (int j = y; j <= y + h; j++)
				{
					//prieiti prie kito x ir y jei dabartiniai uz mapo ribu
					if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) continue;
					try
					{
						/*if(WorldGen.genRand.Next(100)<10)
						{
							if(WorldGen.AddBuriedChest(i, j, 0, false, 4)) return true;
						}
						else if(WorldGen.genRand.Next(100)<20)
						{
							if(WorldGen.AddBuriedChest(i, j, 0, false, 2)) return true;
						}
						else
						{
							if(WorldGen.AddBuriedChest(i, j, 0, false, 1)) return true;
						}*/
						if (WorldGen.AddBuriedChest(i, j, 0, false, 1))
							return (Chest.FindChest(i, j));
					}
					catch { }
				}
			}
			return -1;
		}
		public static void AddPotsInCube(int x, int y, int w = 40, int h = 0, int maxQ = 10)
		{
			for (int i = x; i <= x + w; i++)
			{
				//if(HitChance(90))
				//{
				for (int j = y; j <= y + h; j++)
				{
					//prieiti prie kito x ir y jei dabartiniai uz mapo ribu
					if (i < 0 || j < 0 || i >= Main.maxTilesX || j >= Main.maxTilesY) continue;
					try
					{
						if (WorldGen.PlacePot(i, j))
						{
							i++;
							break;
						}
					}
					catch { }
				}
				//}
			}
		}
		public void FillWithFurniture(int offsetX, int offsetY)
		{
			if (isFake) return;
			//if(isDestroyed) return;
			//if(HitChance(65)) return;
			bool catacomb = false;
			/*bool blacksmith = false;
		    bool library = false;
		    bool alchemy = false;
		    bool workshop = false;*/
			int caseNum = WorldGen.genRand.Next(0, 100);
			if (caseNum < 10) catacomb = true;
			/*else if(caseNum<70) blacksmith = true;
		    else if(caseNum<80) library = true;
		    else if(caseNum<90) alchemy = true;
		    else if(caseNum<100) workshop = true;*/
			int furnitureNum = 1;
			for (int i = 0; i < furnitureNum; i++)
			{
				int putX = x + w / furnitureNum * i + offsetX;
				int putY = y + h + offsetY;
				if (catacomb) WorldGen.PlaceTile(putX, putY, 105, true, false, -1, Utils.SelectRandom(WorldGen.genRand, 2, 4, 7, 12, 20, 21, 22, 26, 30, 34, 38));
				else
				{
					switch (Main.rand.Next(0, 2))
					{
						case 0:
							if (HitChance(40)) WorldGen.PlaceTile(putX, putY, 14, true, false, -1, 10); break;
						case 1:
							if (HitChance(40)) WorldGen.PlaceTile(putX, putY, 15, true, false, -1, 7); break;
					}
					//if (HitChance(40)) WorldGen.PlaceTile(putX + 1, putY - 2, 49, true, false, -1, 0);
					switch (Main.rand.Next(0, 2))
					{
						case 0:
							break;
						case 1:
							if (HitChance(120)) WorldGen.PlaceTile(putX, putY, (ushort)Tremor.instance.TileType("RuinAltar")); break;
					}
				}
			}
		}
		bool FirstAI = true;
		public void FillWithChests(int offsetX, int offsetY)
		{
			if (isFake) return;
			//if(isDestroyed) return;
			//if(HitChance(65)) return;
			bool catacomb = false;
			/*bool blacksmith = false;
		    bool library = false;
		    bool alchemy = false;
		    bool workshop = false;*/
			int caseNum = WorldGen.genRand.Next(0, 100);
			if (caseNum < 10) catacomb = true;
			/*else if(caseNum<70) blacksmith = true;
		    else if(caseNum<80) library = true;
		    else if(caseNum<90) alchemy = true;
		    else if(caseNum<100) workshop = true;*/
			int furnitureNum = WorldGen.genRand.Next(1, 5);
			int putX = x + w / furnitureNum + offsetX;
			int putY = y + h + offsetY;
			if (FirstAI)
			{
				FirstAI = false;
				if (HitChance(40)) WorldGen.PlaceChest(putX, putY, (ushort)Tremor.instance.TileType("RuinChest"), false, 2);
			}
		}
	}

	public class Graph
	{
		public int room1;
		public int room2;

		private int I;
		private Connection[] connection;

		public Graph(int roomNum)
		{
			connection = new Connection[roomNum * 2];
			for (int i = 0; i < connection.Length; i++)
			{
				connection[i] = new Connection();
			}
		}
		public void Connect(int r1, int r2)
		{
			for (int i = 0; i < connection.Length; i++)
			{
				if (!connection[i].connected)
				{
					connection[i].Connect(r1, r2);
					break;
				}
			}
		}
		public int Count()
		{
			int n = 0;
			for (int i = 0; i < connection.Length; i++)
				if (connection[i].connected) n++;
			return n;
		}
		public bool Next()
		{
			for (int i = I; i < connection.Length; i++)
			{
				I = i + 1;
				if (connection[i].connected)
				{
					room1 = connection[i].room1;
					room2 = connection[i].room2;
					return true;
				}
			}
			//I = 0;
			return false;
		}
	}

	public class Connection
	{
		public int room1;
		public int room2;
		public bool connected;
		public void Connect(int r1, int r2)
		{
			room1 = r1;
			room2 = r2;
			connected = true;
		}
		/*public static bool operator ==(Connection conn, bool b)
        {
            if (conn == null)
                return false;
            return conn.connected == b;
        }

        public static bool operator !=(Connection conn, bool b)
        {
            return !(conn == b);
        }*/
	}

	public class TileList
	{
		static public void PickRandom(Dungeon dungeon)
		{
			dungeon.type = 120;
			dungeon.wall = 24;
		}
	}

	public class ItemList
	{
		static public string[] lowTier = {
			"IceKey"
		};
		static public string[] highTier = {
			"Gold Coin"
		};
	}

	public class ChestManager
	{
		static public void Begin()
		{
			for (int i = 0; i < Main.chest.Length; i++)
			{
				bool isInDungeon = false;
				if (Main.chest[i] == null) continue;
				if (Main.chest[i].y < (int)(Main.rockLayer))
				{
					continue;
				}
				for (int j = 0; j < DungeonWorld.dungeon.Length; j++)
				{
					if (DungeonWorld.dungeon[j].IsInDungeon(Main.chest[i].x, Main.chest[i].y))
					{
						isInDungeon = true;
						break;
					}
				}
				int[] itemsToPlaceInGlassChestsSecondary = { Tremor.instance.ItemType("IceKey"), 73 };
				int itemsToPlaceInGlassChestsSecondaryChoice = 0;
				if (isInDungeon)
				{
					itemsToPlaceInGlassChestsSecondaryChoice = Main.rand.Next(itemsToPlaceInGlassChestsSecondary.Length);
					Main.chest[i].item[0].type = itemsToPlaceInGlassChestsSecondary[itemsToPlaceInGlassChestsSecondaryChoice];
				}
			}
		}

		public static bool HitChance(int chance)
		{
			return (WorldGen.genRand.Next(100) < chance);
		}
	}
}

