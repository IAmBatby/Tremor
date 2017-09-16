using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GolemCore : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 20;

			item.value = 100000;
			item.rare = 8;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem Core");
			Tooltip.SetDefault("The ancient and mysterious mechanism");
		}

	}
}
