using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class JavaRobe : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 32;
			item.value = 10000;
			item.rare = 2;

			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Java Robe");
			Tooltip.SetDefault("");
		}

	}
}
