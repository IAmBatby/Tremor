using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Tremor.Items
{
	public class OmnikronBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 10000;
			item.rare = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omnikron Bar");
			Tooltip.SetDefault("");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
		}


		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

	}
}
