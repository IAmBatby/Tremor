using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class AmplifiedEnchantmentSolution : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Amplified Enchantment Solution");
			Description.SetDefault("45% chance not to consume flask");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}