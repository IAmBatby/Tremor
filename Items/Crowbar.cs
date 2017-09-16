using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Crowbar : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 25;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 12000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crowbar");
			Tooltip.SetDefault("'Actually it snaps in two'");
		}

	}
}
