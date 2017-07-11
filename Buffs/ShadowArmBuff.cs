using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ShadowArmBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("ShadowArm");
			Description.SetDefault("The shadow arm will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("ShadowStaffPro")] > 0)
			{
				modPlayer.shadowMinion = true;
			}
			if (!modPlayer.shadowMinion)
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