using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SwampClump : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;
			item.value = 100;
			item.rare = 7;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Swamp Clump");
			Tooltip.SetDefault("Greatly reduces movement speed\n" +
"Prolonged after hit invicibility\n" +
"Greatly increases life regeneration");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed -= 0.4f;
			player.longInvince = true;
			player.lifeRegen += 5;
		}
	}
}
