using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class CryptStone : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 16;
			item.maxStack = 99;
			item.rare = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crypt Stone");
			Tooltip.SetDefault("");
		}
	}
}
