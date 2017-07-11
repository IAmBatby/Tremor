using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BarrierRechargeBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Barrier Recharging");
			Description.SetDefault("Magic barrier can't appear");
			Main.debuff[Type] = true;
		}
	}
}