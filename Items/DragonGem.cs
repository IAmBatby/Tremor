using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DragonGem : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.value = 30000;

			item.rare = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Gem");
			Tooltip.SetDefault("Increases regeneration during night");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (!Main.dayTime)
			{
				player.lifeRegen += 1;
			}
		}
	}
}
