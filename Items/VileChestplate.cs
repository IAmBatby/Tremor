using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class VileChestplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 30000;
			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vile Chestplate");
			Tooltip.SetDefault("8% increased minion damage\n" +
"Increases your max number of minions");
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.08f;
		}

	}
}
