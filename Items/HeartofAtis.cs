using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HeartofAtis : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 1200;
			item.rare = 2;
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of Atis");
			Tooltip.SetDefault("Increases life regeneration");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 1;
		}
	}
}
