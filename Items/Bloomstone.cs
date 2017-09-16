using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Bloomstone : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;
			item.value = 50000;

			item.rare = 1;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloomstone");
			Tooltip.SetDefault("You are glowing during night");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (!Main.dayTime)
			{
				player.AddBuff(11, 10);
				player.AddBuff(12, 10);
			}
		}
	}
}
