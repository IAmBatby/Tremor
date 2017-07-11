using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Sporaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = true;
			item.width = 54;
			item.height = 48;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 5;
			item.shootSpeed = 10f;
			item.value = 22000;
			item.shoot = 569;
			item.rare = 3;
			item.axe = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sporaxe");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "JungleAlloy", 1);
			recipe.AddIngredient(ItemID.Stinger, 4);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.SetResult(this);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();
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

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 61);
			}
		}
	}
}
