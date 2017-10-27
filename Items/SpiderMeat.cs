using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class SpiderMeat : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 30;
			item.maxStack = 20;

			item.rare = 1;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item2;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Meat");
			Tooltip.SetDefault("'I don't see anything wrong with it, eat it!'");
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(22, 10000, true);
			player.AddBuff(32, 10000, true);
			player.AddBuff(31, 10000, true);
			return true;
		}
	}
}
