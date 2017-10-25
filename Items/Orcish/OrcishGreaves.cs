using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Orcish
{
	[AutoloadEquip(EquipType.Legs)]
	public class OrcishGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 500;

			item.rare = 1;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Greaves");
			Tooltip.SetDefault("7% increased melee damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.07f;
		}

	}
}
