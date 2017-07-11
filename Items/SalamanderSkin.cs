using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SalamanderSkin : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 40;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.rare = 1;
			item.createTile = mod.TileType("SalamanderSkinTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Salamander Skin");
			Tooltip.SetDefault("");
		}

	}
}
