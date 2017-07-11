using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Tremor.NovaPillar
{
	public class NovaData : ScreenShaderData
	{
		int NovaTowerIndex;

		public NovaData(string passName) : base(passName) { }

		void UpdatePuritySpiritIndex()
		{
			int NovaTowerType = ModLoader.GetMod("Tremor").NPCType("NovaPillar");
			if (NovaTowerIndex >= 0 && Main.npc[NovaTowerIndex].active && Main.npc[NovaTowerIndex].type == NovaTowerType)
			{
				return;
			}
			NovaTowerIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == NovaTowerType)
				{
					NovaTowerIndex = i;
					break;
				}
			}
		}

		public override void Apply()
		{
			UpdatePuritySpiritIndex();
			if (NovaTowerIndex != -1)
			{
				UseTargetPosition(Main.npc[NovaTowerIndex].Center);
			}
			base.Apply();
		}
	}
}
