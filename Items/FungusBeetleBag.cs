using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FungusBeetleBag : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("FungusBeetle");
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
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("FungusBeetleMask"));
			}
			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("GoldenGlowingRing"));
			player.QuickSpawnItem(mod.ItemType("FungusElement"), Main.rand.Next(10, 32));
		}
	}
}
