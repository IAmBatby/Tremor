using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class CyberSawBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cyber Saw");
			Description.SetDefault("The cyber saw will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("CyberStaffPro")] > 0)
			{
				modPlayer.cyberMinion = true;
			}
			if (!modPlayer.cyberMinion)
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