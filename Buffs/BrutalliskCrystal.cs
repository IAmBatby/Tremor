using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BrutalliskCrystal : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Aquamarine Crystal");
			Description.SetDefault("A fast way of travelling");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("BrutalliskCrystal"), player);
			player.buffTime[buffIndex] = 10;
			player.noKnockback = true;
		}
	}
}
