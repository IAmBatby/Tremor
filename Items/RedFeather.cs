using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RedFeather : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 3000;
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Feather");
			Tooltip.SetDefault("");
		}

	}
}
