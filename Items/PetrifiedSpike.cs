using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PetrifiedSpike : ModItem
	{
		public override void SetDefaults()
		{

			item.height = 16;
			item.maxStack = 99;
			item.value = 10;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petrified Spike");
			Tooltip.SetDefault("");
		}

	}
}
