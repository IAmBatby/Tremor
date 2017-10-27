using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Archer
{
	public class ArcherGlove : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.value = 6000;

			item.rare = 1;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archer Glove");
			Tooltip.SetDefault("5% increased ranged damage");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.rangedDamage += 0.05f;
		}
	}
}
