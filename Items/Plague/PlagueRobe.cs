using Terraria.ModLoader;

namespace Tremor.Items.Plague
{
	[AutoloadEquip(EquipType.Body)]
	public class PlagueRobe : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;

			item.rare = 2;
			item.value = 10000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plague Robe");
			Tooltip.SetDefault("'HEE HEE HEE'");
		}

	}
}
