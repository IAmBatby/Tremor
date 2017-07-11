using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TheSnowBall : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 27;
			item.magic = true;
			item.mana = 9;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 3;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("TheSnowBall");
			item.shootSpeed = 8f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Snow Ball");
			Tooltip.SetDefault("");
		}

	}
}
