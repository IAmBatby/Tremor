using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class PaladinBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;

			item.value = 600000;
			item.rare = 10;
			item.defense = 32;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paladin Breastplate");
			Tooltip.SetDefault("25% increased melee critical strike chance");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 25;
		}
	}
}
