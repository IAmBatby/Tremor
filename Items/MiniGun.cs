using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MiniGun : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 8;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini Gun");
			Tooltip.SetDefault("");
		}

	}
}
