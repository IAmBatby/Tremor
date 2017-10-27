using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FarmerShovel : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Farmer's Shovel");
			Tooltip.SetDefault("''She wants to get it back..''\n" +
"Allows the Farmer to move in");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 17;
			item.useAnimation = 17;
			item.pick = 45;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 1000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.autoReuse = true;
		}
	}
}
