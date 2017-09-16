using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class PaladinGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 500000;

			item.rare = 10;
			item.defense = 28;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paladin Greaves");
			Tooltip.SetDefault("22% increased melee damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.22f;
		}
	}
}
