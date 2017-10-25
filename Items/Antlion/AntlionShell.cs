using Terraria.ModLoader;

namespace Tremor.Items.Antlion
{
	public class AntlionShell : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Shell");
			Tooltip.SetDefault("");
		}

	}
}
