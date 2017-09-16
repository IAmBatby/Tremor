using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ButcherMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 20;
			item.value = 20000;
			item.rare = 0;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Butcher Mask");
			Tooltip.SetDefault("");
		}

	}
}
