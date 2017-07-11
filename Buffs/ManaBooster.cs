using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ManaBooster : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mana Booster");
			Description.SetDefault("Regenerates 150 mana every minute");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] == 0)
			{
				player.statMana += 150;
				player.ManaEffect(150);
				player.AddBuff(mod.BuffType("ManaBooster"), 3600);
			}
		}
	}
}