using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	public static class TremorGlowMask
	{
		//Grove Set List
		public static short DEH;
		public static short DEG;

		public static short NovaPick;
		public static short NovaHamaxe;

		//Count items
		const short Count = 4;

		//Start - Final
		static short End;
		public static bool Loaded;

		public static void Load()
		{
			Array.Resize(ref Main.glowMaskTexture, Main.glowMaskTexture.Length + Count);
			short i = (short)(Main.glowMaskTexture.Length - Count);
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Tremor/Items/DesertExplorerVisage_HeadGlow");
			DEH = i;
			i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Tremor/Items/DesertExplorerGreaves_LegsGlow");
			DEG = i;
			i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Tremor/NovaPillar/NovaPickaxe_Glow");
			NovaPick = i;
			i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Tremor/NovaPillar/NovaHamaxe_Glow");
			NovaHamaxe = i;
			i++;
			End = i;
			Loaded = true;
		}

		public static void Unload()
		{
			if (Main.glowMaskTexture.Length == End)
			{
				Array.Resize(ref Main.glowMaskTexture, Main.glowMaskTexture.Length - Count);
			}
			else if (Main.glowMaskTexture.Length > End && Main.glowMaskTexture.Length > Count)
			{
				for (int i = End - Count; i < End; i++)
				{
					Main.glowMaskTexture[i] = ModLoader.GetTexture("Terraria/Item_0");
				}
			}
			Loaded = false;
			DEH = 0;
			DEG = 0;
			NovaPick = 0;
			NovaHamaxe = 0;
			End = 0;
		}

	}
}
