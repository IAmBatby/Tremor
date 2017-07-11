using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class DakkharnsMask : ModItem
	{



		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;


			item.value = 1000000;
			item.rare = 11;
			item.defense = 50;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dakkharn Mask");
			Tooltip.SetDefault("Summons and ancient predator to defend you from foes\nPredator attacks enemies and inflicts curses");
		}


		public override void UpdateEquip(Player player)
		{
			player.AddBuff(mod.BuffType("AncientPredatorBuff"), 2);
		}
	}
}
