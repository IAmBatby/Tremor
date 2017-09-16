using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GreenPuzzleFragment : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 10000;
			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Puzzle Fragment");
			Tooltip.SetDefault("");
		}

	}
}
