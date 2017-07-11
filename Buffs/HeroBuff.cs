using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class HeroBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hero");
			Description.SetDefault("Almost grants invulnerability");
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.aggro += 50;
			
			player.statDefense += 10000;
			player.moveSpeed += 0.15f;
			player.moveSpeed += 999f;
			
		    player.buffImmune[20] = true;
		    player.buffImmune[21] = true;
			player.buffImmune[22] = true;
			player.buffImmune[23] = true;
			player.buffImmune[24] = true;
			player.buffImmune[25] = true;
			player.buffImmune[30] = true;
			player.buffImmune[31] = true;
			player.buffImmune[32] = true;
			player.buffImmune[33] = true;
			player.buffImmune[35] = true;
			player.buffImmune[36] = true;
			player.buffImmune[37] = true;
			player.buffImmune[38] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[67] = true;
			player.buffImmune[68] = true;
			player.buffImmune[69] = true;
			player.buffImmune[70] = true;
			player.buffImmune[72] = true;
			player.buffImmune[80] = true;
			player.buffImmune[86] = true;
			player.buffImmune[88] = true;
			player.buffImmune[94] = true;
			player.buffImmune[103] = true;
			player.buffImmune[137] = true;
			player.buffImmune[144] = true;
			player.buffImmune[145] = true;
			player.buffImmune[148] = true;
			player.buffImmune[149] = true;
			player.buffImmune[153] = true;
			player.buffImmune[156] = true;
			player.buffImmune[160] = true;
			player.buffImmune[163] = true;
			player.buffImmune[164] = true;
			player.buffImmune[169] = true;
			player.buffImmune[194] = true;
			player.buffImmune[195] = true;
			player.buffImmune[196] = true;
			player.buffImmune[197] = true;
		}
	}
}
