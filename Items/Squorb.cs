using Terraria.ID;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Squorb : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 10;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squorb");
			Tooltip.SetDefault("");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}

	}
}
