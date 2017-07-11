using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class AlchemistGloveBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Master Alchemist Glove");
			Description.SetDefault("Alchemic weapons throw two flasks");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}