using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class TimeTissue : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;

			item.maxStack = 99;
			item.value = 10000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Time Tissue");
			Tooltip.SetDefault("'It's about time'.");
		}

	}
}
