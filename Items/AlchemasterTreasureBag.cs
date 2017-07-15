using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AlchemasterTreasureBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Alchemaster");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right click to open");
		}


		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("AlchemasterMask"));
			}
			if (Main.rand.Next(10) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("AlchemasterTrophy"));
			}
			if (Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("PlagueFlask"), Main.rand.Next(30, 78));
			}
			if (Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("SparkingFlask"), Main.rand.Next(30, 78));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("TheGlorch"));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BadApple"));
			}
			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("GoldenStar"));
			player.QuickSpawnItem(mod.ItemType("LongFuse"));
		}

	}
}
