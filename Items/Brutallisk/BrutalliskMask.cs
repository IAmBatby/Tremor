using Terraria.ModLoader;

namespace Tremor.Items.Brutallisk
{
	[AutoloadEquip(EquipType.Head)]
	public class BrutalliskMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brutallisk Mask");
			Tooltip.SetDefault("");
		}

	}
}
