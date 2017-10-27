using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AxeofExecutioner : ModItem
	{
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 1;

			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("AxeofExecutionerPro");
			item.damage = 175;
			item.width = 18;
			item.height = 20;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 14;
			item.useTime = 17;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 500000;
			item.knockBack = 5f;
			item.melee = true;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Axe of Executioner");
			Tooltip.SetDefault("");
		}

	}
}
