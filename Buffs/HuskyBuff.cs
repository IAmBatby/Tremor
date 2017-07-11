using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class HuskyBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Husky");
			Description.SetDefault("A husky will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("HuskyStaffPro")] > 0)
			{
				modPlayer.huskyStaff = true;
			}
			if (!modPlayer.huskyStaff)
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