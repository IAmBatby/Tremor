using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ArgiteOre : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 3;
			item.createTile = mod.TileType("ArgiteOre");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Argite Ore");
			Tooltip.SetDefault("");
		}

	}
}
