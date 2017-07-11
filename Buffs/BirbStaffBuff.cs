using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BirbStaffBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Birb");
			Description.SetDefault("A birb will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("BirbStaffPro")] > 0)
			{
				modPlayer.birbStaff = true;
			}
			if (!modPlayer.birbStaff)
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