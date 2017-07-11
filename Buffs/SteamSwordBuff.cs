using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class SteamSwordBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Brass Melee Enchanting");
			Description.SetDefault("Increases Brass Rapier and Glaive damage");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}