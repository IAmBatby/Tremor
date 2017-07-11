using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
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
				player.QuickSpawnItem(mod.ItemType("DarkEmperorMask"));
			}
			if (Main.rand.Next(5) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("DrippingScythe"));
			}
			if (Main.rand.Next(5) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("DelightfulClump"));
			}
			if (Main.rand.Next(1) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("NastyJavelin"), Main.rand.Next(30, 50));
			}
			player.QuickSpawnItem(mod.ItemType("SuperBigCannon"));
			player.QuickSpawnItem(mod.ItemType("SBCCannonballAmmo"), Main.rand.Next(50, 150));
			player.QuickSpawnItem(mod.ItemType("DarkGel"), Main.rand.Next(50, 100));
			player.QuickSpawnItem(mod.ItemType("SoulofFight"), Main.rand.Next(20, 30));
		}
	}
}
