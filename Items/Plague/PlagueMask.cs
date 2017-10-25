using Terraria.ModLoader;

namespace Tremor.Items.Plague
{
	[AutoloadEquip(EquipType.Head)]
	public class PlagueMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;

			item.rare = 2;
			item.value = 10000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plague Mask");
			Tooltip.SetDefault("'HEE HEE HEE'");
		}

	}
}
