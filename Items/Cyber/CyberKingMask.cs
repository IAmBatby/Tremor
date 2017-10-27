using Terraria.ModLoader;

namespace Tremor.Items.Cyber
{
	[AutoloadEquip(EquipType.Head)]
	public class CyberKingMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyber King Mask");
			Tooltip.SetDefault("");
		}

	}
}
