using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class EyeMonolithBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Eye Monolith");
			Description.SetDefault("15% increased summon damage");
		}

		public override void Update(Player player, ref int buffIndex)
		{
	player.minionDamage += 0.15f;
		}
	}
}
