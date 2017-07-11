using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class RuinAltarBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ruin Powers");
			Description.SetDefault("Ancient powers allow you to summon Ancient Dragon");
		}

		public override void Update(Player player, ref int buffIndex)
		{
            TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
            modPlayer.ruinAltar = true;
        }
	}
}
