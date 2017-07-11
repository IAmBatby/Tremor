using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class NorthwindBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("North wind");
			Description.SetDefault("The frost ghost will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("NorthWindMinion")] > 0)
			{
				modPlayer.northWind = true;
			}
			if (!modPlayer.northWind)
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