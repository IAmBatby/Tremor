using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
[AutoloadEquip(EquipType.Head)]
	public class PurpleShelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 22;
			item.value = 5000;
			item.rare = 2;
			item.defense = 6;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Purple Shelmet");
      Tooltip.SetDefault("");
    }

	}
}
