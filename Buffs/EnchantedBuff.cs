using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor;
using Tremor.NPCs;

namespace Tremor.Buffs
{
	public class EnchantedBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Enchanted");
			Description.SetDefault("Enchanted weapons have more power");
                        //Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}
