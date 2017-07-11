using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class EnchantedHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 24;


			item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Helmet");
			Tooltip.SetDefault("Increases maximum mana by 20\nIncreases maximum health by 15");
		}


		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 20;
			player.statLifeMax2 += 15;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("EnchantedBreastplate") && legs.type == mod.ItemType("EnchantedGreaves");
		}


		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "8% increased magic damage, increases power of enchanted weapons";
			player.magicDamage += 0.08f;
			player.AddBuff(mod.BuffType("EnchantedBuff"), 2);
		}

	}
}
