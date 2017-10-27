using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Dark
{
	public class DarkMass : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 20;
			item.value = 100000;
			item.rare = 11;
			item.maxStack = 99;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Mass");
			Tooltip.SetDefault("");
		}

	}
}
