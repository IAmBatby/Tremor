using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class HummerBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 34;
			item.height = 18;
			item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hummer's Breastplate");
			Tooltip.SetDefault("'Great for impersonating devs!'");
		}

		public override void UpdateEquip(Player player)
		{
			if (player.name == "Hummer")
			{
				player.lifeRegen = +999;
			}
		}
	}
}
