using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StormJellyfishBag : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("StormJellyfish");
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
				player.QuickSpawnItem(mod.ItemType("StormJellyfishMask"));
			}
			if (Main.rand.NextBool(4))
			{
				player.QuickSpawnItem(mod.ItemType("StormBlade"));
			}
			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("Poseidon"));
			}
			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("JellyfishStaff"));
			}
			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("BoltTome"));
			}
			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("StickyFlail"));
			}
			player.QuickSpawnItem(mod.ItemType("EnchantedHourglass"));
		}
	}
}
