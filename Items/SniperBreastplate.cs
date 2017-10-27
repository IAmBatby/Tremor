using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class SniperBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 22;

			item.value = 1000000;
			item.rare = 11;
			item.defense = 40;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sniper Breastplate");
			Tooltip.SetDefault("20% increased ranged damage\n" +
"20% decreased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage *= 1.2f;
			player.moveSpeed -= 0.20f;
		}

	}
}
