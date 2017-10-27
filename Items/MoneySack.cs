using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MoneySack : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 32;
			item.height = 32;
			item.rare = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Money Sack");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(71, Main.rand.Next(70, 98));
			player.QuickSpawnItem(72, Main.rand.Next(50, 75));
			player.QuickSpawnItem(73);
			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(73, Main.rand.Next(1, 3));
			}
			if (Main.rand.NextBool(5))
			{
				player.QuickSpawnItem(73, Main.rand.Next(5, 7));
			}
			if (Main.rand.Next(25) == 0)
			{
				player.QuickSpawnItem(73, Main.rand.Next(10, 15));
			}
		}

	}
}
