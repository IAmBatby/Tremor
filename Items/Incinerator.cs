using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class Incinerator : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 82;
			item.mana = 12;
			item.width = 20;
			item.height = 12;
			item.magic = true;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 6, 0, 0);
			item.rare = 8;
			item.crit = 3;
			item.useStyle = 5;
			item.UseSound = SoundID.Item36;
			item.noMelee = true;
			item.autoReuse = true;
			item.shoot = 260;
			item.shootSpeed = 10f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Incinerator");
			Tooltip.SetDefault("");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 2, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 2, type, damage, knockBack, Main.myPlayer);
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
			recipe.AddIngredient(null, "GolemCore", 1);
			recipe.AddIngredient(ItemID.HeatRay, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 16);
			recipe.AddIngredient(ItemID.SoulofFright, 16);
			recipe.AddIngredient(ItemID.SoulofSight, 16);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GolemCore", 1);
			recipe.AddIngredient(ItemID.HeatRay, 1);
			recipe.AddIngredient(null, "SoulofMind", 16);
			recipe.AddIngredient(ItemID.SoulofFright, 16);
			recipe.AddIngredient(ItemID.SoulofSight, 16);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
