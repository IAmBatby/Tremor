using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class VultureKingMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 22;
			item.value = 20000;
			item.rare = 0;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rukh Mask");
			Tooltip.SetDefault("");
		}

	}
}
