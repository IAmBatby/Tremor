using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AtisBlood : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 16;
			item.maxStack = 99;
			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Atis Blood");
			Tooltip.SetDefault("");
		}

	}
}
