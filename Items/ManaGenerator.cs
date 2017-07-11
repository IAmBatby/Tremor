using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ManaGenerator : ModItem
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
			item.rare = 9;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 300000;
			item.createTile = mod.TileType("ManaGeneratorTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Generator");
			Tooltip.SetDefault("Decreases mana cost of the player standing near");
		}

	}
}
