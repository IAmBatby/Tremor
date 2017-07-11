using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CyberKingBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("CyberKing");
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
				player.QuickSpawnItem(mod.ItemType("CyberKingMask"));
			}
			switch (Main.rand.Next(4))
			{
				case 0:
					player.QuickSpawnItem(mod.ItemType("RedStorm"));
					break;
				case 1:
					player.QuickSpawnItem(mod.ItemType("CyberCutter"));
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("ShockwaveClaymore"));
					break;
			}
			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("CyberStaff"));
		}

	}
}
