using Terraria.ModLoader;

namespace Tremor.Items.Alchemist
{
	[AutoloadEquip(EquipType.Head)]
	public class AlchemasterMask : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;
			item.rare = 1;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemaster Mask");
			Tooltip.SetDefault("");
		}

	}
}
