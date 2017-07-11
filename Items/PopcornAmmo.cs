using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PopcornAmmo : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.ranged = true;
			item.width = 22;
			item.height = 22;
			item.maxStack = 999;

			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("PopcornAmmo");
			item.ammo = item.type;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Popcorn");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Corn", 1);
			recipe.SetResult(this, 25);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
