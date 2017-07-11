using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class AncientBannerBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Ancient Banner");
			Description.SetDefault("Increased life regeneration");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 40;
		}
	}
}