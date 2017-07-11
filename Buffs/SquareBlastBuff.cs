using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class SquareBlastBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Square Blast");
			Description.SetDefault("Alchemical projectiles leave explosions in the shape of square");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}