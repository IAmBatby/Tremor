using System;
using System.Collections.Generic;
using System.IO;
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

		internal static Tremor instance;

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
			ErrorLogger.Log($"[Tremor][{DateTime.Now:yyyy-MM-dd hh:mm:ss}] {message}");
		}

		public static void Log(string format, params object[] args)
		{
			ErrorLogger.Log($"[Tremor][{DateTime.Now:yyyy-MM-dd hh:mm:ss}] {string.Format(format, args)}");
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " " + Lang.GetItemNameValue(ItemType("AmethystStaff")), ItemType("AmethystStaff"), ItemType("DiamondStaff"), ItemType("RubyStaff"), ItemType("TopazStaff"), ItemType("SapphireStaff"), ItemType("AmberStaff"), ItemType("EmeraldStaff"));
			RecipeGroup.RegisterGroup("Tremor:GemStaves", group);
		}

		public override void UpdateMusic(ref int music)
		{
			if (Main.myPlayer != -1 && !Main.gameMenu)
			{
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

				CyberWrathInvasion modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
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
				
			}
		}


		public override void Load()
		{
			instance = this;

			Filters.Scene["Tremor:Invasion"] = new Filter(new InvasionData("FilterMiniTower").UseColor(0.2f, 0.4f, 0.5f).UseOpacity(0.9f), EffectPriority.VeryHigh);
			SkyManager.Instance["Tremor:Invasion"] = new ZombieSky();
			Filters.Scene["Tremor:Zombie"] = new Filter(new ZombieScreenShaderData("FilterMiniTower").UseColor(1.1f, 0.3f, 0.3f).UseOpacity(0.6f), EffectPriority.VeryHigh);
			SkyManager.Instance["Tremor:Zombie"] = new ZombieSky();
			Filters.Scene["Tremor:Ice"] = new Filter(new ZombieScreenShaderData("FilterMiniTower").UseColor(0.4f, 0.8f, 1.0f).UseOpacity(0.6f), EffectPriority.VeryHigh);
			SkyManager.Instance["Tremor:Ice"] = new ZombieSky();
			Filters.Scene["Tremor:CogLord"] = new Filter(new ZombieScreenShaderData("FilterMiniTower").UseColor(0.9f, 0.5f, 0.2f).UseOpacity(0.6f), EffectPriority.VeryHigh);
			SkyManager.Instance["Tremor:CogLord"] = new ZombieSky();

			// Init
			NPCDrops.Init();

			if (!Main.dedServ)
			{
				string[,] musicBoxes =
				{
					{ "CogLord", "CogLordMusicBox", "CogLordMusicBox" },
					{ "SlimeRain", "SlimeRainMusicBox", "SlimeRainMusicBox" },
					{ "Boss6", "Boss6MusicBox", "Boss6MusicBox" },
					{ "Trinity", "TrinityMusicBox", "TrinityMusicBox" },
					{ "TikiTotem", "TikiTotemMusicBox", "TikiTotemMusicBox" },
					{ "EvilCorn", "EvilCornMusicBox", "EvilCornMusicBox" },
					{ "CyberKing", "CyberKingMusicBox", "CyberKingMusicBox" },
					{ "Snow2", "BlizzardMusicBox", "BlizzardMusicBox" },
					{ "CyberWrath", "ParadoxCohortMusicBox", "ParadoxCohortMusicBoxTile" },
					{ "NightOfUndead", "DeathHordeMusicBox", "DeathHordeMusicBoxTile" },
					{ "Granite", "GraniteMusicBox", "GraniteMusicBox" },
				};

				for (int i = 0; i < musicBoxes.GetUpperBound(0) + 1; i++)
				{
					AddMusicBox(GetSoundSlot(SoundType.Music, $"Sounds/Music/{musicBoxes[i, 0]}"), ItemType(musicBoxes[i, 1]), TileType(musicBoxes[i, 2]));
				}
				
				GameShaders.Armor.BindShader(ItemType("NovaDye"), new ArmorShaderData(Main.PixelShaderRef, "ArmorSolar")).UseColor(0.8f, 0.7f, 0.3f).UseSecondaryColor(0.8f, 0.7f, 0.3f);
				NovaSky.PlanetTexture = GetTexture("NovaPillar/NovaPlanet");
				Filters.Scene["Tremor:Nova"] = new Filter(new NovaData("FilterMiniTower").UseColor(0.8f, 0.7f, 0.3f).UseOpacity(0.82f), EffectPriority.VeryHigh);
				SkyManager.Instance["Tremor:Nova"] = new NovaSky();

				// Replace celestial sigil?
				Main.itemTexture[3601] = GetTexture($"Resprites/{(ModLoader.GetLoadedMods().Contains("Elerium") ? "CelestialSigil2" : "CelestialSigil")}");

				// Replace vanilla buff sprites with resprites
				for (int i = 1; i < 206; i++)
				{
					Main.buffTexture[i] = GetTexture($"Resprites/Buff_{i}");
				}
			}
		}

		public override void AddRecipes()
		{
			// Recipe wrapper
			RecipeWrapper.AddRecipes(this);
			RecipeWrapper.RemoveRecipes();
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			CyberWrathInvasion modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
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
			CyberWrathInvasion modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
			if (InvasionWorld.CyberWrath && !Main.gameMenu)
			{
				float scaleMultiplier = 0.5f + 1 * 0.5f;
				float alpha = 0.5f;
				Texture2D progressBg = Main.colorBarTexture;
				Texture2D progressColor = Main.colorBarTexture;
				Texture2D orionIcon = Tremor.instance.GetTexture("Invasion/InvasionIcon");
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