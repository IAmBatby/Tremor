using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class MaximumCharge : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Maximum Charge");
			Description.SetDefault("Maximum mana increased by 100");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statManaMax2 += 100;
		}
	}
}
