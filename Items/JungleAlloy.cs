using Terraria.ModLoader;

namespace Tremor.Items
{
	public class JungleAlloy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Alloy");
			Tooltip.SetDefault("''Forge Master will be interested in this''\n" +
"Allows Forge Master to move in");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 30;
			item.maxStack = 99;
			item.value = 2500;
			item.rare = 3;
		}

	}
}
