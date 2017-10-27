using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DelightfulClump : ModItem
	{
		public override void SetDefaults()
		{

			item.accessory = true;
			item.width = 22;
			item.height = 18;
			item.value = 250000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Delightful Clump");
			Tooltip.SetDefault("Increases maximum life by 100\n" +
"15% increased critical strike chance");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 100;
			player.rangedCrit += 5;
			player.meleeCrit += 5;
			player.magicCrit += 5;
			player.thrownCrit += 5;
		}

	}
}
