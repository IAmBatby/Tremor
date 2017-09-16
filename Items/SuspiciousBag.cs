using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SuspiciousBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 34;
			item.height = 34;
			item.value = 20000;

			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suspicious Bag");
			Tooltip.SetDefault("Right click to open\n'Contains powerful treasures'");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Doomstone"), Main.rand.Next(2, 5));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("ConcentratedEther"), Main.rand.Next(3, 10));
			}
			if (Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("CandyBar"), Main.rand.Next(2, 6));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("VoidBar"), Main.rand.Next(2, 7));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("NightmareBar"), Main.rand.Next(2, 6));
			}
			if (Main.rand.Next(5) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Phantaplasm"), Main.rand.Next(3, 6));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("CarbonSteel"), Main.rand.Next(1, 3));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("ClusterShard"), Main.rand.Next(3, 36));
			}
			if (Main.rand.Next(8) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("DeadTissue"), 1);
			}
			if (Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("ToothofAbraxas"), Main.rand.Next(2, 4));
			}
			if (Main.rand.Next(30) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Burner"));
			}
		}

	}
}
