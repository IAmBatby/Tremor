using Terraria;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class SecondHand : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 20;
			item.alpha = 100;
			item.value = 110000;
			item.rare = 10;

			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Second Hand");
			Tooltip.SetDefault("Increases tile and wall placement range");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			Player.tileRangeX += 10;
			Player.tileRangeY += 10;
		}

	}
}
