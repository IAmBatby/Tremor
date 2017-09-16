using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Phantaplasm : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 36;
			item.height = 52;
			item.maxStack = 99;
			item.value = 15000;
			item.rare = 10;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alphaplasm");
			Tooltip.SetDefault("");
		}

	}
}
