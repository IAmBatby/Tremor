using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Invar
{
	public class InvarBar : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = Item.sellPrice(silver: 1, copper: 25);
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invar Bar");
			Tooltip.SetDefault("Can be used to make Invar equipment at an anvil");
		}

		public override void AddRecipes()
		{

		}
	}
}
