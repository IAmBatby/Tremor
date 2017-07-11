using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StoneofLife : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 16;
			item.maxStack = 99;
			item.value = 500;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone of Life");
			Tooltip.SetDefault("");
		}

	}
}
