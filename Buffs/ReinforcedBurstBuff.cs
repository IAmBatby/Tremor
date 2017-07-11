using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ReinforcedBurstBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Reinforced Burst");
			Description.SetDefault("Alchemical projectiles leave three death flames");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}