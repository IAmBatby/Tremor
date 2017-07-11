using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
	public class CursedKnightGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 30000;

			item.rare = 9;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cursed Knight Greaves");
      Tooltip.SetDefault("'Great for impersonating devs!'");
    }

	}
}
