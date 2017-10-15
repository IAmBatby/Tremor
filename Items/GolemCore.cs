using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GolemCore : ModItem
	{
		public override void SetDefaults()
		{
			item.Size = new Vector2(38);
			item.value = 100000;
			item.rare = 8;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}

		public override void GrabRange(Player player, ref int grabRange)
		{
			grabRange *= 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem Core");
			Tooltip.SetDefault("The ancient and mysterious mechanism");
		}

	}
}
