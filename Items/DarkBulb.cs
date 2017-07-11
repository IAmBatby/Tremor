using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DarkBulb : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 22;
			item.maxStack = 999;
			item.rare = 3;
			item.value = Item.buyPrice(0, 0, 10, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Bulb");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LightBulb", 1);
			recipe.AddIngredient(null, "TearsofDeath", 1);
			recipe.AddIngredient(null, "Charcoal", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
