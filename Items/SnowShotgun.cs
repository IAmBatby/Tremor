using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SnowShotgun : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 17;
			item.ranged = true;
			item.width = 26;
			item.maxStack = 1;
			item.height = 56;
			item.useTime = 32;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 100000;
			item.rare = 2;
			item.UseSound = SoundID.Item36;
			item.autoReuse = false;
			item.shoot = 166;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Snowball;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snow Shotgun");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

	}
}
