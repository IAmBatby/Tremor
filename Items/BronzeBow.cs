using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BronzeBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 10;
			item.width = 16;
			item.height = 32;
			item.useTime = 30;
			item.ranged = true;
			item.shoot = 1;
			item.shootSpeed = 12f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 540;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bronze Bow");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BronzeBar", 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
