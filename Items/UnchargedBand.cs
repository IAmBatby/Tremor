using Terraria.ModLoader;

namespace Tremor.Items
{
	public class UnchargedBand : ModItem
	{
		public override void SetDefaults()
		{

			item.rare = 11;
			item.value = 380000;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Uncharged Band");
			Tooltip.SetDefault("Can be charged with fragments\n" +
"Charged band summons a pet");
		}

	}
}
