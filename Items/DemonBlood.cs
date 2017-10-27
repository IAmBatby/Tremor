using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DemonBlood : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 26;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon Blood");
			Tooltip.SetDefault("");
		}

	}
}
