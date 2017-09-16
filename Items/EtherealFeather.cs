using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EtherealFeather : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 1000;
			item.rare = 3;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ethereal Feather");
			Tooltip.SetDefault("Allows you to fall slowly");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.slowFall = true;
		}
	}
}
