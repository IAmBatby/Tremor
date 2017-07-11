using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class VileHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;


			item.value = 30000;
			item.rare = 1;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vile Helmet");
			Tooltip.SetDefault("6% increased minion damage\nIncreases your max number of minions");
		}


		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("VileChestplate") && legs.type == mod.ItemType("VileLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increased maximum defense by 2";
			player.statDefense += 2;
		}

	}
}
