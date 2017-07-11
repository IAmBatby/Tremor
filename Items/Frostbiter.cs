using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Frostbiter : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 86;
			item.magic = true;
			item.mana = 6;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 9;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 128440;
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 118;
			item.shootSpeed = 5f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostbiter");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FrostoneBar", 20);
			recipe.AddIngredient(ItemID.Ectoplasm, 12);
			recipe.AddIngredient(ItemID.Lens, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 15);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}



		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int ShotAmt = 2;
			int spread = 5;
			float spreadMult = 0.3f;

			Vector2 vector2 = new Vector2();

			for (int i = 0; i < ShotAmt; i++)
			{
				float vX = 8 * speedX + Main.rand.Next(-spread, spread + 1) * spreadMult;
				float vY = 8 * speedY + Main.rand.Next(-spread, spread + 1) * spreadMult;

				float angle = (float)Math.Atan(vY / vX);
				vector2 = new Vector2(position.X + 75f * (float)Math.Cos(angle), position.Y + 75f * (float)Math.Sin(angle));
				float mouseX = Main.mouseX + Main.screenPosition.X;
				if (mouseX < player.position.X)
				{
					vector2 = new Vector2(position.X - 75f * (float)Math.Cos(angle), position.Y - 75f * (float)Math.Sin(angle));
				}

				Projectile.NewProjectile(vector2.X, vector2.Y, vX, vY, 118, damage, knockBack, Main.myPlayer);



			}
			return false;
		}
	}
}
