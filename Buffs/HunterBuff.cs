using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class HunterBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Lil' Snatcher");
			Description.SetDefault("The lil' snatcher will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("Hunter")] > 0)
			{
				modPlayer.hunterMinion = true;
			}
			if (!modPlayer.hunterMinion)
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