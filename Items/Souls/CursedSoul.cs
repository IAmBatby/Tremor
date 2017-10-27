using Terraria.ModLoader;

namespace Tremor.Items.Souls
{
	public class CursedSoul : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 40;
			item.height = 28;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Soul");
			Tooltip.SetDefault("");
		}

	}
}
