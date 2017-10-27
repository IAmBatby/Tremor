using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class Rupicide : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rupicide");
			Tooltip.SetDefault("");
		}
	}
}
