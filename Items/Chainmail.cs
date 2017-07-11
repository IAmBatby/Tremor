using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class Chainmail : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 18;
			item.value = 600;
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chainmail");
			Tooltip.SetDefault("");
		}

	}
}
