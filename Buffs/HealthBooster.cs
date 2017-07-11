using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class HealthBooster : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Health Booster");
			Description.SetDefault("Regenerates 100 health every minute");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] == 0)
			{
				player.statLife += 100;
				player.HealEffect(100);
				player.AddBuff(mod.BuffType("HealthBooster"), 3600);
			}
		}
	}
}