using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class HealthRecharging : ModBuff
	{
		public override void SetDefaults()
		{
			Main.debuff[Type] = true;
			DisplayName.SetDefault("Health Recharging");
			Description.SetDefault("Wait before you can use the hourglass again");
		}

	}
}
