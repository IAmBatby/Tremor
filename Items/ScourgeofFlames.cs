using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ScourgeofFlames : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 36;
			item.magic = true;
			item.mana = 8;
			item.width = 34;
			item.height = 30;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 4;
			item.UseSound = SoundID.Item43;
			item.autoReuse = false;
			item.shoot = 668;
			item.shootSpeed = 15f;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scourge of Flames");
			Tooltip.SetDefault("Erupts three fire bolts");
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
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FireFragment", 10);
			recipe.AddIngredient(null, "Charcoal", 7);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
