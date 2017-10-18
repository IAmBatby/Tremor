using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class ParatrooperShotgun : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 300;
			item.ranged = true;
			item.width = 46;
			item.height = 28;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 651000;
			item.rare = 11;
			item.useStyle = 5;
			item.UseSound = SoundID.Item36;
			item.noMelee = true;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 23f;
			item.useAmmo = AmmoID.Bullet;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paratrooper Shotgun");
			Tooltip.SetDefault("Has 33% chance not to consume ammo");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
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

		public override bool ConsumeAmmo(Player p)
		{
			return Main.rand.NextBool(3);
		}
	}
}
