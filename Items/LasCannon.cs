using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class LasCannon : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 500;
			item.ranged = true;
			item.expert = true;
			item.melee = false;
			item.width = 90;
			item.height = 36;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useAmmo = AmmoID.Bullet;
			item.useStyle = 5;
			item.shootSpeed = 20f;
			item.knockBack = 15;
			item.value = 1000000;
			item.rare = 10;
			item.shoot = 440;
			item.shootSpeed = 10f;
			item.UseSound = SoundID.Item40;
			item.autoReuse = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Las Cannon");
			Tooltip.SetDefault("Uses bullets as ammo");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 440;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}

	}
}
