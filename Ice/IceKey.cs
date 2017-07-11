using Terraria.ModLoader;

namespace Tremor.Ice
{
	public class IceKey : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100000;
			item.rare = 3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Key");
			Tooltip.SetDefault("Opens the Frozen Chest once");
		}

	}
}
