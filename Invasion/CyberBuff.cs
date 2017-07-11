using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class CyberBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cyber Stray");
			Description.SetDefault("Cyber stray fights for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("Mini_Cyber")] > 0)
			{
				modPlayer.miniCyber = true;
			}
			if (!modPlayer.miniCyber)
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