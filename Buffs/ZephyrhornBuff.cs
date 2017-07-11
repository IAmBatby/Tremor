using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ZephyrhornBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Zephyrhorn");
			Description.SetDefault("Increased minion size");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.minionDamage += 0.1f;
		}
	}
}
