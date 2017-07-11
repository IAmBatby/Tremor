using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class DesertEmperorSetBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Desert Wasp");
            Description.SetDefault("Releases a wasp to attack enemies when a flask explodes");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}