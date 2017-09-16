using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class ChainGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 14;
			item.value = 600;
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chain Greaves");
			Tooltip.SetDefault("");
		}

	}
}
