using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Souls
{
	public class SoulEruption : ModItem
	{
		public override void SetDefaults()
		{

			item.mana = 8;
			item.UseSound = SoundID.Item43;
			item.useStyle = 5;
			item.damage = 192;
			item.autoReuse = true;
			item.useAnimation = 16;
			item.useTime = 16;
			item.width = 40;
			item.height = 40;
			item.shoot = 297;
			item.shootSpeed = 6f;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.magic = true;
			item.noMelee = true;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Eruption");
			Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpectreBar, 20);
			recipe.AddIngredient(null, "Phantaplasm", 12);
			recipe.AddIngredient(null, "PurpleQuartz", 15);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
