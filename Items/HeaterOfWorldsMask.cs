using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class HeaterOfWorldsMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 32;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heater of Worlds Mask");
			Tooltip.SetDefault("");
		}

	}
}
