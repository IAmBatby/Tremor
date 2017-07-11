using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class LongFuseBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Long fuse");
			Description.SetDefault("Alchemic weapon throws further");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}