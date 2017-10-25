using Terraria.ModLoader;

namespace Tremor.Items.Chaos
{
	public class ChaosBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 500;
			item.rare = 5;
			item.createTile = mod.TileType("ChaosBar");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Bar");
			Tooltip.SetDefault("");
		}

	}
}
