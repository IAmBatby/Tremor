using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ExtraterrestrialRubies : ModItem
	{
		public override void SetDefaults()
		{

			item.accessory = true;
			item.width = 22;
			item.height = 18;
			item.value = 10000000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Extraterrestrial Rubies");
			Tooltip.SetDefault("Increases maximum life by 100\n" +
"Greatly increases life regeneration");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 100;
			player.lifeRegen = +20;
		}

	}
}
