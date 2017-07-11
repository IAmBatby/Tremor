using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AngryShard : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 22;
			item.maxStack = 999;
			item.rare = 10;
			item.value = Item.buyPrice(0, 10, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angry Shard");
			Tooltip.SetDefault("");
		}

	}
}
