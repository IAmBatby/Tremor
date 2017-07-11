using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RockHorn : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 22;
			item.maxStack = 999;
			item.rare = 3;
			item.value = Item.buyPrice(0, 0, 5, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rock Horn");
			Tooltip.SetDefault("");
		}

	}
}
