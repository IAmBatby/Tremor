using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HandCannon : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 60;
			item.ranged = true;
			item.width = 58;
			item.height = 30;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 50000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 162;
			item.shootSpeed = 15f;
			//item.useAmmo = 14;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hand Cannon");
			Tooltip.SetDefault("");
		}

	}
}
