using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ExtendedHealthBooster : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Extended Health Booster");
			Description.SetDefault("Regenerates 150 health every 45 seconds");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] == 0)
			{
				player.statLife += 150;
				player.HealEffect(150);
				player.AddBuff(mod.BuffType("ExtendedHealthBooster"), 2700);
			}
		}
	}
}