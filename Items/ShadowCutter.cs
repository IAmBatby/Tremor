using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShadowCutter : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 60;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 25;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 20150;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Cutter");
			Tooltip.SetDefault("");
		}

	}
}
