using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TrueEssense : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 0;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			//ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Essence");
			Tooltip.SetDefault("");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

	}
}
