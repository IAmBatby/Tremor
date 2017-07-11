using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TikiSkull : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 24;
			item.value = 10000;

			item.rare = 9;
			item.expert = true;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiki Skull");
			Tooltip.SetDefault("10% increased minion damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.1f;
		}
	}
}
