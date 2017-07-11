using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EyeMonolith : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 62;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;

			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
                        item.rare = 3;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("EyeMonolithTile");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Eye Monolith");
      Tooltip.SetDefault("15% increased minion damage if placed");
    }


	}
}
