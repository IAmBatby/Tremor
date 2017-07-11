using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WallofShadowBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("WallOfShadow");
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
			switch (Main.rand.Next(4))
			{
				case 0:
					player.QuickSpawnItem(mod.ItemType("HeavyBeamCannon"));
					break;
				case 1:
					player.QuickSpawnItem(mod.ItemType("Bolter"));
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("StrikerBlade"));
					break;
			}

			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("WallofShadowMask"));
			}

			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("WallOfShadowsFlask"));
			player.QuickSpawnItem(mod.ItemType("DarknessCloth"), Main.rand.Next(8, 15));
			player.QuickSpawnItem(499, Main.rand.Next(5, 15));
		}

	}
}
