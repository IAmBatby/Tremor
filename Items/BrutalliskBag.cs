using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BrutalliskBag : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Brutallisk");
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
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BrutalliskMask"));
			}
			if (Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Awakening"));
			}
			if (Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SnakeDevourer"));
			}
			if (Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("LightningStaff"));
			}
			if (Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("QuetzalcoatlStave"));
			}
			if (Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("TreasureGlaive"));
			}
			if (Main.rand.Next(25) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("FallenSnake"));
			}
			if (Main.rand.Next(100) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("StrangeEgg"));
			}
			player.QuickSpawnItem(mod.ItemType("BrutalliskCrystal"));
			player.QuickSpawnItem(mod.ItemType("Aquamarine"), Main.rand.Next(10, 18));
			if (Main.hardMode)
			{
				player.TryGettingDevArmor();
			}
		}
	}
}
