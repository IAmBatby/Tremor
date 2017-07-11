using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FrostoneOre : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.rare = 7;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("FrostoneOreTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostone Ore");
			Tooltip.SetDefault("");
		}


	}
}
