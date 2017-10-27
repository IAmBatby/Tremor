using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Sandstone
{
	public class SandstoneRing : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 20;
			item.value = 10000;

			item.rare = 1;
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstone Ring ");
			Tooltip.SetDefault("5% increased melee damage\n" +
"Increases melee critical strike chance by 5");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.meleeDamage += 0.05f;
			player.meleeCrit += 5;
		}
	}
}
