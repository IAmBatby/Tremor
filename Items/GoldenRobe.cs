using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class GoldenRobe : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 250;

			item.height = 28;
			item.value = 35000;
			item.rare = 2;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Robe");
			Tooltip.SetDefault("5% decreased magic damage\n" +
"Increases maximum mana by 40");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage -= 0.05f;
			player.statManaMax2 += 40;
		}
	}
}
