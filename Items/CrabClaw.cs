using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CrabClaw : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 36;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 5025;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crab Claw");
			Tooltip.SetDefault("");
		}

	}
}
