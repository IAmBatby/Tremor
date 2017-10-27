using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class VultureFeather : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;
			item.value = 100;
			item.rare = 2;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vulture Feather");
			Tooltip.SetDefault("15% increased movement speed");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 0.15f;
			player.maxRunSpeed += 0.15f;
		}
	}
}
