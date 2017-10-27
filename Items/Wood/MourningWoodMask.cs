using Terraria.ModLoader;

namespace Tremor.Items.Wood
{
	[AutoloadEquip(EquipType.Head)]
	public class MourningWoodMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 24;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mourning Wood Mask");
			Tooltip.SetDefault("");
		}

	}
}
