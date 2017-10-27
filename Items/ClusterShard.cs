using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ClusterShard : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 12000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cluster Shard");
			Tooltip.SetDefault("");
		}

	}
}
