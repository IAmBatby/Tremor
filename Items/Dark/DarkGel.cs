using Terraria.ModLoader;

namespace Tremor.Items.Dark
{
	public class DarkGel : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Gel");
			Tooltip.SetDefault("");
		}

	}
}
