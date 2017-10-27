using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HuskofDusk : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.maxStack = 999;
			item.value = 200;
			item.rare = 11;
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Husk of Dusk");
			Tooltip.SetDefault("");
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Purple;
		}

	}
}
