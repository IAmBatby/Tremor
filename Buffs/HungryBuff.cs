using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class HungryBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hungry");
			Description.SetDefault("The hungry will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("HungryStaffPro")] > 0)
			{
				modPlayer.hungryMinion = true;
			}
			if (!modPlayer.hungryMinion)
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