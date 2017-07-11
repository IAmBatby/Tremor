using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MoonLash : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 259;
			item.magic = true;
			item.mana = 20;
			item.width = 34;
			item.height = 30;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 10;
			item.UseSound = SoundID.Item43;
			item.autoReuse = false;
			item.shoot = 645;
			item.shootSpeed = 12f;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Lash");
			Tooltip.SetDefault("Erupts three moon flame bolts");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ScourgeofFlames", 1);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(null, "NightmareBar", 11);
			recipe.AddIngredient(ItemID.PlatinumBar, 9);
			recipe.AddIngredient(ItemID.GoldBar, 9);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
