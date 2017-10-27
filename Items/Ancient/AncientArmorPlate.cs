using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	public class AncientArmorPlate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 12000;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Armor Plate");
			Tooltip.SetDefault("");
		}

	}
}
