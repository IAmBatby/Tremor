using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class ParadoxCohortMusicBox : ModItem
	{
		public override void SetDefaults()
		{

			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("ParadoxCohortMusicBoxTile");
			item.width = 24;
			item.height = 24;
			item.rare = 4;
			item.value = 100000;
			item.accessory = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Music Box (Paradox Cohort)");
      Tooltip.SetDefault("");
    }

	}
}
