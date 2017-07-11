using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Tremor.Invasion;

namespace Tremor
{
	public class InvasionData : ScreenShaderData
	{
        private int invasionI;

		public InvasionData(string passName)
			: base(passName)
		{
		}

		private void UpdatePuritySpiritIndex()
		{
            Mod mod = ModLoader.GetMod("Tremor");
            CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
            if (InvasionWorld.CyberWrath)
			{
				return;
			}
            invasionI = -1;
        }

		public override void Apply()
		{
			UpdatePuritySpiritIndex();
			base.Apply();
		}
	}
}