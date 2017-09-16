using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DeadTissue : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 12000;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dead Tissue");
			Tooltip.SetDefault("");
		}

	}
}
