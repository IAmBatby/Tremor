using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SkullTeeth : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;

			item.maxStack = 99;
			item.value = 8000;
			item.rare = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull Teeth");
			Tooltip.SetDefault("'Hell yeah!'");
		}

	}
}
