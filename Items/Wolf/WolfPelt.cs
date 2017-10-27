using Terraria.ModLoader;

namespace Tremor.Items.Wolf
{
	public class WolfPelt : ModItem
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
			item.createTile = mod.TileType("WolfPelt");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wolf Pelt");
			Tooltip.SetDefault("");
		}

	}
}
