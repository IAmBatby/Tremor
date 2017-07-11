using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	class CornSeed : ModItem
	{
		public override void SetDefaults()
		{
			Tile tile = new Tile();

			item.maxStack = 999;
			item.height = 2;
			item.width = 2;
			item.createTile = mod.TileType("Corn");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.value = 100;
			item.useTime = 10;
			item.useStyle = 1;
			item.rare = 2;
			item.consumable = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corn Seeds");
			Tooltip.SetDefault("");
		}


	}
}
