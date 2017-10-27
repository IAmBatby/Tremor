using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Souls
{
	public class InfernoSoul : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 38;
			item.value = 10000;
			item.rare = 0;
			item.maxStack = 999;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Soul");
			Tooltip.SetDefault("");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

	}
}
