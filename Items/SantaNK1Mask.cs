using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class SantaNK1Mask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 34;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Santa-NK1 Mask");
			Tooltip.SetDefault("");
		}

	}
}
