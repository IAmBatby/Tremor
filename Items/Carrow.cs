using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Carrow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.ranged = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 1;

			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("Carrot");
			item.shootSpeed = 19f;
			item.useAmmo = mod.ItemType("Carrot");
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 70000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Carrow");
			Tooltip.SetDefault("Uses carrots as ammo");
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
