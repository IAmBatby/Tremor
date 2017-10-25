using Terraria.ModLoader;

namespace Tremor.Items.Cursed
{
	[AutoloadEquip(EquipType.Head)]
	public class CursedKnightHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 30000;

			item.rare = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Knight Helmet");
			Tooltip.SetDefault("'Great for impersonating devs!'");
		}

	}
}
