using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	public class AncientTechnology : ModItem
	{
		public override void SetDefaults()
		{

			item.height = 16;
			item.maxStack = 20;
			item.value = 1000000;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Technology");
			Tooltip.SetDefault("");
		}

	}
}
