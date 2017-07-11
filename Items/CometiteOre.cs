using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CometiteOre : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.value = 10000;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.rare = 11;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("CometiteOreTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cometite Ore");
			Tooltip.SetDefault("'Ore from the depths of space'");
		}

	}
}
