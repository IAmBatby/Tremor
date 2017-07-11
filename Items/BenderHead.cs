using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class BenderHead : ModItem
	{



		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;
			item.value = 10000;
			item.rare = 5;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bender Head");
			Tooltip.SetDefault("");
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BenderBody") && legs.type == mod.ItemType("BenderLegs");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "'Bite my shiny metal ass!'";
		}
	}
}
