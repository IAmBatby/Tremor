using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Tremor.Invasion
{
	public class InvasionWorld : ModWorld
	{
		public static int CyberWrathPoints = 0; // Is set once to Points1, never used. Delete ?? (?)
		public static int CyberWrathPoints1;
		public static bool CyberWrath;

		public override void Initialize()
		{
			CyberWrathPoints1 = 0;
			CyberWrath = false;
		}

		/*public override void SaveCustomData(BinaryWriter writer)
		{
			writer.Write(saveVersion);
			writer.Write(CyberWrath);
			writer.Write(CyberWrathPoints1);
		} */

		public override TagCompound Save()
		{
			var tc = new TagCompound
			{
				{"CyberWrath", CyberWrath},
				{"CyberWrathPoints1", CyberWrathPoints1}
			};
			return tc;
		}

		public override void Load(TagCompound tag)
		{
			CyberWrath = tag.GetBool("CyberWrath");
			CyberWrathPoints1 = tag.GetAsInt("CyberWrathPoints1");
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(CyberWrath);
			writer.Write(CyberWrathPoints1);
		}

		public override void NetReceive(BinaryReader reader)
		{
			CyberWrath = reader.ReadBoolean();
			CyberWrathPoints1 = reader.ReadInt32();
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				// ? potential trouble
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
