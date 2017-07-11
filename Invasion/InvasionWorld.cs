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

namespace Tremor.Invasion
{
	public class InvasionWorld : ModWorld
	{
	    private const int saveVersion = 0;
        public static int CyberWrathPoints = 0;
        public static int CyberWrathPoints1 = 0;
        public static bool CyberWrath = false;
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			
		}

		public override void PostWorldGen()
		{
			
        }

		public override void Initialize()
        {
			CyberWrathPoints1 = 0;
			CyberWrath = false;
        }

        public override void TileCountsAvailable(int[] tileCounts)
		{
			
		}
		
		/*public override void SaveCustomData(BinaryWriter writer)
		{
			writer.Write(saveVersion);
			writer.Write(CyberWrath);
			writer.Write(CyberWrathPoints1);
		} */
		
		public override TagCompound Save()
		{
			TagCompound save_data = new TagCompound();
			save_data.Add("CyberWrath", CyberWrath);
			save_data.Add("CyberWrathPoints1", CyberWrathPoints1);
			return save_data;
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(CyberWrath);
			writer.Write(CyberWrathPoints1);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			flags[0] = CyberWrath;
			CyberWrathPoints1 = reader.ReadInt32();
		}
		
		int num;
		public override void Load(TagCompound tag)
		{
			CyberWrath = tag.GetBool("CyberWrath");
			CyberWrathPoints1 = tag.GetInt("CyberWrathPoints1"); 
		}
		
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				CyberWrath = flags[0];
				CyberWrathPoints1 = reader.ReadInt32();
			}
			else
			{
				ErrorLogger.Log("Tremor: Unknown loadVersion: " + loadVersion);
			}
		}	
	}
}
