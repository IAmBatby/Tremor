using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SandstoneBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 200;
			item.rare = 2;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.createTile = mod.TileType("SandstoneBar");
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Bar");
			Tooltip.SetDefault("");
		}

	}
}
