using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TechnologyofDionysus : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;

			item.value = 100000;
			item.rare = 6;
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Technology of Dionysus");
			Tooltip.SetDefault("Enemies are less likely to target you");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.aggro -= 400;
		}
	}
}
