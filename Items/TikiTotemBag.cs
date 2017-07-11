using Terraria;
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
				player.QuickSpawnItem(mod.ItemType("AngryTotemMask"));
			}
			if (Main.rand.Next(1) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("JungleAlloy"));
			}

			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("HappyTotemMask"));
			}

			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("IndifferentTotemMask"));
			}
			player.QuickSpawnItem(mod.ItemType("ToxicBlade"));

			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("ToxicHilt"));
			}

			player.QuickSpawnItem(mod.ItemType("TikiSkull"));

			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("PickaxeofBloom"));
			}
		}
	}
}
