using Terraria.ModLoader;

namespace Tremor.Items.Flesh
{
	public class UntreatedFlesh : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.maxStack = 99;
			item.value = 80;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Untreated Flesh");
			Tooltip.SetDefault("");
		}

	}
}
