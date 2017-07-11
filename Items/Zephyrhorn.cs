using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Zephyrhorn : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;
			item.value = 100000;
			item.rare = 7;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zephyrhorn");
			Tooltip.SetDefault("Increases minion damage and size");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("ZephyrhornBuff"), 2);
		}
	}
}
