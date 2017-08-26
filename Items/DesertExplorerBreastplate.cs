using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class DesertExplorerBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;


			item.value = 16500;
			item.rare = 8;
			item.defense = 17;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Explorer Breastplate");
			Tooltip.SetDefault("Increases alchemic damage by 19%\nIncreases throwing damage by 35%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.5f;
			player.thrownDamage += 0.35f;
		}
	}
}
