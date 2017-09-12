using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AncientDragonBag : ModItem
	{
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;

			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Dragon_HeadB");
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
			switch (Main.rand.Next(4))
			{
				case 0:
					player.QuickSpawnItem(mod.ItemType("DragonHead"));
					break;
				case 1:
					player.QuickSpawnItem(mod.ItemType("Swordstorm"));
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("AncientTimesEdge"));
					break;
			}

			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("AncientDragonMask"));
			}

			player.TryGettingDevArmor();
			player.QuickSpawnItem(mod.ItemType("AncientSoul"));
			player.QuickSpawnItem(188, Main.rand.Next(5, 15));
		}

	}
}
