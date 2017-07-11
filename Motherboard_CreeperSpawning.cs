using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor
{
	public class Motherboard_CreeperSpawning : GlobalNPC
	{
		public override void AI(NPC npc)
		{
			if (npc.type == NPCID.Creeper && Main.npc[NPC.crimsonBoss].type == mod.NPCType("Motherboard"))
				npc.active = false;
			for (int i = 0; i < Main.gore.Length; i++)
				if (Main.gore[i].type == 392 || Main.gore[i].type == 393 || Main.gore[i].type == 394 || Main.gore[i].type == 395)
					Main.gore[i].active = false;
		}
	}
}