using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientMeteorHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 26;

			item.value = 9000;
			item.rare = 1;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Meteor Helmet");
			Tooltip.SetDefault("7% increased magic damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.07f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 124 && legs.type == 125;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Reduces the mana cost of the Space Gun to zero";
			player.spaceGun = true;
		}
	}
}
