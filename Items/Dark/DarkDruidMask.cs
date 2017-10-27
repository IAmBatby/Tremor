using Terraria.ModLoader;

namespace Tremor.Items.Dark
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkDruidMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 36;
			item.height = 26;
			item.value = 2500;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Druid Mask");
			Tooltip.SetDefault("");
		}

	}
}
