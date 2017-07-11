using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GreatAnvil : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 50;
			item.height = 26;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;

			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("GreatAnvilTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Great Anvil");
			Tooltip.SetDefault("Allows to produce heavy weapons");
		}


	}
}
