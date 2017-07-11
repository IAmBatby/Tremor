using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ElectricSpear : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 25;
			item.width = 70;
			item.height = 70;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 25;
			item.shoot = mod.ProjectileType("ElectricSpearPro");
			item.shootSpeed = 5f;
			item.useAnimation = 30;

			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 12500;
			item.rare = 3;
			item.UseSound = SoundID.Item93;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electric Spear");
			Tooltip.SetDefault("'Traitor!'");
		}


	}
}
