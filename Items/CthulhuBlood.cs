using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CthulhuBlood : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 30;
			item.maxStack = 1;


			item.value = 255000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Cthulhu Blood");
			Tooltip.SetDefault("Increased life regeneration\nIncreased alchemical damage and critical strike chance by 25%");
		}



		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 3;
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.25f;
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 25;
		}
	}
}
