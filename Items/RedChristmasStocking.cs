using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RedChristmasStocking : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 26;
			item.maxStack = 99;
			item.rare = 1;
			item.createTile = mod.TileType("RedChristmasStocking");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.value = 100;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Christmas Stocking");
			Tooltip.SetDefault("");
		}

	}
}
