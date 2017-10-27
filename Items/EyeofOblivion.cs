using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EyeofOblivion : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 16000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Oblivion");
			Tooltip.SetDefault("");
		}

	}
}
