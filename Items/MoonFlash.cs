using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MoonFlash : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 90;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 25;
			item.mana = 10;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.shoot = 645;
			item.shootSpeed = 40f;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item77;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Flash");
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
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(null, "LunarRoot", 6);
			recipe.AddIngredient(3467, 30);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}
