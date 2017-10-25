using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items.Dark
{
	public class DarkMatter : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter");
			Tooltip.SetDefault("");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
		}

	}
}
