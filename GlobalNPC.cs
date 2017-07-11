using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	public class TremorGlobalNPC : GlobalNPC
	{
		public override void AI(NPC npc)
		{
			if (npc.type == 36 && Main.npc[(int)npc.ai[1]].type == mod.NPCType("CogLord"))
			{
				npc.aiStyle = 0;
				npc.hide = true;
				npc.scale /= 1000000;
				npc.life = -1;
			}
		}
	}
}