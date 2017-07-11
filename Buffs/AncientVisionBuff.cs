using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class AncientVisionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ancient Vision");
			Description.SetDefault("The ancient vision will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("AncientVisionPro")] > 0)
			{
				modPlayer.ancientVision = true;
			}
			if (!modPlayer.ancientVision)
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