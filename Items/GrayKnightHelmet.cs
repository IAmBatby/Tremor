using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class GrayKnightHelmet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 22;

			item.value = 10000;
			item.rare = 2;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gray Knight Helmet");
			Tooltip.SetDefault("Can be colored with gems");
		}

	}
}
