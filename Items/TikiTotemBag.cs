using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TikiTotemBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("TikiTotem");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiki Totem Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}


		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			object[,] drops = new object[,]
			{
				// item, chance, stack
				{"ToxicBlade", 3, 1},
				{"JungleAlloy", 1, 1},
				{"TikiSkull", 1, 1}, // only specific one
				{"PickaxeofBloom", 3, 1},
				{"ToxicHilt", 4, 1},
				{"AngryTotemMask", 7, 1},
				{"HappyTotemMask", 7, 1},
				{"IndifferentTotemMask", 7, 1},
				{ItemID.HealingPotion, 1, Main.rand.Next(5, 16)},
				{ItemID.ManaPotion, 1, Main.rand.Next(5, 16)},
			};

			for (int i = 0; i < drops.GetUpperBound(0); i++)
			{
				if (Main.rand.NextBool((int)drops[i, 1]))
				{
					object drop = drops[i, 0];
					if (drop is string)
						player.QuickSpawnItem(mod.ItemType((string)drop), (int)drops[i, 2]);
					else if (drop is int)
						player.QuickSpawnItem((int)drop, (int)drops[i, 2]);
				}
			}
		}
	}
}
