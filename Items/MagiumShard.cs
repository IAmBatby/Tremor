using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MagiumShard : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 120;
			item.rare = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magium Shard");
			Tooltip.SetDefault("");
		}

	}
}
