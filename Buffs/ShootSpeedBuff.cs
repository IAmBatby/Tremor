using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor;
using Tremor.NPCs;

namespace Tremor.Buffs
{
	public class ShootSpeedBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sniper's Accuracy");
			Description.SetDefault("Increased projectile's speed twice");
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}
