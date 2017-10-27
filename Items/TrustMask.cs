using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class TrustMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 32;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doom Mask");
			Tooltip.SetDefault("");
		}

	}
}
