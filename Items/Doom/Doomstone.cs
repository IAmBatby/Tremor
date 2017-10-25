using Terraria.ModLoader;

namespace Tremor.Items.Doom
{
	public class Doomstone : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 20000;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doomstone");
			Tooltip.SetDefault("");
		}

	}
}
