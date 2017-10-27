using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class SniperBoots : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 1000000;

			item.rare = 11;
			item.defense = 32;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sniper Boots");
			Tooltip.SetDefault("15% increased ranged damage\n" +
"20% decreased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage *= 1.15f;
			player.moveSpeed -= 0.20f;
		}

	}
}
