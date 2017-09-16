using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class PixieQueenMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 22;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixie Queen Mask");
			Tooltip.SetDefault("");
		}

	}
}
