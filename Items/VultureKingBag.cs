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
				player.QuickSpawnItem(mod.ItemType("VultureKingMask"));
			}
			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("CactusBow"));
			}
			if (Main.rand.NextBool(3))
			{
				player.QuickSpawnItem(mod.ItemType("SandKnife"));
			}
			if (Main.rand.NextBool(4))
			{
				player.QuickSpawnItem(mod.ItemType("VultureFeather"));
			}
			if (Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("SandstoneBar"), Main.rand.Next(10, 18));
			}
			player.QuickSpawnItem(mod.ItemType("DesertClaymore"));
		}
	}
}
