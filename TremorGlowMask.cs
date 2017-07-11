using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	public static class TremorGlowMask
	{
		static short countAdded=0;
		static ushort countInitial=0;

		public static short AddGlowMask(string texturePath)
		{
			if(countInitial==0){countInitial=(ushort)Main.glowMaskTexture.Length;}
			Microsoft.Xna.Framework.Graphics.Texture2D texture=ModLoader.GetTexture(texturePath);
			if(texture==null){throw new Exception("Could not find texture: "+texturePath);}
			countAdded++;
			Array.Resize(ref Main.glowMaskTexture,Main.glowMaskTexture.Length+1);
			Main.glowMaskTexture[Main.glowMaskTexture.Length-1]=texture;
			return (short)(Main.glowMaskTexture.Length-1);
		}

		/*public static void Load()
		{

		}*/

		public static void Unload()
		{
			if(Main.glowMaskTexture.Length>=countInitial+countAdded)//Probably an unneeded check
			{
				Array.Resize(ref Main.glowMaskTexture,Main.glowMaskTexture.Length-countAdded);
			}
			else if(Main.glowMaskTexture.Length>countInitial)
			{
				Array.Resize(ref Main.glowMaskTexture,countInitial);
			}
		}
	}
}
