using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TwilightKnife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 150;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("TwilightKnifePro");
			item.shootSpeed = 22f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 7;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Knife");
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

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PurpleQuartz", 1);
			recipe.AddIngredient(null, "NightmareBar", 1);
			recipe.SetResult(this, 125);
			recipe.AddTile(14);
			recipe.AddRecipe();
		}
	}
}
