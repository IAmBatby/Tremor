using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class CorruptorBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Corruptor Junior");
			Description.SetDefault("The corruptor will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("CorruptorStaffPro")] > 0)
			{
				modPlayer.corruptorMinion = true;
			}
			if (!modPlayer.corruptorMinion)
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