using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items.Sparks
{
	public class AdventurerSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adventurer Spark");
			Tooltip.SetDefault("Can be enchanted only once!");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.rare = 1;
			item.value = Item.buyPrice(silver: 1);
		}
	}
}
