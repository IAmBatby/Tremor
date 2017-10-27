using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HeartMagnet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 12000;
			item.rare = 3;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart Magnet");
			Tooltip.SetDefault("Increased heart pickup range");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeMagnet = true;
		}
	}
}
