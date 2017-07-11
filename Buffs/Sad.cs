using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Tremor.NPCs;

namespace Tremor.Buffs
{
	public class Sad : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sad");
			Description.SetDefault("10% decreased damage");
                        Main.debuff[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.damage = (int) (npc.damage - 0.1f);
        }
	}
}