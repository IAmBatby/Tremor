using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ToothofAbraxas : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 19000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tooth of Abraxas");
			Tooltip.SetDefault("");
		}

	}
}
