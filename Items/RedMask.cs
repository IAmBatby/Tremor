using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class RedMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.value = 1000;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red's Mask");
			Tooltip.SetDefault("");
		}

	}
}
