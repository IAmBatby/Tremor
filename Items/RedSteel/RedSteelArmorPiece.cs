using Terraria.ModLoader;

namespace Tremor.Items.RedSteel
{
	public class RedSteelArmorPiece : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 18;
			item.maxStack = 99;
			item.value = 50;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Steel Armor Piece");
			Tooltip.SetDefault("");
		}

	}
}
