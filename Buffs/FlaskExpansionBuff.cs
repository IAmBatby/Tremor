using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class FlaskExpansionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Flask Expansion");
			Description.SetDefault("Increased size of alchemic clouds");
		}
	}
}
