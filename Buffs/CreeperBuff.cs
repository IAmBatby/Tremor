using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class CreeperBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Creeper");
			Description.SetDefault("The creeper will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("CreeperStaffPro")] > 0)
			{
				modPlayer.creeperMinion = true;
			}
			if (!modPlayer.creeperMinion)
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