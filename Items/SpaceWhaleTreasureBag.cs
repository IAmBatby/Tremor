using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SpaceWhaleTreasureBag : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("SpaceWhale");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			if (Main.rand.NextBool(7))
			{
				player.QuickSpawnItem(mod.ItemType("SpaceWhaleMask"));
			}

			if (Main.rand.NextBool(5))
			{
				player.QuickSpawnItem(mod.ItemType("StarLantern"));
			}

			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("SDL"));
			}

			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("BlackHoleCannon"));
			}

			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("HornedWarHammer"));
			}

			if (Main.rand.NextBool(8))
			{
				player.QuickSpawnItem(mod.ItemType("WhaleFlippers"));
			}
			player.QuickSpawnItem(mod.ItemType("LasCannon"));

			player.QuickSpawnItem(mod.ItemType("CosmicFuel"));
		}
	}
}
