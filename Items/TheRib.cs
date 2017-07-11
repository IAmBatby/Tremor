using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TheRib : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Rib");
			Tooltip.SetDefault("");
		}

	}
}
