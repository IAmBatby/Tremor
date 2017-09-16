using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class TruthMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 28;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Truth Mask");
			Tooltip.SetDefault("");
		}

	}
}
