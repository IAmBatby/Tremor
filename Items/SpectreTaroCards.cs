using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SpectreTaroCards : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 67;
			item.magic = true;
			item.width = 36;
			item.mana = 8;
			item.height = 34;
			item.useTime = 20;
			item.useAnimation = 20;
			item.noUseGraphic = true;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 30000;
			item.rare = 6;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpectreTaroCard");
			item.shootSpeed = 8f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectre Taro Cards");
			Tooltip.SetDefault("");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 1, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
