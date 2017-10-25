using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Orcish
{
	[AutoloadEquip(EquipType.Body)]
	public class OrcishBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;

			item.value = 600;
			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Breastplate");
			Tooltip.SetDefault("15% increased melee speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.15f;
		}

	}
}
