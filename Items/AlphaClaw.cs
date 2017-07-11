using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AlphaClaw : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;

			item.maxStack = 99;
			item.value = 10;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alpha Claw");
			Tooltip.SetDefault("A claw of a powerful wolf");
		}

	}
}
