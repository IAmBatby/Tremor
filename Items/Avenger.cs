using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Avenger : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(3279);
			item.damage = 17;
			item.width = 30;
			item.height = 26;
			item.shoot = mod.ProjectileType("AvengerPro");
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avenger");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteelBar", 18);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
