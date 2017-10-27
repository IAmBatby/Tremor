using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class HummerHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;

			item.height = 26;
			item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hummer's Helmet");
			Tooltip.SetDefault("'Great for impersonating devs!'");
		}

	}
}
