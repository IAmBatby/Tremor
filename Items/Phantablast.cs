using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class Phantablast : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 83;
			item.ranged = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 12;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 210000;
			item.rare = 10;
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
			DisplayName.SetDefault("Phantablast");
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
				Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 3, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 3, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 4, speedY - 2, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX + 4, speedY + 2, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

		public override bool ConsumeAmmo(Player p)
		{
			return Main.rand.Next(2) == 0;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientTechnology", 1);
			recipe.AddIngredient(3456, 30);
			recipe.AddIngredient(null, "AirFragment", 25);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
