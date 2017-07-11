using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BottledSoulOfMind : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Bottled Soul of Mind");
			Description.SetDefault("Shows the location of treasure and ore");
		}

		public override void Update(Player player, ref int buffIndex)
		{
        player.findTreasure = true;
		}
	}
}
