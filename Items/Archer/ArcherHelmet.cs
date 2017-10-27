using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Archer
{
	[AutoloadEquip(EquipType.Head)]
	public class ArcherHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 22;
			item.value = 1000;
			item.rare = 2;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archer Helmet");
			Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ArcherChainmail") && legs.type == mod.ItemType("ArcherGreaves");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
	}
}
