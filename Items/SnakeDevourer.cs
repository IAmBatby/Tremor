using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SnakeDevourer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 295;
			item.ranged = true;
			item.width = 58;
			item.height = 26;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;

			item.useAmmo = AmmoID.Bullet;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 440;
			item.shootSpeed = 6f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snake Devourer");
			Tooltip.SetDefault("Uses bullets as ammo");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -2);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 440;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
