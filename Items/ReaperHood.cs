using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ReaperHood : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 22;

			item.value = 10000;
			item.rare = 5;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reaper Hood");
			Tooltip.SetDefault("15% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.15f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ReaperBreastplate") && legs.type == mod.ItemType("ReaperGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "30% increased alchemical critical strike chance";
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 30;
		}
	}
}
