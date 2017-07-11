using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ManaBooster : ModItem
	{
		public override void SetDefaults()
		{

			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 4;
			item.width = 22;
			item.UseSound = SoundID.Item43;
			item.height = 18;
			item.buffType = mod.BuffType("ManaBooster");
			item.value = 5160000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Booster");
			Tooltip.SetDefault("Regenerates mana every minute");
		}


		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

	}
}
