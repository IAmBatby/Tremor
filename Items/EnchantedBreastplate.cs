using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class EnchantedBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 20;
			item.value = 10000;

			item.rare = 2;
			item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Breastplate");
			Tooltip.SetDefault("Increases maximum mana by 20\n" +
"Increases maximum health by 20");
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 20;
			player.statLifeMax2 += 20;
		}
	}
}
