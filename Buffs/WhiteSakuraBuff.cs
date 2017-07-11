using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class WhiteSakuraBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("White Wind");
			Description.SetDefault("The white wind will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("WhiteSakuraPro")] > 0)
			{
				modPlayer.whiteSakura = true;
			}
			if (!modPlayer.whiteSakura)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}