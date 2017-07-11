using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class SpikeShield : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 26;
			item.value = 32000;
			item.rare = 0;

			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiky Shield");
			Tooltip.SetDefault("Allows you to prick foes");
		}

		public override void UpdateEquip(Player player)
		{
			player.thorns = 1;
		}
	}
}
