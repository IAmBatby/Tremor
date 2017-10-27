using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	public class AncientTablet : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 34;
			item.height = 40;
			item.maxStack = 99;
			item.value = 10000;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Tablet");
			Tooltip.SetDefault("");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
		}
	}
}
