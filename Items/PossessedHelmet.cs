using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class PossessedHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 18;
			item.value = 100;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Possessed Helmet");
			Tooltip.SetDefault("");
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PossessedChestplate") && legs.type == mod.ItemType("PossessedGreaves");
		}
	}
}
