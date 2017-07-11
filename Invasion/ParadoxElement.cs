using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class ParadoxElement : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 46;
			item.height = 46;
			item.value = 600;
			item.rare = 11;

			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Element");
			Tooltip.SetDefault("'Element of paradox warriors'");
		}

	}
}
