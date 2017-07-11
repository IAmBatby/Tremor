using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class VultureKingBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("npcVultureKing");
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
				player.QuickSpawnItem(mod.ItemType("VultureKingMask"));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("CactusBow"));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SandKnife"));
			}
			if (Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("VultureFeather"));
			}
			if (Main.rand.Next(1) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SandstoneBar"), Main.rand.Next(10, 18));
			}
			player.QuickSpawnItem(mod.ItemType("DesertClaymore"));
		}
	}
}
