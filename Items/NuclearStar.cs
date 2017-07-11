using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NuclearStar : ModItem
	{

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.0174f;
			double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
			double deltaAngle = spread / 8f;
			double offsetAngle;
			int i;
			for (i = 0; i < 4; i++)
			{
				offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
				Projectile.NewProjectile(position.X, position.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), item.shoot, damage, knockBack, item.owner);
				Projectile.NewProjectile(position.X, position.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), item.shoot, damage, knockBack, item.owner);
			}
			return false;
		}

		public override void SetDefaults()
		{

			item.damage = 500;
			item.magic = true;
			item.mana = 50;
			item.useTime = 60;
			item.useAnimation = 60;
			item.knockBack = 5;
			item.value = 2500000;
			item.rare = 9;
			item.UseSound = SoundID.Item84;
			item.autoReuse = true;
			item.width = 28;
			item.height = 30;
			item.useStyle = 5;

			item.noMelee = true;
			item.shoot = mod.ProjectileType("NuclearStarPro");
			item.shootSpeed = 20f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nuclear Star");
			Tooltip.SetDefault("Creates nuclear beams.");
		}



		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "StarBar", 25);
			recipe.AddIngredient(null, "SoulofFight", 25);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.Amber, 16);
			recipe.AddIngredient(null, "Blasticyde", 10);
			recipe.AddIngredient(null, "AngryShard", 15);
			recipe.AddTile(null, "StarvilTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
