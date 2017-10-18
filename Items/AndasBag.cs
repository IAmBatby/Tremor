using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AndasBag : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("TrueAndas");
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
			switch (Main.rand.Next(4))
			{
				case 0:
					player.QuickSpawnItem(mod.ItemType("GehennaStaff"));
					break;
				case 1:
					player.QuickSpawnItem(mod.ItemType("VulcanBlade"));
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("Pandemonium"));
					break;
				case 3:
					player.QuickSpawnItem(mod.ItemType("HellStorm"));
					break;
				case 4:
					player.QuickSpawnItem(mod.ItemType("Inferno"));
					break;
			}

			if (Main.rand.NextBool(7))
			{
				player.QuickSpawnItem(mod.ItemType("AndasMask"));
			}

			if (Main.hardMode)
			{
				player.TryGettingDevArmor();
			}
			player.QuickSpawnItem(mod.ItemType("AndasCore"));
			player.QuickSpawnItem(3544, Main.rand.Next(10, 25));
			player.QuickSpawnItem(mod.ItemType("InfernoSoul"), Main.rand.Next(8, 15));
		}
	}
}
