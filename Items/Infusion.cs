using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Infusion : ModItem
	{
		public override void SetDefaults()
		{

			item.rare = 11;
			item.maxStack = 1;
			item.useAnimation = 20;
			item.useTime = 20;
			item.useStyle = 2;
			item.potion = true;
			item.healLife = 100;

			item.UseSound = SoundID.Item3;
			item.value = 1000000;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infusion");
			Tooltip.SetDefault("Eternal potion");
		}

	}
}
