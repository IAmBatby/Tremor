using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Tremor.Invasion;
using Tremor.NovaPillar;
using Tremor.ZombieEvent;

namespace Tremor
{
	public class Tremor : Mod
	{

		public const string wallshadow1 = "Tremor/NPCs/WallOfShadow_Head_Boss2";
		public const string wallshadow2 = "Tremor/NPCs/WallOfShadow_Head_Boss1";

		public Tremor()
		{
			Properties = new ModProperties
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

		public static void Log(object message)
		{
			ErrorLogger.Log(String.Format("[Tremor][{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), message));
		}

		public static void Log(string format, params object[] args)
		{
			ErrorLogger.Log(String.Format("[Tremor][{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), String.Format(format, args)));
		}

		private Mod mod => ModLoader.GetMod("Tremor");

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " " + Lang.GetItemNameValue(ItemType("AmethystStaff")), ItemType("AmethystStaff"), ItemType("DiamondStaff"), ItemType("RubyStaff"), ItemType("TopazStaff"), ItemType("SapphireStaff"), ItemType("AmberStaff"), ItemType("EmeraldStaff"));
			RecipeGroup.RegisterGroup("Tremor:GemStaves", group);
		}


		public override void UpdateMusic(ref int music)
		{
			if (Main.myPlayer != -1 && !Main.gameMenu)
			{
				Mod mod = ModLoader.GetMod("Tremor");
				TremorPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(mod);
				int[] NoOverride = {MusicID.Boss1, MusicID.Boss2, MusicID.Boss3, MusicID.Boss4, MusicID.Boss5,
				MusicID.LunarBoss, MusicID.PumpkinMoon, MusicID.TheTowers, MusicID.FrostMoon, MusicID.GoblinInvasion, MusicID.Eclipse, MusicID.MartianMadness,
				MusicID.PirateInvasion, GetSoundSlot(SoundType.Music, "Sounds/Music/CyberKing"), GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6"), GetSoundSlot(SoundType.Music, "Sounds/Music/Trinity"),
				GetSoundSlot(SoundType.Music, "Sounds/Music/SlimeRain"), GetSoundSlot(SoundType.Music, "Sounds/Music/EvilCorn"), GetSoundSlot(SoundType.Music, "Sounds/Music/TikiTotem"), GetSoundSlot(SoundType.Music, "Sounds/Music/CogLord"),
				GetSoundSlot(SoundType.Music, "Sounds/Music/NightOfUndead"), GetSoundSlot(SoundType.Music, "Sounds/Music/CyberWrath")};
				bool playMusic = true;
				foreach (int n in NoOverride)
				{
					if (music == n) playMusic = false;
				}
				for (int i = 0; i < Main.npc.Length; ++i)
				{
					if (Main.npc[i].boss)
					{
						playMusic = false;
					}
				}

				Player player = Main.player[Main.myPlayer];

				if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<TremorPlayer>(this).ZoneGranite && playMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Granite");
				}

				if (ZWorld.ZInvasion && playMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/NightOfUndead");
				}

				CyberWrathInvasion modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
				if (InvasionWorld.CyberWrath)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/CyberWrath");
				}

				if (Main.player[Main.myPlayer].active && NPC.AnyNPCs(NPCType("CogLord")))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/CogLord");
				}

				if (Main.player[Main.myPlayer].active && NPC.AnyNPCs(50))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6");
				}

				if (Main.player[Main.myPlayer].active && (NPC.AnyNPCs(NPCType("TikiTotem")) || NPC.AnyNPCs(NPCType("HappySoul")) || NPC.AnyNPCs(NPCType("AngerSoul")) || NPC.AnyNPCs(NPCType("IndifferenceSoul"))))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/TikiTotem");
				}

				if (Main.player[Main.myPlayer].active && NPC.AnyNPCs(NPCType("EvilCorn")))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/EvilCorn");
				}

				if (Main.player[Main.myPlayer].active && Main.invasionType == 2)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6");
				}

				if (Main.player[Main.myPlayer].active && Main.slimeRain && !NPC.AnyNPCs(50) && !Main.eclipse && playMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/SlimeRain");
				}

				if (Main.player[Main.myPlayer].active && NPC.AnyNPCs(NPCType("SoulofTruth")))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Trinity");
				}
				if (Main.player[Main.myPlayer].active && NPC.AnyNPCs(NPCType("SoulofTrust")))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Trinity");
				}
				if (Main.player[Main.myPlayer].active && NPC.AnyNPCs(NPCType("SoulofHope")))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Trinity");
				}
				if (Main.player[Main.myPlayer].active && NPC.AnyNPCs(NPCType("FrostKing")))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6");
				}
				if (Main.player[Main.myPlayer].active && NPC.AnyNPCs(NPCType("CyberKing")))
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/CyberKing");
				}


				if (Main.cloudAlpha > 0f &&
					Main.player[Main.myPlayer].position.Y <
					Main.worldSurface * 16.0 + Main.screenHeight / 2 && Main.player[Main.myPlayer].ZoneSnow && playMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Snow2");
				}

				if (player.active && player.GetModPlayer<TremorPlayer>(this).ZoneIce && !Main.gameMenu && playMusic)
				{
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/Snow2");
				}

			}
		}

		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call("AddBossWithInfo", "Rukh", 2.7f, (Func<bool>)(() => TremorWorld.downedRukh), "Use a [i:" + ItemType("DesertCrown") + "] in Desert");
				bossChecklist.Call("AddBossWithInfo", "Tiki Totem", 3.3f, (Func<bool>)(() => TremorWorld.downedTikiTotem), "Use a [i:" + ItemType("MysteriousDrum") + "] in Jungle at night after beating Eye of Cthulhu");
				bossChecklist.Call("AddBossWithInfo", "Evil Corn", 3.4f, (Func<bool>)(() => TremorWorld.downedEvilCorn), "Use a [i:" + ItemType("CursedPopcorn") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Storm Jellyfish", 3.5f, (Func<bool>)(() => TremorWorld.downedStormJellyfish), "Use a [i:" + ItemType("StormJelly") + "]");
				bossChecklist.Call("AddBossWithInfo", "Ancient Dragon", 3.6f, (Func<bool>)(() => TremorWorld.downedAncientDragon), "Use a [i:" + ItemType("RustyLantern") + "] in Ruins after pressing with RMB on Ruin Altar and getting Ruin Powers buff");
				bossChecklist.Call("AddBossWithInfo", "Fungus Beetle", 5.5f, (Func<bool>)(() => TremorWorld.downedFungusBeetle), "Use a [i:" + ItemType("MushroomCrystal") + "]");
				bossChecklist.Call("AddBossWithInfo", "Heater of Worlds", 5.6f, (Func<bool>)(() => TremorWorld.downedFungusBeetle), "Use a [i:" + ItemType("MoltenHeart") + "] in Underworld");
				bossChecklist.Call("AddBossWithInfo", "Alchemaster", 6.5f, (Func<bool>)(() => TremorWorld.downedAlchemaster), "Use a [i:" + ItemType("AncientMosaic") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Motherboard (Destroyer alt)", 8.01f, (Func<bool>)(() => TremorWorld.downedMotherboard), "Use a [i:" + ItemType("MechanicalBrain") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Pixie Queen", 9.6f, (Func<bool>)(() => TremorWorld.downedPixieQueen), "Use a [i:" + ItemType("PixieinaJar") + "] in Hallow at night");
				bossChecklist.Call("AddBossWithInfo", "Wall of Shadows", 10.7f, (Func<bool>)(() => TremorWorld.downedWallOfShadow), "Throw a [i:" + ItemType("ShadowRelic") + "] into lava in Underworld after beating Plantera and having the Dryad alive ");
				bossChecklist.Call("AddBossWithInfo", "Frost King", 10.6f, (Func<bool>)(() => TremorWorld.downedFrostKing), "Use a [i:" + ItemType("FrostCrown") + "] in Snow");
				bossChecklist.Call("AddBossWithInfo", "Cog Lord", 11.4f, (Func<bool>)(() => TremorWorld.downedCogLord), "Use a [i:" + ItemType("ArtifactEngine") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Cyber King", 11.5f, (Func<bool>)(() => TremorWorld.downedCyberKing), "Use a [i:" + ItemType("AdvancedCircuit") + "] at night to summon a Mothership which will spawn Cyber King on death");
				bossChecklist.Call("AddBossWithInfo", "Nova Pillar", 13.5f, (Func<bool>)(() => TremorWorld.DownedNovaPillar), "Kill the Lunatic Cultist outside the dungeon post-Golem");
				bossChecklist.Call("AddBossWithInfo", "The Dark Emperor", 14.4f, (Func<bool>)(() => TremorWorld.downedDarkEmperor), "Use a [i:" + ItemType("EmperorCrown") + "]");
				bossChecklist.Call("AddBossWithInfo", "Brutallisk", 14.5f, (Func<bool>)(() => TremorWorld.downedBrutallisk), "Use a [i:" + ItemType("RoyalEgg") + "] in Desert");
				bossChecklist.Call("AddBossWithInfo", "Space Whale", 14.6f, (Func<bool>)(() => TremorWorld.downedSpaceWhale), "Use a [i:" + ItemType("CosmicKrill") + "]");
				bossChecklist.Call("AddBossWithInfo", "The Trinity", 14.7f, (Func<bool>)(() => TremorWorld.downedTrinity), "Use a [i:" + ItemType("StoneofKnowledge") + "] at night");
				bossChecklist.Call("AddBossWithInfo", "Andas", 14.8f, (Func<bool>)(() => TremorWorld.downedAndas), "Use a [i:" + ItemType("InfernoSkull") + "] at Underworld");
			}
		}

		public override void Unload()
		{
			if (!Main.dedServ)
			{
				TremorGlowMask.Unload();
			}
		}


		public override void Load()
		{


			Filters.Scene["Tremor:Invasion"] = new Filter(new InvasionData("FilterMiniTower").UseColor(0.2f, 0.4f, 0.5f).UseOpacity(0.9f), EffectPriority.VeryHigh);
			SkyManager.Instance["Tremor:Invasion"] = new ZombieSky();
			Filters.Scene["Tremor:Zombie"] = new Filter(new ZombieScreenShaderData("FilterMiniTower").UseColor(1.1f, 0.3f, 0.3f).UseOpacity(0.6f), EffectPriority.VeryHigh);
			SkyManager.Instance["Tremor:Zombie"] = new ZombieSky();
			Filters.Scene["Tremor:Ice"] = new Filter(new ZombieScreenShaderData("FilterMiniTower").UseColor(0.4f, 0.8f, 1.0f).UseOpacity(0.6f), EffectPriority.VeryHigh);
			SkyManager.Instance["Tremor:Ice"] = new ZombieSky();
			Filters.Scene["Tremor:CogLord"] = new Filter(new ZombieScreenShaderData("FilterMiniTower").UseColor(0.9f, 0.5f, 0.2f).UseOpacity(0.6f), EffectPriority.VeryHigh);
			SkyManager.Instance["Tremor:CogLord"] = new ZombieSky();

			if (!Main.dedServ)
			{

				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/CogLord"), ItemType("CogLordMusicBox"),
					TileType("CogLordMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/SlimeRain"), ItemType("SlimeRainMusicBox"),
					TileType("SlimeRainMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6"), ItemType("Boss6MusicBox"),
					TileType("Boss6MusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Trinity"), ItemType("TrinityMusicBox"),
					TileType("TrinityMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/TikiTotem"), ItemType("TikiTotemMusicBox"),
					TileType("TikiTotemMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/EvilCorn"), ItemType("EvilCornMusicBox"),
					TileType("EvilCornMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/CyberKing"), ItemType("CyberKingMusicBox"),
					TileType("CyberKingMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Snow2"), ItemType("BlizzardMusicBox"),
					TileType("BlizzardMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/CyberWrath"), ItemType("ParadoxCohortMusicBox"),
					TileType("ParadoxCohortMusicBoxTile"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/NightOfUndead"), ItemType("DeathHordeMusicBox"),
					TileType("DeathHordeMusicBoxTile"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Granite"), ItemType("GraniteMusicBox"),
					TileType("GraniteMusicBox"));

				TremorGlowMask.Load();
				GameShaders.Armor.BindShader(ItemType("NovaDye"), new ArmorShaderData(Main.PixelShaderRef, "ArmorSolar")).UseColor(0.8f, 0.7f, 0.3f).UseSecondaryColor(0.8f, 0.7f, 0.3f);
				NovaSky.PlanetTexture = GetTexture("NovaPillar/NovaPlanet");
				Filters.Scene["Tremor:Nova"] = new Filter(new NovaData("FilterMiniTower").UseColor(0.8f, 0.7f, 0.3f).UseOpacity(0.82f), EffectPriority.VeryHigh);
				SkyManager.Instance["Tremor:Nova"] = new NovaSky();

				AddGlobalNPC("GlobalNPCRule", new GlobalNPCRule());

				if (ModLoader.GetLoadedMods().Contains("Elerium"))
				{
					Main.itemTexture[3601] = ModLoader.GetTexture("Tremor/Resprites/CelestialSigil2");
				}
				if (!ModLoader.GetLoadedMods().Contains("Elerium"))
				{
					Main.itemTexture[3601] = ModLoader.GetTexture("Tremor/Resprites/CelestialSigil");
				}

				Main.buffTexture[1] = ModLoader.GetTexture("Tremor/Resprites/Buff_1");
				Main.buffTexture[2] = ModLoader.GetTexture("Tremor/Resprites/Buff_2");
				Main.buffTexture[3] = ModLoader.GetTexture("Tremor/Resprites/Buff_3");
				Main.buffTexture[4] = ModLoader.GetTexture("Tremor/Resprites/Buff_4");
				Main.buffTexture[5] = ModLoader.GetTexture("Tremor/Resprites/Buff_5");
				Main.buffTexture[6] = ModLoader.GetTexture("Tremor/Resprites/Buff_6");
				Main.buffTexture[7] = ModLoader.GetTexture("Tremor/Resprites/Buff_7");
				Main.buffTexture[8] = ModLoader.GetTexture("Tremor/Resprites/Buff_8");
				Main.buffTexture[9] = ModLoader.GetTexture("Tremor/Resprites/Buff_9");
				Main.buffTexture[10] = ModLoader.GetTexture("Tremor/Resprites/Buff_10");
				Main.buffTexture[11] = ModLoader.GetTexture("Tremor/Resprites/Buff_11");
				Main.buffTexture[12] = ModLoader.GetTexture("Tremor/Resprites/Buff_12");
				Main.buffTexture[13] = ModLoader.GetTexture("Tremor/Resprites/Buff_13");
				Main.buffTexture[14] = ModLoader.GetTexture("Tremor/Resprites/Buff_14");
				Main.buffTexture[15] = ModLoader.GetTexture("Tremor/Resprites/Buff_15");
				Main.buffTexture[16] = ModLoader.GetTexture("Tremor/Resprites/Buff_16");
				Main.buffTexture[17] = ModLoader.GetTexture("Tremor/Resprites/Buff_17");
				Main.buffTexture[18] = ModLoader.GetTexture("Tremor/Resprites/Buff_18");
				Main.buffTexture[19] = ModLoader.GetTexture("Tremor/Resprites/Buff_19");
				Main.buffTexture[20] = ModLoader.GetTexture("Tremor/Resprites/Buff_20");
				Main.buffTexture[21] = ModLoader.GetTexture("Tremor/Resprites/Buff_21");
				Main.buffTexture[23] = ModLoader.GetTexture("Tremor/Resprites/Buff_23");
				Main.buffTexture[24] = ModLoader.GetTexture("Tremor/Resprites/Buff_24");
				Main.buffTexture[25] = ModLoader.GetTexture("Tremor/Resprites/Buff_25");
				Main.buffTexture[26] = ModLoader.GetTexture("Tremor/Resprites/Buff_26");
				Main.buffTexture[27] = ModLoader.GetTexture("Tremor/Resprites/Buff_27");
				Main.buffTexture[28] = ModLoader.GetTexture("Tremor/Resprites/Buff_28");
				Main.buffTexture[29] = ModLoader.GetTexture("Tremor/Resprites/Buff_29");
				Main.buffTexture[30] = ModLoader.GetTexture("Tremor/Resprites/Buff_30");
				Main.buffTexture[31] = ModLoader.GetTexture("Tremor/Resprites/Buff_31");
				Main.buffTexture[32] = ModLoader.GetTexture("Tremor/Resprites/Buff_32");
				Main.buffTexture[33] = ModLoader.GetTexture("Tremor/Resprites/Buff_33");
				Main.buffTexture[34] = ModLoader.GetTexture("Tremor/Resprites/Buff_34");
				Main.buffTexture[35] = ModLoader.GetTexture("Tremor/Resprites/Buff_35");
				Main.buffTexture[36] = ModLoader.GetTexture("Tremor/Resprites/Buff_36");
				Main.buffTexture[37] = ModLoader.GetTexture("Tremor/Resprites/Buff_37");
				Main.buffTexture[38] = ModLoader.GetTexture("Tremor/Resprites/Buff_38");
				Main.buffTexture[39] = ModLoader.GetTexture("Tremor/Resprites/Buff_39");
				Main.buffTexture[40] = ModLoader.GetTexture("Tremor/Resprites/Buff_40");
				Main.buffTexture[41] = ModLoader.GetTexture("Tremor/Resprites/Buff_41");
				Main.buffTexture[42] = ModLoader.GetTexture("Tremor/Resprites/Buff_42");
				Main.buffTexture[43] = ModLoader.GetTexture("Tremor/Resprites/Buff_43");
				Main.buffTexture[44] = ModLoader.GetTexture("Tremor/Resprites/Buff_44");
				Main.buffTexture[45] = ModLoader.GetTexture("Tremor/Resprites/Buff_45");
				Main.buffTexture[46] = ModLoader.GetTexture("Tremor/Resprites/Buff_46");
				Main.buffTexture[47] = ModLoader.GetTexture("Tremor/Resprites/Buff_47");
				Main.buffTexture[48] = ModLoader.GetTexture("Tremor/Resprites/Buff_48");
				Main.buffTexture[49] = ModLoader.GetTexture("Tremor/Resprites/Buff_49");
				Main.buffTexture[50] = ModLoader.GetTexture("Tremor/Resprites/Buff_50");
				Main.buffTexture[51] = ModLoader.GetTexture("Tremor/Resprites/Buff_51");
				Main.buffTexture[53] = ModLoader.GetTexture("Tremor/Resprites/Buff_53");
				Main.buffTexture[54] = ModLoader.GetTexture("Tremor/Resprites/Buff_54");
				Main.buffTexture[55] = ModLoader.GetTexture("Tremor/Resprites/Buff_55");
				Main.buffTexture[56] = ModLoader.GetTexture("Tremor/Resprites/Buff_56");
				Main.buffTexture[57] = ModLoader.GetTexture("Tremor/Resprites/Buff_57");
				Main.buffTexture[58] = ModLoader.GetTexture("Tremor/Resprites/Buff_58");
				Main.buffTexture[59] = ModLoader.GetTexture("Tremor/Resprites/Buff_59");
				Main.buffTexture[60] = ModLoader.GetTexture("Tremor/Resprites/Buff_60");
				Main.buffTexture[61] = ModLoader.GetTexture("Tremor/Resprites/Buff_61");
				Main.buffTexture[62] = ModLoader.GetTexture("Tremor/Resprites/Buff_62");
				Main.buffTexture[63] = ModLoader.GetTexture("Tremor/Resprites/Buff_63");
				Main.buffTexture[64] = ModLoader.GetTexture("Tremor/Resprites/Buff_64");
				Main.buffTexture[65] = ModLoader.GetTexture("Tremor/Resprites/Buff_65");
				Main.buffTexture[66] = ModLoader.GetTexture("Tremor/Resprites/Buff_66");
				Main.buffTexture[67] = ModLoader.GetTexture("Tremor/Resprites/Buff_67");
				Main.buffTexture[68] = ModLoader.GetTexture("Tremor/Resprites/Buff_68");
				Main.buffTexture[69] = ModLoader.GetTexture("Tremor/Resprites/Buff_69");
				Main.buffTexture[70] = ModLoader.GetTexture("Tremor/Resprites/Buff_70");
				Main.buffTexture[71] = ModLoader.GetTexture("Tremor/Resprites/Buff_71");
				Main.buffTexture[72] = ModLoader.GetTexture("Tremor/Resprites/Buff_72");
				Main.buffTexture[73] = ModLoader.GetTexture("Tremor/Resprites/Buff_73");
				Main.buffTexture[74] = ModLoader.GetTexture("Tremor/Resprites/Buff_74");
				Main.buffTexture[75] = ModLoader.GetTexture("Tremor/Resprites/Buff_75");
				Main.buffTexture[76] = ModLoader.GetTexture("Tremor/Resprites/Buff_76");
				Main.buffTexture[76] = ModLoader.GetTexture("Tremor/Resprites/Buff_77");
				Main.buffTexture[78] = ModLoader.GetTexture("Tremor/Resprites/Buff_78");
				Main.buffTexture[79] = ModLoader.GetTexture("Tremor/Resprites/Buff_79");
				Main.buffTexture[80] = ModLoader.GetTexture("Tremor/Resprites/Buff_80");
				Main.buffTexture[81] = ModLoader.GetTexture("Tremor/Resprites/Buff_81");
				Main.buffTexture[82] = ModLoader.GetTexture("Tremor/Resprites/Buff_82");
				Main.buffTexture[83] = ModLoader.GetTexture("Tremor/Resprites/Buff_83");
				Main.buffTexture[84] = ModLoader.GetTexture("Tremor/Resprites/Buff_84");
				Main.buffTexture[85] = ModLoader.GetTexture("Tremor/Resprites/Buff_85");
				Main.buffTexture[86] = ModLoader.GetTexture("Tremor/Resprites/Buff_86");
				Main.buffTexture[87] = ModLoader.GetTexture("Tremor/Resprites/Buff_87");
				Main.buffTexture[88] = ModLoader.GetTexture("Tremor/Resprites/Buff_88");
				Main.buffTexture[89] = ModLoader.GetTexture("Tremor/Resprites/Buff_89");
				Main.buffTexture[90] = ModLoader.GetTexture("Tremor/Resprites/Buff_90");
				Main.buffTexture[91] = ModLoader.GetTexture("Tremor/Resprites/Buff_91");
				Main.buffTexture[93] = ModLoader.GetTexture("Tremor/Resprites/Buff_93");
				Main.buffTexture[94] = ModLoader.GetTexture("Tremor/Resprites/Buff_94");
				Main.buffTexture[95] = ModLoader.GetTexture("Tremor/Resprites/Buff_95");
				Main.buffTexture[96] = ModLoader.GetTexture("Tremor/Resprites/Buff_96");
				Main.buffTexture[97] = ModLoader.GetTexture("Tremor/Resprites/Buff_97");
				Main.buffTexture[98] = ModLoader.GetTexture("Tremor/Resprites/Buff_98");
				Main.buffTexture[99] = ModLoader.GetTexture("Tremor/Resprites/Buff_99");
				Main.buffTexture[100] = ModLoader.GetTexture("Tremor/Resprites/Buff_100");
				Main.buffTexture[101] = ModLoader.GetTexture("Tremor/Resprites/Buff_101");
				Main.buffTexture[102] = ModLoader.GetTexture("Tremor/Resprites/Buff_102");
				Main.buffTexture[103] = ModLoader.GetTexture("Tremor/Resprites/Buff_103");
				Main.buffTexture[104] = ModLoader.GetTexture("Tremor/Resprites/Buff_104");
				Main.buffTexture[105] = ModLoader.GetTexture("Tremor/Resprites/Buff_105");
				Main.buffTexture[106] = ModLoader.GetTexture("Tremor/Resprites/Buff_106");
				Main.buffTexture[107] = ModLoader.GetTexture("Tremor/Resprites/Buff_107");
				Main.buffTexture[108] = ModLoader.GetTexture("Tremor/Resprites/Buff_108");
				Main.buffTexture[109] = ModLoader.GetTexture("Tremor/Resprites/Buff_109");
				Main.buffTexture[110] = ModLoader.GetTexture("Tremor/Resprites/Buff_110");
				Main.buffTexture[111] = ModLoader.GetTexture("Tremor/Resprites/Buff_111");
				Main.buffTexture[112] = ModLoader.GetTexture("Tremor/Resprites/Buff_112");
				Main.buffTexture[113] = ModLoader.GetTexture("Tremor/Resprites/Buff_113");
				Main.buffTexture[114] = ModLoader.GetTexture("Tremor/Resprites/Buff_114");
				Main.buffTexture[115] = ModLoader.GetTexture("Tremor/Resprites/Buff_115");
				Main.buffTexture[116] = ModLoader.GetTexture("Tremor/Resprites/Buff_116");
				Main.buffTexture[117] = ModLoader.GetTexture("Tremor/Resprites/Buff_117");
				Main.buffTexture[118] = ModLoader.GetTexture("Tremor/Resprites/Buff_118");
				Main.buffTexture[119] = ModLoader.GetTexture("Tremor/Resprites/Buff_119");
				Main.buffTexture[120] = ModLoader.GetTexture("Tremor/Resprites/Buff_120");
				Main.buffTexture[121] = ModLoader.GetTexture("Tremor/Resprites/Buff_121");
				Main.buffTexture[123] = ModLoader.GetTexture("Tremor/Resprites/Buff_123");
				Main.buffTexture[124] = ModLoader.GetTexture("Tremor/Resprites/Buff_124");
				Main.buffTexture[125] = ModLoader.GetTexture("Tremor/Resprites/Buff_125");
				Main.buffTexture[126] = ModLoader.GetTexture("Tremor/Resprites/Buff_126");
				Main.buffTexture[127] = ModLoader.GetTexture("Tremor/Resprites/Buff_127");
				Main.buffTexture[128] = ModLoader.GetTexture("Tremor/Resprites/Buff_128");
				Main.buffTexture[129] = ModLoader.GetTexture("Tremor/Resprites/Buff_129");
				Main.buffTexture[130] = ModLoader.GetTexture("Tremor/Resprites/Buff_130");
				Main.buffTexture[131] = ModLoader.GetTexture("Tremor/Resprites/Buff_131");
				Main.buffTexture[132] = ModLoader.GetTexture("Tremor/Resprites/Buff_132");
				Main.buffTexture[134] = ModLoader.GetTexture("Tremor/Resprites/Buff_134");
				Main.buffTexture[135] = ModLoader.GetTexture("Tremor/Resprites/Buff_135");
				Main.buffTexture[136] = ModLoader.GetTexture("Tremor/Resprites/Buff_136");
				Main.buffTexture[137] = ModLoader.GetTexture("Tremor/Resprites/Buff_137");
				Main.buffTexture[138] = ModLoader.GetTexture("Tremor/Resprites/Buff_138");
				Main.buffTexture[139] = ModLoader.GetTexture("Tremor/Resprites/Buff_139");
				Main.buffTexture[140] = ModLoader.GetTexture("Tremor/Resprites/Buff_140");
				Main.buffTexture[141] = ModLoader.GetTexture("Tremor/Resprites/Buff_141");
				Main.buffTexture[142] = ModLoader.GetTexture("Tremor/Resprites/Buff_142");
				Main.buffTexture[144] = ModLoader.GetTexture("Tremor/Resprites/Buff_144");
				Main.buffTexture[145] = ModLoader.GetTexture("Tremor/Resprites/Buff_145");
				Main.buffTexture[146] = ModLoader.GetTexture("Tremor/Resprites/Buff_146");
				Main.buffTexture[147] = ModLoader.GetTexture("Tremor/Resprites/Buff_147");
				Main.buffTexture[148] = ModLoader.GetTexture("Tremor/Resprites/Buff_148");
				Main.buffTexture[149] = ModLoader.GetTexture("Tremor/Resprites/Buff_149");
				Main.buffTexture[150] = ModLoader.GetTexture("Tremor/Resprites/Buff_150");
				Main.buffTexture[151] = ModLoader.GetTexture("Tremor/Resprites/Buff_151");
				Main.buffTexture[152] = ModLoader.GetTexture("Tremor/Resprites/Buff_152");
				Main.buffTexture[153] = ModLoader.GetTexture("Tremor/Resprites/Buff_153");
				Main.buffTexture[154] = ModLoader.GetTexture("Tremor/Resprites/Buff_154");
				Main.buffTexture[155] = ModLoader.GetTexture("Tremor/Resprites/Buff_155");
				Main.buffTexture[156] = ModLoader.GetTexture("Tremor/Resprites/Buff_156");
				Main.buffTexture[157] = ModLoader.GetTexture("Tremor/Resprites/Buff_157");
				Main.buffTexture[158] = ModLoader.GetTexture("Tremor/Resprites/Buff_158");
				Main.buffTexture[159] = ModLoader.GetTexture("Tremor/Resprites/Buff_159");
				Main.buffTexture[160] = ModLoader.GetTexture("Tremor/Resprites/Buff_160");
				Main.buffTexture[161] = ModLoader.GetTexture("Tremor/Resprites/Buff_161");
				Main.buffTexture[162] = ModLoader.GetTexture("Tremor/Resprites/Buff_162");
				Main.buffTexture[163] = ModLoader.GetTexture("Tremor/Resprites/Buff_163");
				Main.buffTexture[164] = ModLoader.GetTexture("Tremor/Resprites/Buff_164");
				Main.buffTexture[165] = ModLoader.GetTexture("Tremor/Resprites/Buff_165");
				Main.buffTexture[166] = ModLoader.GetTexture("Tremor/Resprites/Buff_166");
				Main.buffTexture[167] = ModLoader.GetTexture("Tremor/Resprites/Buff_167");
				Main.buffTexture[168] = ModLoader.GetTexture("Tremor/Resprites/Buff_168");
				Main.buffTexture[169] = ModLoader.GetTexture("Tremor/Resprites/Buff_169");
				Main.buffTexture[170] = ModLoader.GetTexture("Tremor/Resprites/Buff_170");
				Main.buffTexture[171] = ModLoader.GetTexture("Tremor/Resprites/Buff_171");
				Main.buffTexture[172] = ModLoader.GetTexture("Tremor/Resprites/Buff_172");
				Main.buffTexture[174] = ModLoader.GetTexture("Tremor/Resprites/Buff_173");
				Main.buffTexture[174] = ModLoader.GetTexture("Tremor/Resprites/Buff_174");
				Main.buffTexture[175] = ModLoader.GetTexture("Tremor/Resprites/Buff_175");
				Main.buffTexture[176] = ModLoader.GetTexture("Tremor/Resprites/Buff_176");
				Main.buffTexture[177] = ModLoader.GetTexture("Tremor/Resprites/Buff_177");
				Main.buffTexture[178] = ModLoader.GetTexture("Tremor/Resprites/Buff_178");
				Main.buffTexture[179] = ModLoader.GetTexture("Tremor/Resprites/Buff_179");
				Main.buffTexture[180] = ModLoader.GetTexture("Tremor/Resprites/Buff_180");
				Main.buffTexture[181] = ModLoader.GetTexture("Tremor/Resprites/Buff_181");
				Main.buffTexture[182] = ModLoader.GetTexture("Tremor/Resprites/Buff_182");
				Main.buffTexture[184] = ModLoader.GetTexture("Tremor/Resprites/Buff_184");
				Main.buffTexture[185] = ModLoader.GetTexture("Tremor/Resprites/Buff_185");
				Main.buffTexture[186] = ModLoader.GetTexture("Tremor/Resprites/Buff_186");
				Main.buffTexture[187] = ModLoader.GetTexture("Tremor/Resprites/Buff_187");
				Main.buffTexture[188] = ModLoader.GetTexture("Tremor/Resprites/Buff_188");
				Main.buffTexture[189] = ModLoader.GetTexture("Tremor/Resprites/Buff_189");
				Main.buffTexture[190] = ModLoader.GetTexture("Tremor/Resprites/Buff_190");

				Main.buffTexture[191] = ModLoader.GetTexture("Tremor/Resprites/Buff_191");
				Main.buffTexture[192] = ModLoader.GetTexture("Tremor/Resprites/Buff_192");
				Main.buffTexture[193] = ModLoader.GetTexture("Tremor/Resprites/Buff_193");
				Main.buffTexture[194] = ModLoader.GetTexture("Tremor/Resprites/Buff_194");
				Main.buffTexture[195] = ModLoader.GetTexture("Tremor/Resprites/Buff_195");
				Main.buffTexture[196] = ModLoader.GetTexture("Tremor/Resprites/Buff_196");
				Main.buffTexture[197] = ModLoader.GetTexture("Tremor/Resprites/Buff_197");
				Main.buffTexture[198] = ModLoader.GetTexture("Tremor/Resprites/Buff_198");
				Main.buffTexture[199] = ModLoader.GetTexture("Tremor/Resprites/Buff_199");
				Main.buffTexture[200] = ModLoader.GetTexture("Tremor/Resprites/Buff_200");
				Main.buffTexture[201] = ModLoader.GetTexture("Tremor/Resprites/Buff_201");
				Main.buffTexture[202] = ModLoader.GetTexture("Tremor/Resprites/Buff_202");
				Main.buffTexture[203] = ModLoader.GetTexture("Tremor/Resprites/Buff_203");
				Main.buffTexture[204] = ModLoader.GetTexture("Tremor/Resprites/Buff_204");
				Main.buffTexture[205] = ModLoader.GetTexture("Tremor/Resprites/Buff_205");
			}
		}

		public override void AddRecipes()
		{
			List<Tuple<int, int[]>> recipesToDelete = new List<Tuple<int, int[]>>();
			recipesToDelete.Add(new Tuple<int, int[]>(ItemID.NightsEdge, new int[] { ItemID.BloodButcherer }));
			recipesToDelete.Add(new Tuple<int, int[]>(ItemID.MechanicalWorm, new int[] { ItemID.Vertebrae }));

			recipesToDelete.Add(new Tuple<int, int[]>(3544, new int[0])); // Super Healing Potion
			recipesToDelete.Add(new Tuple<int, int[]>(3601, new int[0])); // Celestial Sigil
			recipesToDelete.Add(new Tuple<int, int[]>(3456, new int[0])); // Celestial Sigil
			recipesToDelete.Add(new Tuple<int, int[]>(3457, new int[0])); // Celestial Sigil
			recipesToDelete.Add(new Tuple<int, int[]>(3458, new int[0])); // Celestial Sigil
			recipesToDelete.Add(new Tuple<int, int[]>(3459, new int[0])); // Celestial Sigil


			RecipeFinder finder;
			foreach (var recipeTuple in recipesToDelete)
			{
				finder = new RecipeFinder();
				finder.SetResult(recipeTuple.Item1);
				foreach (var ingredient in recipeTuple.Item2)
				{
					finder.AddIngredient(ingredient);
				}
				foreach (Recipe foundRecipe in finder.SearchRecipes())
				{
					RecipeEditor editor = new RecipeEditor(foundRecipe);
					editor.DeleteRecipe();
				}
			}
			////////////////////////// Pillars Recipes

			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(3456, 1);
			recipe.AddIngredient(3457, 1);
			recipe.AddIngredient(3458, 1);
			recipe.AddIngredient(3459, 1);
			recipe.AddIngredient(null, "NovaFragment", 1);
			recipe.SetResult(3544, 4);
			recipe.AddTile(13);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(3456, 20);
			recipe.AddIngredient(3457, 20);
			recipe.AddIngredient(3458, 20);
			recipe.AddIngredient(3459, 20);
			recipe.AddIngredient(null, "NovaFragment", 20);
			recipe.SetResult(3601);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(3457, 1);
			recipe.AddIngredient(3458, 1);
			recipe.AddIngredient(3459, 1);
			recipe.AddIngredient(null, "NovaFragment", 1);
			recipe.SetResult(3456);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(3456, 1);
			recipe.AddIngredient(3458, 1);
			recipe.AddIngredient(3459, 1);
			recipe.AddIngredient(null, "NovaFragment", 1);
			recipe.SetResult(3457);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(3456, 1);
			recipe.AddIngredient(3457, 1);
			recipe.AddIngredient(3459, 1);
			recipe.AddIngredient(null, "NovaFragment", 1);
			recipe.SetResult(3458);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(3457, 1);
			recipe.AddIngredient(3458, 1);
			recipe.AddIngredient(3456, 1);
			recipe.AddIngredient(null, "NovaFragment", 1);
			recipe.SetResult(3459);
			recipe.AddTile(412);
			recipe.AddRecipe();

			//////////////////////////
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.SilverBar, 15);
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.SetResult(ItemID.MagicMirror);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ItemID.GoldBar, 2);
			recipe.SetResult(ItemID.GoldChest);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ItemID.PlatinumBar, 2);
			recipe.SetResult(ItemID.GoldChest);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "Band");
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.SetResult(111, 1);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "Band");
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.SetResult(49, 1);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TinBar, 5);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CopperBar, 5);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.SetResult(ItemID.SlimeStaff, 1);
			recipe.AddTile(304);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CopperOre, 3);
			recipe.SetResult(ItemID.TinOre, 2);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TinOre, 3);
			recipe.SetResult(ItemID.CopperOre, 2);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronOre, 3);
			recipe.SetResult(ItemID.LeadOre, 2);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.LeadOre, 3);
			recipe.SetResult(ItemID.IronOre, 2);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.SilverOre, 3);
			recipe.SetResult(ItemID.TungstenOre, 2);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TungstenOre, 3);
			recipe.SetResult(ItemID.SilverOre, 2);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldOre, 3);
			recipe.SetResult(ItemID.PlatinumOre, 2);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.PlatinumOre, 3);
			recipe.SetResult(ItemID.GoldOre, 2);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.DemoniteOre, 5);
			recipe.SetResult(ItemID.CrimtaneOre, 3);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrimtaneOre, 5);
			recipe.SetResult(ItemID.DemoniteOre, 3);
			recipe.AddTile(null, "MineralTransmutator");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "TrueBloodCarnage", 1);
			recipe.AddIngredient(674, 1);
			recipe.AddTile(134);
			recipe.SetResult(757);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SoulofMind", 20);
			recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.Minishark, 1);
			recipe.SetResult(533);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 4);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(null, "SoulofMind", 5);
			recipe.SetResult(561);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemID.SoulofFright, 1);
			recipe.AddIngredient(null, "SoulofMind", 1);
			recipe.AddIngredient(ItemID.SoulofSight, 1);
			recipe.SetResult(579);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemID.SoulofFright, 1);
			recipe.AddIngredient(null, "SoulofMind", 1);
			recipe.AddIngredient(ItemID.SoulofSight, 1);
			recipe.SetResult(990);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.WarriorEmblem, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(null, "SoulofMind", 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.SummonerEmblem, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(null, "SoulofMind", 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.RangerEmblem, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(null, "SoulofMind", 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.SorcererEmblem, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(null, "SoulofMind", 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SharpenedTooth", 5);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.SetResult(3212);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SharpenedTooth", 5);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.SetResult(3212);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SandstonePlatform", 2);
			recipe.SetResult(607);
			recipe.AddRecipe();

			//вот   тут   начинаются новые крафты

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.PalladiumOre, 3);
			recipe.SetResult(ItemID.CobaltOre, 2);
			recipe.AddTile(null, "RecyclerofMatterTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CobaltOre, 3);
			recipe.SetResult(ItemID.PalladiumOre, 2);
			recipe.AddTile(null, "RecyclerofMatterTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MythrilOre, 3);
			recipe.SetResult(ItemID.OrichalcumOre, 2);
			recipe.AddTile(null, "RecyclerofMatterTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.OrichalcumOre, 3);
			recipe.SetResult(ItemID.MythrilOre, 2);
			recipe.AddTile(null, "RecyclerofMatterTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TitaniumOre, 3);
			recipe.SetResult(ItemID.AdamantiteOre, 2);
			recipe.AddTile(null, "RecyclerofMatterTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.AdamantiteOre, 3);
			recipe.SetResult(ItemID.TitaniumOre, 2);
			recipe.AddTile(null, "RecyclerofMatterTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TurtleShell, 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(ItemID.JungleSpores, 20);
			recipe.AddIngredient(ItemID.Stinger, 18);
			recipe.AddIngredient(null, "KeyMold", 1);
			recipe.SetResult(ItemID.JungleKey, 1);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.DemoniteBar, 25);
			recipe.AddIngredient(ItemID.ShadowScale, 25);
			recipe.AddIngredient(ItemID.EbonstoneBlock, 25);
			recipe.AddIngredient(ItemID.VilePowder, 25);
			recipe.AddIngredient(null, "KeyMold", 1);
			recipe.SetResult(ItemID.CorruptionKey, 1);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CrimtaneBar, 25);
			recipe.AddIngredient(ItemID.TissueSample, 25);
			recipe.AddIngredient(ItemID.CrimstoneBlock, 25);
			recipe.AddIngredient(ItemID.ViciousPowder, 25);
			recipe.AddIngredient(null, "KeyMold", 1);
			recipe.SetResult(ItemID.CrimsonKey, 1);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.PurificationPowder, 25);
			recipe.AddIngredient(null, "KeyMold", 1);
			recipe.SetResult(ItemID.HallowedKey, 1);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.FrostCore, 2);
			recipe.AddIngredient(ItemID.SnowBlock, 30);
			recipe.AddIngredient(ItemID.IceBlock, 30);
			recipe.AddIngredient(null, "KeyMold", 1);
			recipe.SetResult(ItemID.FrozenKey, 1);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Bone, 80);
			recipe.SetResult(1320);
			recipe.AddTile(300);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Torch, 5);
			recipe.SetResult(3069);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CobaltBar, 12);
			recipe.AddIngredient(ItemID.SnowBlock, 25);
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.SetResult(602);
			recipe.AddTile(26);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.PalladiumBar, 12);
			recipe.AddIngredient(ItemID.SnowBlock, 25);
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.SetResult(602);
			recipe.AddTile(26);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Wood, 30);
			recipe.SetResult(2196);
			recipe.AddTile(191);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(2766);
			recipe.SetResult(1261, 75);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(2766);
			recipe.SetResult(1261, 75);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(2766, 15);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 3);
			recipe.AddIngredient(null, "EssenseofJungle", 1);
			recipe.SetResult(1293);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

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

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			Mod mod = ModLoader.GetMod("Tremor");
			CyberWrathInvasion modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			if (InvasionWorld.CyberWrath)
			{
				int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
				LegacyGameInterfaceLayer orionProgress = new LegacyGameInterfaceLayer("Tremor: Invasion2",
					delegate
					{
						DrawOrionEvent(Main.spriteBatch);
						return true;
					},
					InterfaceScaleType.UI);
				layers.Insert(index, orionProgress);
			}
		}


		public void DrawOrionEvent(SpriteBatch spriteBatch)
		{
			Mod mod = ModLoader.GetMod("Tremor");
			CyberWrathInvasion modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			if (InvasionWorld.CyberWrath && !Main.gameMenu)
			{
				float scaleMultiplier = 0.5f + 1 * 0.5f;
				float alpha = 0.5f;
				Texture2D progressBg = Main.colorBarTexture;
				Texture2D progressColor = Main.colorBarTexture;
				Texture2D orionIcon = mod.GetTexture("Invasion/InvasionIcon");
				const string orionDescription = "Paradox Cohort";
				Color descColor = new Color(39, 86, 134);

				Color waveColor = new Color(255, 241, 51);
				Color barrierColor = new Color(255, 241, 51);

				try
				{
					//draw the background for the waves counter
					const int offsetX = 20;
					const int offsetY = 20;
					int width = (int)(200f * scaleMultiplier);
					int height = (int)(46f * scaleMultiplier);
					Rectangle waveBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 23f), new Vector2(width, height));
					Utils.DrawInvBG(spriteBatch, waveBackground, new Color(63, 65, 151, 255) * 0.785f);

					//draw wave text

					string waveText = "Cleared " + InvasionWorld.CyberWrathPoints1 + "%";
					Utils.DrawBorderString(spriteBatch, waveText, new Vector2(waveBackground.X + waveBackground.Width / 2, waveBackground.Y), Color.White, scaleMultiplier, 0.5f, -0.1f);

					//draw the progress bar

					if (InvasionWorld.CyberWrathPoints1 == 0)
					{

					}

					Rectangle waveProgressBar = Utils.CenteredRectangle(new Vector2(waveBackground.X + waveBackground.Width * 0.5f, waveBackground.Y + waveBackground.Height * 0.75f), new Vector2(progressColor.Width, progressColor.Height));
					Rectangle waveProgressAmount = new Rectangle(0, 0, (int)(progressColor.Width * 0.01f * MathHelper.Clamp(InvasionWorld.CyberWrathPoints1, 0f, 100f)), progressColor.Height);
					Vector2 offset = new Vector2((waveProgressBar.Width - (int)(waveProgressBar.Width * scaleMultiplier)) * 0.5f, (waveProgressBar.Height - (int)(waveProgressBar.Height * scaleMultiplier)) * 0.5f);


					spriteBatch.Draw(progressBg, waveProgressBar.Location.ToVector2() + offset, null, Color.White * alpha, 0f, new Vector2(0f), scaleMultiplier, SpriteEffects.None, 0f);
					spriteBatch.Draw(progressBg, waveProgressBar.Location.ToVector2() + offset, waveProgressAmount, waveColor, 0f, new Vector2(0f), scaleMultiplier, SpriteEffects.None, 0f);

					//draw the icon with the event description

					//draw the background
					const int internalOffset = 6;
					Vector2 descSize = new Vector2(154, 40) * scaleMultiplier;
					Rectangle barrierBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 19f), new Vector2(width, height));
					Rectangle descBackground = Utils.CenteredRectangle(new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), descSize);
					Utils.DrawInvBG(spriteBatch, descBackground, descColor * alpha);

					//draw the icon
					int descOffset = (descBackground.Height - (int)(32f * scaleMultiplier)) / 2;
					Rectangle icon = new Rectangle(descBackground.X + descOffset, descBackground.Y + descOffset, (int)(32 * scaleMultiplier), (int)(32 * scaleMultiplier));
					spriteBatch.Draw(orionIcon, icon, Color.White);

					//draw text

					Utils.DrawBorderString(spriteBatch, orionDescription, new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), Color.White, 0.80f, 0.3f, 0.4f);
				}
				catch (Exception e)
				{
					ErrorLogger.Log(e.ToString());
				}
			}
		}
	}
}