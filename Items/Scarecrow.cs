using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Scarecrow : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 2500;
			item.createTile = mod.TileType("Scarecrow");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scarecrow");
			Tooltip.SetDefault("");
		}

	}
}
