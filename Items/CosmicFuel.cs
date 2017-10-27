using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CosmicFuel : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 20;

			item.value = 10000000;
			item.rare = 11;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Fuel");
			Tooltip.SetDefault("'Infinity energy!'");
		}

	}
}
