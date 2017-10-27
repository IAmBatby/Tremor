using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;
using Tremor.Items.Souls;

namespace Tremor.NPCs.Bosses.Motherboard.Items
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
			bossBagNPC = mod.NPCType<global::Tremor.NPCs.Bosses.Motherboard.Motherboard>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Motherboard Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		
		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.QuickSpawnItem(ItemID.MechanicalWagonPiece);
			player.QuickSpawnItem(mod.ItemType<SoulofMind>(), Main.rand.Next(20, 41));
			player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
			player.QuickSpawnItem(ItemID.HallowedBar, Main.rand.Next(15, 36));

			if (Main.rand.NextBool(7))
			{
				player.QuickSpawnItem(mod.ItemType<MotherboardMask>());
			}

			if (Main.hardMode)
			{
				player.TryGettingDevArmor();
			}
		}

	}
}
