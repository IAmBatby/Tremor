using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ChainCoif : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 24;
			item.value = 600;
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chain Coif");
			Tooltip.SetDefault("");
		}

	}
}
