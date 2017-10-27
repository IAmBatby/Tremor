using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class LeechingSeed : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 45000;
			item.rare = 6;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leeching Seed");
			Tooltip.SetDefault("Maximum life increased by 50");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 50;
		}
	}
}
