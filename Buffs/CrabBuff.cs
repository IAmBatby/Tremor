using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class CrabBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Little Crab");
			Description.SetDefault("A little crab will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("CrabStaffPro")] > 0)
			{
				modPlayer.crabStaff = true;
			}
			if (!modPlayer.crabStaff)
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