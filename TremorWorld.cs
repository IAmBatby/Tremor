using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Tremor
{
	public class TremorWorld : ModWorld
	{
		private const int saveVersion = 0;
		public static bool downedEvilCorn;
		public static bool downedRukh;
		public static bool downedSpaceWhale;
		public static bool downedTrinity;
		public static bool downedTremode;
		public static bool downedTikiTotem;
		public static bool downedStormJellyfish;
		public static bool downedCyberKing;
		public static bool downedHeaterofWorlds;
		public static bool downedFrostKing;
		public static bool downedDarkEmperor;
		public static bool downedPixieQueen;
		public static bool downedAlchemaster;
		public static bool downedBrutallisk;
		public static bool downedParadoxTitan;
		public static bool downedCogLord;
		public static bool downedWallofShadow;
		public static bool downedMotherboard;
		public static bool downedFungusBeetle;
		public static bool downedAncientDragon;
		public static bool downedAndas;
		public static bool DownedNovaPillar;
		public static bool downedWallOfShadow;

		public override void Initialize()
		{
			downedEvilCorn = false;
			downedRukh = false;
			downedSpaceWhale = false;
			downedTrinity = false;
			downedTremode = false;
			downedTikiTotem = false;
			downedStormJellyfish = false;
			downedCyberKing = false;
			downedHeaterofWorlds = false;
			downedFrostKing = false;
			downedDarkEmperor = false;
			downedPixieQueen = false;
			downedAlchemaster = false;
			downedBrutallisk = false;
			downedParadoxTitan = false;
			downedCogLord = false;
			downedWallofShadow = false;
			downedMotherboard = false;
			downedFungusBeetle = false;
			downedAncientDragon = false;
			DownedNovaPillar = false;
			downedAndas = false;
			downedWallOfShadow = false;
		}

		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedEvilCorn) downed.Add("evilCorn");
			if (downedRukh) downed.Add("rukh");
			if (downedSpaceWhale) downed.Add("spaceWhale");
			if (downedTrinity) downed.Add("trinity");
			if (downedTremode) downed.Add("tremode");
			if (downedTikiTotem) downed.Add("tikiTotem");
			if (downedStormJellyfish) downed.Add("stormJellyfish");
			if (downedCyberKing) downed.Add("cyberKing");
			if (downedHeaterofWorlds) downed.Add("heaterofWorlds");
			if (downedFrostKing) downed.Add("frostKing");
			if (downedDarkEmperor) downed.Add("darkEmperor");
			if (downedPixieQueen) downed.Add("pixieQueen");
			if (downedAlchemaster) downed.Add("alchemaster");
			if (downedBrutallisk) downed.Add("brutallisk");
			if (downedParadoxTitan) downed.Add("paradoxTitan");
			if (downedCogLord) downed.Add("cogLord");
			if (downedWallofShadow) downed.Add("wallofShadow");
			if (downedMotherboard) downed.Add("motherboard");
			if (downedFungusBeetle) downed.Add("fungusBeetle");
			if (downedAncientDragon) downed.Add("ancientDragon");
			if (downedAndas) downed.Add("andas");
			if (downedWallOfShadow) downed.Add("wallOfShadow");

			return new TagCompound {
				{"downed", downed}
			};


			var Downed = new List<string>();
			if (DownedNovaPillar) Downed.Add("novaPillar");
			return new TagCompound {
				{"Downed", Downed}
			};
		}

		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedEvilCorn = downed.Contains("evilCorn");
			downedRukh = downed.Contains("rukh");
			downedSpaceWhale = downed.Contains("spaceWhale");
			downedTrinity = downed.Contains("trinity");
			downedTremode = downed.Contains("tremode");
			downedTikiTotem = downed.Contains("tikiTotem");
			downedStormJellyfish = downed.Contains("stormJellyfish");
			downedCyberKing = downed.Contains("cyberKing");
			downedHeaterofWorlds = downed.Contains("heaterofWorlds");
			downedFrostKing = downed.Contains("frostKing");
			downedDarkEmperor = downed.Contains("darkEmperor");
			downedPixieQueen = downed.Contains("pixieQueen");
			downedAlchemaster = downed.Contains("alchemaster");
			downedBrutallisk = downed.Contains("brutallisk");
			downedParadoxTitan = downed.Contains("paradoxTitan");
			downedCogLord = downed.Contains("cogLord");
			downedWallofShadow = downed.Contains("wallofShadow");
			downedMotherboard = downed.Contains("motherboard");
			downedFungusBeetle = downed.Contains("fungusBeetle");
			downedAncientDragon = downed.Contains("ancientDragon");
			downedAndas = downed.Contains("andas");
			downedWallOfShadow = downed.Contains("wallOfShadow");

			var Downed = tag.GetList<string>("Downed");
			DownedNovaPillar = Downed.Contains("novaPillar");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedEvilCorn = flags[0];
				downedRukh = flags[1];
				downedSpaceWhale = flags[2];
				downedTrinity = flags[3];
				downedTremode = flags[4];
				downedTikiTotem = flags[5];
				downedStormJellyfish = flags[6];
				downedCyberKing = flags[7];
				downedHeaterofWorlds = flags[8];
				downedFrostKing = flags[9];
				downedDarkEmperor = flags[10];
				downedPixieQueen = flags[11];
				downedAlchemaster = flags[12];
				downedBrutallisk = flags[13];
				downedParadoxTitan = flags[14];
				downedCogLord = flags[15];
				downedWallofShadow = flags[16];
				downedMotherboard = flags[17];
				downedFungusBeetle = flags[18];
				downedAncientDragon = flags[19];
				DownedNovaPillar = flags[20];
				downedAndas = flags[21];
				downedWallOfShadow = flags[22];
			}
			else
			{
				ErrorLogger.Log("ExampleMod: Unknown loadVersion: " + loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags1 = new BitsByte();
			flags1[0] = downedEvilCorn;
			flags1[1] = downedRukh;
			flags1[2] = downedSpaceWhale;
			flags1[3] = downedTrinity;
			flags1[4] = downedTremode;
			flags1[5] = downedTikiTotem;
			flags1[6] = downedStormJellyfish;
			flags1[7] = downedCyberKing;
			BitsByte flags2 = new BitsByte();
			flags2[0] = downedHeaterofWorlds;
			flags2[1] = downedFrostKing;
			flags2[2] = downedDarkEmperor;
			flags2[3] = downedPixieQueen;
			flags2[4] = downedAlchemaster;
			flags2[5] = downedBrutallisk;
			flags2[6] = downedParadoxTitan;
			flags2[7] = downedCogLord;
			BitsByte flags3 = new BitsByte();
			flags3[0] = downedWallofShadow;
			flags3[1] = downedMotherboard;
			flags3[2] = downedFungusBeetle;
			flags3[3] = downedAncientDragon;
			flags3[4] = DownedNovaPillar;
			flags3[5] = downedAndas;
			flags3[6] = downedWallOfShadow;
			writer.Write(flags1);
			writer.Write(flags2);
			writer.Write(flags3);
		}


		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags1 = reader.ReadByte();
			BitsByte flags2 = reader.ReadByte();
			BitsByte flags3 = reader.ReadByte();
			downedEvilCorn = flags1[0];
			downedRukh = flags1[1];
			downedSpaceWhale = flags1[2];
			downedTrinity = flags1[3];
			downedTremode = flags1[4];
			downedTikiTotem = flags1[5];
			downedStormJellyfish = flags1[6];
			downedCyberKing = flags1[7];
			downedHeaterofWorlds = flags2[0];
			downedFrostKing = flags2[1];
			downedDarkEmperor = flags2[2];
			downedPixieQueen = flags2[3];
			downedAlchemaster = flags2[4];
			downedBrutallisk = flags2[5];
			downedParadoxTitan = flags2[6];
			downedCogLord = flags2[7];
			downedWallofShadow = flags3[0];
			downedMotherboard = flags3[1];
			downedFungusBeetle = flags3[2];
			downedAncientDragon = flags3[3];
			DownedNovaPillar = flags3[4];
			downedAndas = flags3[5];
			downedWallOfShadow = flags3[6];
		}

		public static int CometTiles;
		public static int GraniteTiles;
		public static int IceTiles;
		public static int RuinsTiles;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				return;
			}

			tasks.Insert(ShiniesIndex + 4, new PassLegacy("Generating argite", delegate (GenerationProgress progress)
			{
				progress.Message = "Generating argite";

				for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
				{
					int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
					int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .45f));
					WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(3, 8), (ushort)mod.TileType("ArgiteOre"));
				}
			}));

			tasks.Insert(ShiniesIndex + 8, new PassLegacy("Mod Biomes", delegate (GenerationProgress progress)
			{
				progress.Message = "Generating glacier...";
				IL_19:
				int StartPositionX = WorldGen.genRand.Next(0, Main.maxTilesX - 2);
				int StartPositionY = (int)Main.worldSurface;
				int StartX = 0;
				int StartY = 0;
				int Size = 0;
				int[] BlockNums = { 23, 25, 147, 161, 163, 164, 200, 0, 2 };
				int[] OreNums = { 6, 7, 8, 9, 221, 222, 223, 204, 166, 167, 168, 169, 107, 108, 111, 22 };
				if (Main.maxTilesX == 4200 && Main.maxTilesY == 1200)
				{
					Size = 105;
				}
				if (Main.maxTilesX == 6300 && Main.maxTilesY == 1800)
				{
					Size = 198;
				}
				if (Main.maxTilesX == 8400 && Main.maxTilesY == 2400)
				{
					Size = 270;
				}
				if (Main.tile[StartPositionX, StartPositionY].type == TileID.SnowBlock)
				{
					StartX = StartPositionX;
					StartY = StartPositionY;
					StartX = StartX - 100;
					StartY = StartY - 100;
					StartY++;
					for (int X = StartX - Size; X <= StartX + Size; X++)
					{
						for (int Y = StartY - Size; Y <= StartY + Size; Y++)
						{
							if (Vector2.Distance(new Vector2(StartX, StartY), new Vector2(X, Y)) <= Size)
							{
								if (Main.tile[X, Y].wall == 40 || Main.tile[X, Y].wall == 71)
								{
									Main.tile[X, Y].wall = (ushort)mod.WallType("IceWall");
								}
								if (Main.tile[X, Y].type == 23 || Main.tile[X, Y].type == 147 || Main.tile[X, Y].type == 161 || Main.tile[X, Y].type == 25 || Main.tile[X, Y].type == 163 || Main.tile[X, Y].type == 164 || Main.tile[X, Y].type == 200 || Main.tile[X, Y].type == 0 || Main.tile[X, Y].type == 2 || Main.tile[X, Y].type == TileID.Stone || Main.tile[X, Y].type == TileID.Sand)
								{
									Main.tile[X, Y].type = (ushort)mod.TileType("IceBlock");
								}
								if (Main.tile[X, Y].liquid == 3)
								{
									WorldGen.PlaceTile(X, Y, 162);
								}
								if (Main.tile[X, Y].type == 6 || Main.tile[X, Y].type == 7 || Main.tile[X, Y].type == 8 || Main.tile[X, Y].type == 9 || Main.tile[X, Y].type == 221 || Main.tile[X, Y].type == 222 || Main.tile[X, Y].type == 223 || Main.tile[X, Y].type == 204 || Main.tile[X, Y].type == 166 || Main.tile[X, Y].type == 167 || Main.tile[X, Y].type == 168 || Main.tile[X, Y].type == 169 || Main.tile[X, Y].type == 221 || Main.tile[X, Y].type == 107 || Main.tile[X, Y].type == 108 || Main.tile[X, Y].type == 22 || Main.tile[X, Y].type == 111 || Main.tile[X, Y].type == 123 || Main.tile[X, Y].type == 224 || Main.tile[X, Y].type == 40 || Main.tile[X, Y].type == 59)
								{
									Main.tile[X, Y].type = (ushort)mod.TileType("IceOre");
								}
							}
						}
					}
					for (int k = 0; k < 1000; k++)
					{
						int PositionX = WorldGen.genRand.Next(0, Main.maxTilesX);
						int PositionY = WorldGen.genRand.Next(0, Main.maxTilesY);
						if (Main.tile[PositionX, PositionY].type == mod.TileType("IceBlock"))
						{
							WorldGen.TileRunner(PositionX, PositionY, WorldGen.genRand.Next(2, 8), WorldGen.genRand.Next(2, 8), (ushort)mod.TileType("IceOre"), false, 0f, 0f, false, true);
						}
					}
					for (int k = 0; k < Main.maxTilesX; k++)
					{
						for (int i = 0; i < Main.maxTilesY; i++)
						{
							if (Main.tile[k, i].type == mod.TileType("IceBlock"))
							{
								if (Main.tile[k + 1, i].active() && Main.tile[k, i - 1].active() && Main.tile[k - 1, i].active() && Main.tile[k, i + 1].active())
								{
								}
								else
								{
									Main.tile[k, i].type = (ushort)mod.TileType("VeryVeryIce");
								}
							}
						}
					}

					while (!Main.tile[StartX, StartY].active() && StartY < Main.worldSurface)
					{
						StartY++;
					}
					for (int k = 0; k < 16; k++)
					{
						for (int l = 0; l < 10; l++)
						{
							WorldGen.KillTile(StartX - k, StartY - l, false, false, true);
						}
					}
					for (int k = 0; k < 14; k++)
					{
						for (int l = 0; l < 8; l++)
						{
							WorldGen.KillWall(StartX - 1 - k, StartY - 1 - l, false);
							WorldGen.PlaceWall(StartX - 1 - k, StartY - 1 - l, (ushort)mod.WallType("DungeonWall"));
						}
					}
					for (int k = 0; k < 15; k++)
						WorldGen.PlaceTile(StartX - k, StartY, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 9; l++)
						WorldGen.PlaceTile(StartX, StartY - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 9; l++)
						WorldGen.PlaceTile(StartX - 15, StartY - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 15 + k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 5; k++)
						WorldGen.PlaceTile(StartX - 6 - k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 2, StartY - 7 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 3, StartY - 8 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 4 - k, StartY - 9, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 14, StartY - 7 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 13, StartY - 8 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 12 + k, StartY - 9, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceTile(StartX + 1, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceTile(StartX - 16, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceChest(StartX - 13, StartY - 5, (ushort)mod.TileType("IceChest"), false, 2);
					WorldGen.PlaceChest(StartX - 7, StartY - 5, (ushort)mod.TileType("IceChest"), false, 2);
					//----------------
					StartX = StartPositionX - 42;
					StartY = StartPositionY - 21;
					for (int k = 0; k < 16; k++)
					{
						for (int l = 0; l < 10; l++)
						{
							WorldGen.KillTile(StartX - k, StartY - l, false, false, true);
						}
					}
					for (int k = 0; k < 14; k++)
					{
						for (int l = 0; l < 8; l++)
						{
							WorldGen.KillWall(StartX - 1 - k, StartY - 1 - l, false);
							WorldGen.PlaceWall(StartX - 1 - k, StartY - 1 - l, (ushort)mod.WallType("DungeonWall"));
						}
					}
					for (int k = 0; k < 15; k++)
						WorldGen.PlaceTile(StartX - k, StartY, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 9; l++)
						WorldGen.PlaceTile(StartX, StartY - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 9; l++)
						WorldGen.PlaceTile(StartX - 15, StartY - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 15 + k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 5; k++)
						WorldGen.PlaceTile(StartX - 6 - k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 2, StartY - 7 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 3, StartY - 8 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 4 - k, StartY - 9, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 14, StartY - 7 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 13, StartY - 8 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 12 + k, StartY - 9, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceTile(StartX + 1, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceTile(StartX - 16, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceChest(StartX - 13, StartY - 5, (ushort)mod.TileType("IceChest"), false, 2);
					WorldGen.PlaceChest(StartX - 7, StartY - 5, (ushort)mod.TileType("IceChest"), false, 2);
					//-------------------------
					StartX = StartPositionX - 120;
					StartY = StartPositionY + 50;
					for (int k = 0; k < 16; k++)
					{
						for (int l = 0; l < 10; l++)
						{
							WorldGen.KillTile(StartX - k, StartY - l, false, false, true);
						}
					}
					for (int k = 0; k < 14; k++)
					{
						for (int l = 0; l < 8; l++)
						{
							WorldGen.KillWall(StartX - 1 - k, StartY - 1 - l, false);
							WorldGen.PlaceWall(StartX - 1 - k, StartY - 1 - l, (ushort)mod.WallType("DungeonWall"));
						}
					}
					for (int k = 0; k < 15; k++)
						WorldGen.PlaceTile(StartX - k, StartY, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 9; l++)
						WorldGen.PlaceTile(StartX, StartY - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 9; l++)
						WorldGen.PlaceTile(StartX - 15, StartY - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 15 + k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 5; k++)
						WorldGen.PlaceTile(StartX - 6 - k, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 2, StartY - 7 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 3, StartY - 8 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 4 - k, StartY - 9, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 14, StartY - 7 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int l = 0; l < 2; l++)
						WorldGen.PlaceTile(StartX - 13, StartY - 8 - l, (ushort)mod.TileType("DungeonBlock"));
					for (int k = 0; k < 3; k++)
						WorldGen.PlaceTile(StartX - 12 + k, StartY - 9, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceTile(StartX + 1, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceTile(StartX - 16, StartY - 4, (ushort)mod.TileType("DungeonBlock"));
					WorldGen.PlaceChest(StartX - 13, StartY - 5, (ushort)mod.TileType("IceChest"), false, 2);
					WorldGen.PlaceChest(StartX - 7, StartY - 5, (ushort)mod.TileType("IceChest"), false, 2);
				}
				else
					goto IL_19;
			}));

			tasks.Insert(ShiniesIndex + 10, new PassLegacy("Generating dungeon chest", delegate (GenerationProgress progress)
			{
				progress.Message = "Placing dungeon chest";

				//WorldGen.PlaceChest(Main.dungeonX, Main.dungeonY - 1, (ushort)mod.TileType("IceChest"), false, 2);
				//int chestIndex = Chest.FindChest(Main.dungeonX, Main.dungeonY - 2);
				for (int C = 0; C < 2; C++)
				{
					WorldGen.PlaceChest(Main.dungeonX + WorldGen.genRand.Next(100, 1000), Main.dungeonY + WorldGen.genRand.Next(100, 1000), (ushort)mod.TileType("IceChest"), false, 2);
					int chestIndex = Chest.FindChest(Main.dungeonX + WorldGen.genRand.Next(100, 1000), Main.dungeonY + WorldGen.genRand.Next(100, 1000));
				}
			}));
		}

		public static bool PlaceIceChest(int x, int y, ushort type = 21, bool notNearOtherChests = false, int style = 0)
		{
			int num = -1;
			TileObject toBePlaced;
			if (TileObject.CanPlace(x, y, type, style, 1, out toBePlaced, false))
			{
				bool flag = true;
				if (notNearOtherChests && Chest.NearOtherChests(x - 1, y - 1))
				{
					flag = false;
				}
				if (flag)
				{
					TileObject.Place(toBePlaced);
					num = Chest.CreateChest(toBePlaced.xCoord, toBePlaced.yCoord, -1);
				}
			}
			else
			{
				num = -1;
			}
			// if (num != -1 && Main.netMode == 1)
			// {
			//     NetMessage.SendData(34, -1, -1, "", 0, (float)x, (float)y, (float)style, 0, 0, 0);
			// }
			return true;
		}

		public override void PostWorldGen()
		{
			for (int i = 0; i < Main.maxChests; i++)
			{
				var chest = Main.chest[i];
				if (chest == null) continue;
				var tile = Main.tile[chest.x, chest.y];
				if (tile.type == TileID.Containers && (tile.frameX == 3 * 36 || tile.frameX == 4 * 36) && WorldGen.genRand.Next(4) == 1)
				{
					foreach (var item in chest.item)
					{
						if (item != null && (item.type == 934 || item.type == 857))
						{
							item.SetDefaults(mod.ItemType("HeartAmulet"));
							break;
						}
						if (item != null && (item.type == 848))
						{
							chest.item[0].SetDefaults(mod.ItemType("HeartAmulet"));
							chest.item[1].SetDefaults(ItemID.GoldBar);
							chest.item[1].stack = 5;
							break;
						}
					}
				}
			}
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("RuinChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						chest.item[0].SetDefaults(Utils.SelectRandom(WorldGen.genRand, mod.ItemType("RustySlasher"), mod.ItemType("FirebenderTome"), mod.ItemType("AntiqueStave"), mod.ItemType("Decayed")));
						chest.item[1].stack = 1;
						break;
					}
				}
			}

			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("RuinChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						chest.item[1].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.IronBar, ItemID.TinBar, ItemID.SilverBar, ItemID.CopperBar, ItemID.GoldBar, ItemID.PlatinumBar, ItemID.LeadBar, ItemID.TungstenBar, mod.ItemType("ArgiteBar"), mod.ItemType("SteelBar"), mod.ItemType("BronzeBar")));
						chest.item[1].stack = Main.rand.Next(8, 14);
						break;
					}
				}
			}

			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("RuinChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						chest.item[2].SetDefaults(3001);
						chest.item[2].stack = Main.rand.Next(4, 8);
						break;
					}
				}
			}

			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("RuinChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						chest.item[3].SetDefaults(ItemID.Rope);
						chest.item[3].stack = Main.rand.Next(50, 101);
						break;
					}
				}
			}

			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("RuinChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						chest.item[4].SetDefaults(ItemID.Bomb);
						chest.item[4].stack = Main.rand.Next(8, 15);
						break;
					}
				}
			}

			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("RuinChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						chest.item[5].SetDefaults(73);
						chest.item[5].stack = Main.rand.Next(1, 3);
						break;
					}
				}
			}
			//for (int i = 1; i < Main.rand.Next(1, 3); i++) //кол-во занятых слотов
			//{
			int[] itemsToPlaceInGlassChestsSecondary = { mod.ItemType("FrostLiquidFlask") }; //сами предметы
			int itemsToPlaceInGlassChestsSecondaryChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("IceChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						itemsToPlaceInGlassChestsSecondaryChoice = Main.rand.Next(itemsToPlaceInGlassChestsSecondary.Length);
						chest.item[1].SetDefaults(itemsToPlaceInGlassChestsSecondary[itemsToPlaceInGlassChestsSecondaryChoice]);
						chest.item[1].stack = Main.rand.Next(15, 35); //кол-во предметов с влоте

						break;
					}
				}
			}
			//}

			//for (int i = 1; i < Main.rand.Next(7, 10); i++) //тоже самое
			//{
			int[] itemsToPlaceInGlassChestsSecondary1 = { 73 };
			int itemsToPlaceInGlassChestsSecondaryChoice1 = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("IceChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						itemsToPlaceInGlassChestsSecondaryChoice1 = Main.rand.Next(itemsToPlaceInGlassChestsSecondary1.Length);
						chest.item[2].SetDefaults(itemsToPlaceInGlassChestsSecondary1[itemsToPlaceInGlassChestsSecondaryChoice1]);
						chest.item[2].stack = Main.rand.Next(10, 13);

						break;
					}
				}
			}
			//}
			//рандом. выбор предмета на 1
			int[] itemsToPlaceInGlassChests = { mod.ItemType("FrostLance"), mod.ItemType("FrozenPaxe"), mod.ItemType("FrostGuardian"), mod.ItemType("FrostWind") };
			int itemsToPlaceInGlassChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].type == mod.TileType("IceChest"))
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						itemsToPlaceInGlassChestsChoice = Main.rand.Next(itemsToPlaceInGlassChests.Length);
						chest.item[0].SetDefaults(itemsToPlaceInGlassChests[itemsToPlaceInGlassChestsChoice]);
						break;
					}
				}
			}
		}

		public static bool AddLunarRoots(int i, int j)
		{
			int k = j;
			while (k < Main.maxTilesY)
			{
				if (Main.tile[i, k].active() && Main.tileSolid[Main.tile[i, k].type])
				{
					int num = k - 1;
					if (Main.tile[i, num - 1].lava() || Main.tile[i - 1, num - 1].lava())
					{
						return false;
					}
					if (!WorldGen.EmptyTileCheck(i - 1, i, num - 1, num, -1))
					{
						return false;
					}
					if (Main.wallDungeon[Main.tile[i, num].wall])
					{
						return false;
					}
					Tile tile = Main.tile[i - 1, num + 1];
					Tile tile2 = Main.tile[i, num + 1];
					if (!tile.nactive() || !Main.tileSolid[tile.type])
					{
						return false;
					}
					if (!tile2.nactive() || !Main.tileSolid[tile2.type])
					{
						return false;
					}
					if (tile.blockType() != 0)
					{
						tile.slope(0);
						tile.halfBrick(false);
					}
					if (tile2.blockType() != 0)
					{
						tile2.slope(0);
						tile2.halfBrick(false);
					}
					Main.tile[i - 1, num - 1].active(true);
					Main.tile[i - 1, num - 1].type = (ushort)ModLoader.GetMod("Tremor").TileType("LunarRootTile");
					Main.tile[i - 1, num - 1].frameX = 0;
					Main.tile[i - 1, num - 1].frameY = 0;
					Main.tile[i, num - 1].active(true);
					Main.tile[i, num - 1].type = (ushort)ModLoader.GetMod("Tremor").TileType("LunarRootTile");
					Main.tile[i, num - 1].frameX = 18;
					Main.tile[i, num - 1].frameY = 0;
					Main.tile[i - 1, num].active(true);
					Main.tile[i - 1, num].type = (ushort)ModLoader.GetMod("Tremor").TileType("LunarRootTile");
					Main.tile[i - 1, num].frameX = 0;
					Main.tile[i - 1, num].frameY = 18;
					Main.tile[i, num].active(true);
					Main.tile[i, num].type = (ushort)ModLoader.GetMod("Tremor").TileType("LunarRootTile");
					Main.tile[i, num].frameX = 18;
					Main.tile[i, num].frameY = 18;
					return true;
				}
				k++;
			}
			return false;
		}

		public static void dropComet()
		{
			bool flag = true;
			if (Main.netMode == 1)
			{
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					flag = false;
					break;
				}
			}
			int num = 0;
			float num2 = Main.maxTilesX / 4200;
			int num3 = (int)(400f * num2);
			for (int j = 5; j < Main.maxTilesX - 5; j++)
			{
				int num4 = 5;
				while (num4 < Main.worldSurface)
				{
					if (Main.tile[j, num4].active() && Main.tile[j, num4].type == (ushort)ModLoader.GetMod("Tremor").TileType("CometiteOreTile"))
					{
						num++;
						if (num > num3)
						{
							return;
						}
					}
					num4++;
				}
			}
			float num5 = 600f;
			while (!flag)
			{
				float num6 = Main.maxTilesX * 0.08f;
				int num7 = Main.rand.Next(150, Main.maxTilesX - 150);
				while (num7 > Main.spawnTileX - num6 && num7 < Main.spawnTileX + num6)
				{
					num7 = Main.rand.Next(150, Main.maxTilesX - 150);
				}
				int k = (int)(Main.worldSurface * 0.3);
				while (k < Main.maxTilesY)
				{
					if (Main.tile[num7, k].active() && Main.tileSolid[Main.tile[num7, k].type])
					{
						int num8 = 0;
						int num9 = 15;
						for (int l = num7 - num9; l < num7 + num9; l++)
						{
							for (int m = k - num9; m < k + num9; m++)
							{
								if (WorldGen.SolidTile(l, m))
								{
									num8++;
									if (Main.tile[l, m].type == 189 || Main.tile[l, m].type == 202)
									{
										num8 -= 100;
									}
								}
								else if (Main.tile[l, m].liquid > 0)
								{
									num8--;
								}
							}
						}
						if (num8 < num5)
						{
							num5 -= 0.5f;
							break;
						}
						flag = comet(num7, k);
						if (flag)
						{
						}
						break;
					}
					k++;
				}
				if (num5 < 100f)
				{
					return;
				}
			}
		}
		public static bool comet(int i, int j)
		{
			if (i < 50 || i > Main.maxTilesX - 50)
			{
				return false;
			}
			if (j < 50 || j > Main.maxTilesY - 50)
			{
				return false;
			}
			int num = 35;
			Rectangle rectangle = new Rectangle((i - num) * 16, (j - num) * 16, num * 2 * 16, num * 2 * 16);
			for (int k = 0; k < 255; k++)
			{
				if (Main.player[k].active)
				{
					Rectangle value = new Rectangle((int)(Main.player[k].position.X + Main.player[k].width / 2 - NPC.sWidth / 2 - NPC.safeRangeX), (int)(Main.player[k].position.Y + Main.player[k].height / 2 - NPC.sHeight / 2 - NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
					if (rectangle.Intersects(value))
					{
						return false;
					}
				}
			}
			for (int l = 0; l < 200; l++)
			{
				if (Main.npc[l].active)
				{
					Rectangle value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);
					if (rectangle.Intersects(value2))
					{
						return false;
					}
				}
			}
			for (int m = i - num; m < i + num; m++)
			{
				for (int n = j - num; n < j + num; n++)
				{
					if (Main.tile[m, n].active() && Main.tile[m, n].type == 21)
					{
						return false;
					}
				}
			}
			num = WorldGen.genRand.Next(17, 23);
			for (int num2 = i - num; num2 < i + num; num2++)
			{
				for (int num3 = j - num; num3 < j + num; num3++)
				{
					if (num3 > j + Main.rand.Next(-2, 3) - 5)
					{
						float num4 = Math.Abs(i - num2);
						float num5 = Math.Abs(j - num3);
						float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
						if (num6 < num * 0.9 + Main.rand.Next(-4, 5))
						{
							if (!Main.tileSolid[Main.tile[num2, num3].type])
							{
								Main.tile[num2, num3].active(false);
							}
							Main.tile[num2, num3].type = (ushort)ModLoader.GetMod("Tremor").TileType("CometiteOreTile");
						}
					}
				}
			}
			num = WorldGen.genRand.Next(8, 14);
			for (int num7 = i - num; num7 < i + num; num7++)
			{
				for (int num8 = j - num; num8 < j + num; num8++)
				{
					if (num8 > j + Main.rand.Next(-2, 3) - 4)
					{
						float num9 = Math.Abs(i - num7);
						float num10 = Math.Abs(j - num8);
						float num11 = (float)Math.Sqrt(num9 * num9 + num10 * num10);
						if (num11 < num * 0.8 + Main.rand.Next(-3, 4))
						{
							Main.tile[num7, num8].active(false);
						}
					}
				}
			}
			num = WorldGen.genRand.Next(25, 35);
			for (int num12 = i - num; num12 < i + num; num12++)
			{
				for (int num13 = j - num; num13 < j + num; num13++)
				{
					float num14 = Math.Abs(i - num12);
					float num15 = Math.Abs(j - num13);
					float num16 = (float)Math.Sqrt(num14 * num14 + num15 * num15);
					if (num16 < num * 0.7)
					{
						if (Main.tile[num12, num13].type == 5 || Main.tile[num12, num13].type == 32 || Main.tile[num12, num13].type == 352)
						{
							WorldGen.KillTile(num12, num13, false, false, false);
						}
						Main.tile[num12, num13].liquid = 0;
					}
					if (Main.tile[num12, num13].type == (ushort)ModLoader.GetMod("Tremor").TileType("HardCometiteOreTile"))
					{
						if (!WorldGen.SolidTile(num12 - 1, num13) && !WorldGen.SolidTile(num12 + 1, num13) && !WorldGen.SolidTile(num12, num13 - 1) && !WorldGen.SolidTile(num12, num13 + 1))
						{
							Main.tile[num12, num13].active(false);
						}
						else if ((Main.tile[num12, num13].halfBrick() || Main.tile[num12 - 1, num13].topSlope()) && !WorldGen.SolidTile(num12, num13 + 1))
						{
							Main.tile[num12, num13].active(false);
						}
					}
					WorldGen.SquareTileFrame(num12, num13, true);
					WorldGen.SquareWallFrame(num12, num13, true);
				}
			}
			num = WorldGen.genRand.Next(23, 32);
			for (int num17 = i - num; num17 < i + num; num17++)
			{
				for (int num18 = j - num; num18 < j + num; num18++)
				{
					if (num18 > j + WorldGen.genRand.Next(-3, 4) - 3 && Main.tile[num17, num18].active() && Main.rand.Next(10) == 0)
					{
						float num19 = Math.Abs(i - num17);
						float num20 = Math.Abs(j - num18);
						float num21 = (float)Math.Sqrt(num19 * num19 + num20 * num20);
						if (num21 < num * 0.8)
						{
							if (Main.tile[num17, num18].type == 5 || Main.tile[num17, num18].type == 32 || Main.tile[num17, num18].type == 352)
							{
								WorldGen.KillTile(num17, num18, false, false, false);
							}
							Main.tile[num17, num18].type = (ushort)ModLoader.GetMod("Tremor").TileType("CometiteOreTile");
							WorldGen.SquareTileFrame(num17, num18, true);
						}
					}
				}
			}
			num = WorldGen.genRand.Next(30, 38);
			for (int num22 = i - num; num22 < i + num; num22++)
			{
				for (int num23 = j - num; num23 < j + num; num23++)
				{
					if (num23 > j + WorldGen.genRand.Next(-2, 3) && Main.tile[num22, num23].active() && Main.rand.Next(20) == 0)
					{
						float num24 = Math.Abs(i - num22);
						float num25 = Math.Abs(j - num23);
						float num26 = (float)Math.Sqrt(num24 * num24 + num25 * num25);
						if (num26 < num * 0.85)
						{
							if (Main.tile[num22, num23].type == 5 || Main.tile[num22, num23].type == 32 || Main.tile[num22, num23].type == 352)
							{
								WorldGen.KillTile(num22, num23, false, false, false);
							}
							Main.tile[num22, num23].type = (ushort)ModLoader.GetMod("Tremor").TileType("HardCometiteOreTile");
							WorldGen.SquareTileFrame(num22, num23, true);
						}
					}
				}
			}
			return true;
		}

		public override void ResetNearbyTileEffects()
		{
			TremorPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(mod);
			modPlayer.NovaMonolith = false;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{
			CometTiles = tileCounts[mod.TileType("CometiteOreTile")] + tileCounts[mod.TileType("HardCometiteOreTile")];
			GraniteTiles = tileCounts[368] + tileCounts[180];
			RuinsTiles = tileCounts[120];
			IceTiles = tileCounts[mod.TileType("IceBlock")] + tileCounts[mod.TileType("IceOre")] + tileCounts[mod.TileType("VeryVeryIce")] + tileCounts[mod.TileType("DungeonBlock")];
		}
	}
}
