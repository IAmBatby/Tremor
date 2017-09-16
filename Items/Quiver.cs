using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Quiver : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.value = 12000;

			item.rare = 1;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quiver");
			Tooltip.SetDefault("20% chance not to consume ammo");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.ammoCost80 = true;
		}
	}
}
