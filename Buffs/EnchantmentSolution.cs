using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class EnchantmentSolution : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Enchantment Solution");
			Description.SetDefault("25% chance not to consume flask");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}