using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class SpinalMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;

			item.height = 26;
			item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spinal111 Mask");
			Tooltip.SetDefault("'Great for impersonating YouTubers!'");
		}

	}
}
