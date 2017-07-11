using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class TremorBuffs : GlobalBuff
	{

		public override void Update(int type, Terraria.Player player, ref int buffIndex)
		{
			if (player.FindBuffIndex(117) != -1)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.1f;
			}
			if (player.FindBuffIndex(115) != -1)
			{
				player.GetModPlayer<MPlayer>(mod).alchemistCrit += 10;
			}
		}
	}
}