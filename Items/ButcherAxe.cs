using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ButcherAxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 27;
			item.axe = 9;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 6000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Butcher Axe");
			Tooltip.SetDefault("");
		}

	}
}
