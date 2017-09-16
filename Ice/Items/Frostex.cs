using Terraria;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class Frostex : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 12000;
			item.rare = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostex");
			Tooltip.SetDefault("10% increased melee and ranged damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.1f;
			player.rangedDamage += 0.1f;
		}
	}
}
