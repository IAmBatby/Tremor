using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class PaladinHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;

			item.value = 400;
			item.rare = 10;
			item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paladin Helmet");
			Tooltip.SetDefault("30% increased melee speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.30f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PaladinBreastplate") && legs.type == mod.ItemType("PaladinGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a paladin hammer to protect you!";
			player.AddBuff(mod.BuffType("PaladinBuff"), 2);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}
	}
}
