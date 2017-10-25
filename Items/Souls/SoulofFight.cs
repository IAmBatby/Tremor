using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Souls
{
	public class SoulofFight : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 11;

			ItemID.Sets.ItemNoGravity[item.type] = true;
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Fight");
			Tooltip.SetDefault("'The essence of endless battle'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

	}
}
