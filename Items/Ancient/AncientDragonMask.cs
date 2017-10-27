using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientDragonMask : ModItem
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
			DisplayName.SetDefault("Ancient Dragon Mask");
			Tooltip.SetDefault("");
		}

	}
}
