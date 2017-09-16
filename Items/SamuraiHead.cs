using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class SamuraiHead : ModItem
	{

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 20;
			item.value = 100000;
			item.rare = 5;

			item.defense = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Samurai Helmet");
			Tooltip.SetDefault("Increases all damage by 9%");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.09f;
			player.rangedDamage += 0.09f;
			player.thrownDamage += 0.09f;
			player.minionDamage += 0.09f;
			player.magicDamage += 0.09f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("SamuraiChestplate") && legs.type == mod.ItemType("SamuraiGeaves");
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Greatly increased life regeneration!";
			player.crimsonRegen = true;

		}

	}
}
