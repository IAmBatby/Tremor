using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class NecronomiconBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Necronomicon");
			Description.SetDefault("The skeleton will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("NecronomiconPro")] > 0)
			{
				modPlayer.skeletonMinion = true;
			}
			if (!modPlayer.skeletonMinion)
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