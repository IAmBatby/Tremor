using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WaterStorm : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;


			item.value = 15000;
			item.rare = 3;
			item.defense = 3;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Water Storm");
			Tooltip.SetDefault("Increases magic critical strike chance by 10%\nIncreases maximum mana by 40");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 40;
			player.magicCrit += 10;
		}

	}
}
