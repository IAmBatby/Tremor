using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Dark
{
	public class DarkEmperorBag : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("TheDarkEmperorTwo");
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
				player.QuickSpawnItem(mod.ItemType("DarkEmperorMask"));
			}
			if (Main.rand.NextBool(5))
			{
				player.QuickSpawnItem(mod.ItemType("DrippingScythe"));
			}
			if (Main.rand.NextBool(5))
			{
				player.QuickSpawnItem(mod.ItemType("DelightfulClump"));
			}
			if (Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("NastyJavelin"), Main.rand.Next(30, 50));
			}
			player.QuickSpawnItem(mod.ItemType("SuperBigCannon"));
			player.QuickSpawnItem(mod.ItemType("SBCCannonballAmmo"), Main.rand.Next(50, 150));
			player.QuickSpawnItem(mod.ItemType("DarkGel"), Main.rand.Next(50, 100));
			player.QuickSpawnItem(mod.ItemType("SoulofFight"), Main.rand.Next(20, 30));

			if (Main.hardMode)
			{
				player.TryGettingDevArmor();
			}
		}
	}
}
