using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Terraria.ModLoader.IO;

namespace Tremor.ZombieEvent
{
	public class ZWorld : ModWorld
	{
	    private const int saveVersion = 0;
        public static int ZPoints = 0;
        public static bool ZInvasion = false;
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			
		}

		public override void PostWorldGen()
		{
			
        }

		public override void Initialize()
        {
			ZPoints = 0;
			ZInvasion = false;
        }

        public override void TileCountsAvailable(int[] tileCounts)
		{
			
		}
		
		public override TagCompound Save()
		{
			var downed = new List<string>();
			//var downed_ = new List<int>();
			if (ZInvasion) downed.Add("boolWrath");
			if (ZPoints != -1 && ZInvasion) downed.Add("intWrath");

			return new TagCompound {
				{"downed", downed}
			};
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(ZInvasion);
			writer.Write(ZPoints);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			flags[0] = ZInvasion;
			ZPoints = reader.ReadInt32();
		}
		
		int num;
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			//CyberWrathPoints1 = downed.Contains("intWrath");
			ZInvasion = downed.Contains("boolWrath");
		} 
		
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				ZInvasion = flags[0];
				ZPoints = reader.ReadInt32();
			}
			else
			{
				ErrorLogger.Log("Tremor: Unknown loadVersion: " + loadVersion);
			}
		}	
	}
}
