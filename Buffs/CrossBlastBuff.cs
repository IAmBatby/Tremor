using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class CrossBlastBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cross Blast");
			Description.SetDefault("Alchemical projectiles leave explosions in the shape of cross");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}