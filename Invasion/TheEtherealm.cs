using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class TheEtherealm : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 100;
			item.width = 18;
			item.height = 56;
			item.ranged = true;
			item.useTime = 17;
			item.shoot = 1;
			item.shootSpeed = 52f;
			item.noMelee = true;
			item.useAnimation = 17;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 250000;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 11;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Etherealm");
			Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, 440, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 440, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, 440, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, 440, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 2, 440, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX + 3, speedY + 3, 440, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 3, speedY - 3, 440, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

	}
}
