using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class RockClimberBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Rock Climber");
			Description.SetDefault("Grants ability to climb walls");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.spikedBoots = 1;
			player.spikedBoots = 2;
		}
	}
}
