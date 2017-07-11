using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class KingSuit : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 20;
			item.value = 20000;
			item.rare = 2;

			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King Suit");
			Tooltip.SetDefault("");
		}

	}
}
