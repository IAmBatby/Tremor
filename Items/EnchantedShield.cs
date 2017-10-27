using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class EnchantedShield : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 30;
			item.value = 15000;

			item.rare = 2;
			item.accessory = true;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Shield");
			Tooltip.SetDefault("Increases maximum mana by 40\n" +
"10% decreased magic damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 40;
			player.magicDamage -= 0.1f;
		}
	}
}
