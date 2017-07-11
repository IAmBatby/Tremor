using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BlueSakuraBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Blue Wind");
			Description.SetDefault("The blue wind will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("BlueSakuraPro")] > 0)
			{
				modPlayer.blueSakuraMinion = true;
			}
			if (!modPlayer.blueSakuraMinion)
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