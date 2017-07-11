using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PixieQueenBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("PixieQueen");
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
				player.QuickSpawnItem(mod.ItemType("PixieQueenMask"));
			}
			if (Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("EtherealFeather"));
			}
			if (Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("PixiePulse"));
			}
			if (Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("HeartMagnet"));
			}
			if (Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("DopelgangerCandle"));
			}
			player.QuickSpawnItem(mod.ItemType("GlorianaWrath"));
			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("ChaosBar"), Main.rand.Next(15, 25));
		}

	}
}
