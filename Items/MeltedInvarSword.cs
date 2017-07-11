using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MeltedInvarSword : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;
			item.maxStack = 99;
			item.value = 25;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Melted Invar Sword");
			Tooltip.SetDefault("");
		}


	}
}
