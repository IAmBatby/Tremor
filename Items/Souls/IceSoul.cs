using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Souls
{
	public class IceSoul : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;

			item.rare = 11;
			item.maxStack = 999;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Essence");
			Tooltip.SetDefault("Essence of ice creatures");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}
