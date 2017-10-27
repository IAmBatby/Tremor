using Terraria.ModLoader;

namespace Tremor.Items.Sandstone
{
	public class SandstoneBookcase : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 42;
			item.height = 16;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
			item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("SandstoneBookcase");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Bookcase");
			Tooltip.SetDefault("");
		}

	}
}
