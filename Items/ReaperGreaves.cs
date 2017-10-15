using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class ReaperGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 10000;
			item.rare = 2;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reaper Greaves");
			Tooltip.SetDefault("15% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.15f;
		}

	}
}
