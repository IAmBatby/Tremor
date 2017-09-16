using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GiantShell : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 25000;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Shell");
			Tooltip.SetDefault("");
		}

	}
}
