using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class SilkBannerBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Silk Banner");
			Description.SetDefault("Increases defense by 15 and gives thorn effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
                        player.thorns = 3f; 
                        player.statDefense += 15;
		}
	}
}