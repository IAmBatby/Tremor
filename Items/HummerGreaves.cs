using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class HummerGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;

			item.height = 18;
			item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hummer's Greaves");
			Tooltip.SetDefault("'Great for impersonating devs!'");
		}

	}
}
