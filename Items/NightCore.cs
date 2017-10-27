using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NightCore : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 10;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night Core");
			Tooltip.SetDefault("");
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Purple;
		}

	}
}
