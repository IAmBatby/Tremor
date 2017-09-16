using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EvilCup : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 10000;
			item.rare = 3;
			item.maxStack = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evil Cup");
			Tooltip.SetDefault("Increases monsters spawn rate");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.enemySpawns = true;
		}
	}
}
