using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BottledSoulOfSight : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Bottled Soul of Sight");
			Description.SetDefault("Shows the location of enemies");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.detectCreature = true;
		}
	}
}
