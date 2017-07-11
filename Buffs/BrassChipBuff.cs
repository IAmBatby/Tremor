using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BrassChipBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Brass Chip");
			Description.SetDefault("Shoots rockets from the sky when a flask is destroyed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}