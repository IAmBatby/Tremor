using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StarlightGlimmer : ModItem
	{
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 5;
			item.useAnimation = 12;
			item.useTime = 12;

			item.width = 50;
			item.height = 18;
			item.shoot = 12;
			item.useAmmo = AmmoID.FallenStar;
			item.UseSound = SoundID.Item9;
			item.damage = 228;
			item.shootSpeed = 14f;
			item.noMelee = true;
			item.value = 1000000;
			item.rare = 2;

			item.ranged = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starlight Glimmer");
			Tooltip.SetDefault("Shoots fallen stars");
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
			recipe.AddIngredient(ItemID.StarCannon, 1);
			recipe.AddIngredient(null, "Doomstone", 16);
			recipe.AddIngredient(3467, 20);
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.FallenStar, 25);
			recipe.AddIngredient(null, "ConcentratedEther", 28);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
