using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class CursedInk : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Ink");
			Tooltip.SetDefault("");
		}
	}
}
