using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.LivingWood
{
	public class LivingWoodThreepeater : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 45;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 30000;
			item.rare = 6;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 1;
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Wood Threepeater");
			Tooltip.SetDefault("");
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
