using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class OrcishHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;

			item.value = 400;
			item.rare = 1;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Helmet");
			Tooltip.SetDefault("7% increased melee damage");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.07f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("OrcishBreastplate") && legs.type == mod.ItemType("OrcishGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increased maximum defense by 2";
			player.statDefense += 2;
			player.moveSpeed -= 0.1f;
		}

	}
}
