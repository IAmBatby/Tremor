using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class TornPapyrus : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.rare = 2;
			item.value = 6000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Papyrus");
			Tooltip.SetDefault("");
		}
	}
}
