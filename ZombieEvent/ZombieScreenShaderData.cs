using Terraria;
using Terraria.Graphics.Shaders;

namespace Tremor.ZombieEvent
{
	public class ZombieScreenShaderData : ScreenShaderData
	{
		private int CalIndex;

		public ZombieScreenShaderData(string passName)
			: base(passName)
		{
		}

		private void UpdateCalIndex()
		{
			bool CalType = ZWorld.ZInvasion;
			if (CalIndex >= 0 && Main.npc[CalIndex].active && CalType)
			{
				return;
			}
			CalIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && CalType)
				{
					CalIndex = i;
					break;
				}
			}
		}

		public override void Apply()
		{
			UpdateCalIndex();
			if (CalIndex != -1)
			{
				UseTargetPosition(Main.npc[CalIndex].Center);
			}
			base.Apply();
		}
	}
}