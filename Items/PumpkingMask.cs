using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class PumpkingMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pumpking Mask");
			Tooltip.SetDefault("");
		}

	}
}
