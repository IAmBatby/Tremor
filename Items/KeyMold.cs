using Terraria.ModLoader;

namespace Tremor.Items
{
	public class KeyMold : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 40;
			item.maxStack = 99;
			item.value = 300000;
			item.rare = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Key Mold");
			Tooltip.SetDefault("");
		}

	}
}
