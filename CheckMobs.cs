
using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	public class CheckMobs : ModPlayer
	{
		public override void PostUpdate()
		{
			for (int k = 0; k < 200; k++)
			{
				if (player.GetModPlayer<TremorPlayer>(mod).ZoneRuins)
				{
					if (Main.npc[k].type == mod.NPCType("Youwarkee") || Main.npc[k].type == mod.NPCType("Varki") || Main.npc[k].type == mod.NPCType("NovaFlier") || Main.npc[k].type == mod.NPCType("Deadling") || Main.npc[k].type == mod.NPCType("NovaAlchemist"))
					{
						Main.npc[k].life = -1;
						Main.npc[k].active = false;
						Main.npc[k].checkDead();
					}
				}
			}
		}
	}
}
