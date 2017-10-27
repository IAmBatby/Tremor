using Terraria.ModLoader;

namespace Tremor.Items.Orcish
{
	[AutoloadEquip(EquipType.Shield)]
	public class OrcishShield : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 30;
			item.value = 110;
			item.rare = 1;
			item.accessory = true;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Shield");
			Tooltip.SetDefault("");
		}

	}
}
