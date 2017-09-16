using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BrokenHeroAmulet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;
			item.value = 10000;
			item.rare = 8;
			item.defense = 3;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Hero Amulet");
			Tooltip.SetDefault("");
		}

	}
}
