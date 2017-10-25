using Terraria.ModLoader;

namespace Tremor.Items.Dark
{
	public class DarknessCloth : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 600;
			item.rare = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Cloth");
			Tooltip.SetDefault("");
		}

	}
}
