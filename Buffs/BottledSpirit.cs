using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BottledSpirit : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bottled Spirit");
			Description.SetDefault("Shoots two homing souls when using a flask");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}