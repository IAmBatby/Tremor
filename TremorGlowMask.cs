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
		static ushort vanillaCount;
		
		public static bool Loaded;

		public static void Load()
		{
			vanillaCount=Main.glowMaskTexture.Length;
			Array.Resize(ref Main.glowMaskTexture, vanillaCount + Count);
			short i = (short)vanillaCount;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Tremor/Items/DesertExplorerVisage_HeadGlow");
			DEH = i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Tremor/Items/DesertExplorerGreaves_LegsGlow");
			DEG = i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Tremor/NovaPillar/NovaPickaxe_Glow");
			NovaPick = i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Tremor/NovaPillar/NovaHamaxe_Glow");
			NovaHamaxe = i++;
			Loaded = true;
		}

		public static void Unload()
		{
			Array.Resize(ref Main.glowMaskTexture,vanillaCount);
			Loaded = false;
			DEH = 0;
			DEG = 0;
			NovaPick = 0;
			NovaHamaxe = 0;
		}

	}
}
