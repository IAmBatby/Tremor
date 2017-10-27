using Terraria.ModLoader;

namespace Tremor.Items.RedSteel
{
	public class ChippyRedSteelSword : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 50;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chippy Red Steel Sword");
			Tooltip.SetDefault("");
		}
	}
}
