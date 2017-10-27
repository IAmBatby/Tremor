using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Crystal
{
	public class ChargedCrystal : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 22;
			item.maxStack = 999;
			item.rare = 11;
			item.value = Item.buyPrice(0, 1, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charged Crystal");
			Tooltip.SetDefault("");
		}

	}
}
