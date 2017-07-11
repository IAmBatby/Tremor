using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PerfectBehemoth : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 30;
			item.thrown = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 50000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("PerfectBehemothPro");
			item.shootSpeed = 8f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Perfect Behemoth");
			Tooltip.SetDefault("");
		}

	}
}
