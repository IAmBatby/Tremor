using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class GoblinStaffBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Goblin Staff");
			Description.SetDefault("The goblin will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("GoblinStaffPro")] > 0)
			{
				modPlayer.goblinMinion = true;
			}
			if (!modPlayer.goblinMinion)
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