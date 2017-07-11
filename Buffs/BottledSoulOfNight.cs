using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BottledSoulOfNight : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Bottled Soul of Night");
			Description.SetDefault("8% increased melee speed");
		}

		public override void Update(Player player, ref int buffIndex)
		{
	player.meleeSpeed += 0.08f;
		}
	}
}
