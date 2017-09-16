using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class HopeMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 30;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hope Mask");
			Tooltip.SetDefault("");
		}

	}
}
