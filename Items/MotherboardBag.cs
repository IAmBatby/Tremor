using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MotherboardBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Motherboard");
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
			player.QuickSpawnItem(3355);
			if (Main.rand.Next(1) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SoulofMind"), Main.rand.Next(20, 40));
			}
			if (Main.rand.Next(1) == 0)
			{
				player.QuickSpawnItem(499, Main.rand.Next(5, 15));
			}
			if (Main.rand.Next(1) == 0)
			{
				player.QuickSpawnItem(1225, Main.rand.Next(15, 35)); ;
			}
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("MotherboardMask"));
			}
			player.TryGettingDevArmor();
		}

	}
}
