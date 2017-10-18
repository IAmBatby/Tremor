using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FrostKingBag : ModItem
	{
		public override void SetDefaults()
		{

			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("FrostKing");
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
				player.QuickSpawnItem(mod.ItemType("FrostKingMask"));
			}
			player.QuickSpawnItem(mod.ItemType("EdgeofFrostKing"));
			player.QuickSpawnItem(mod.ItemType("FrostoneOre"), Main.rand.Next(24, 42));
			if (Main.hardMode)
			{
				player.TryGettingDevArmor();
			}
		}

	}
}
