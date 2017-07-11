using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Devastator : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 162;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 1;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("DevastatorPro");
			item.shootSpeed = 19f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 70000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devastator");
			Tooltip.SetDefault("");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 2, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "VoidBar", 20);
			recipe.AddIngredient(null, "Doomstone", 10);
			recipe.AddIngredient(null, "DarkMatter", 100);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}

	}
}
