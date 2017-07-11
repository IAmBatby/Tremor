using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor
{
    public class GlobalNPCRule : GlobalNPC
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