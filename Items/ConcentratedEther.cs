using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ConcentratedEther : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 15000;
			item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Concentrated Ether");
			Tooltip.SetDefault("");
		}

	}
}
