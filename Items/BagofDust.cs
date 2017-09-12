using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BagofDust : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 36;
			item.value = 10000;
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bag of Dust");
			Tooltip.SetDefault("Used for crafting bags with a variety of dust");
		}
	}
}
