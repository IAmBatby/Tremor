using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class WickedHeart : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wicked Heart");
			Tooltip.SetDefault("");
		}
	}
}
