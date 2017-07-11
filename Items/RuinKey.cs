using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RuinKey : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 32;
			item.maxStack = 99;
			item.value = 3000;
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruin Key");
			Tooltip.SetDefault("Opens Ruin Chest once");
		}

	}
}
