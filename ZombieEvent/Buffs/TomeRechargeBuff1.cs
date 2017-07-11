using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Buffs
{
	public class TomeRechargeBuff1 : ModBuff
	{
		public override void SetDefaults()
		{
			Main.debuff[Type] = true;
			DisplayName.SetDefault("Soul Recharging");
			Description.SetDefault("Wait untill Book of Revelations recharge souls");
		}

	}
}
