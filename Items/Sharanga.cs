using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Sharanga : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 24;
			item.width = 16;
			item.height = 32;
			item.ranged = true;
			item.useTime = 20;
			item.shoot = 1;
			item.shootSpeed = 12f;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 8340;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharanga");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShadowBow", 1);
			recipe.AddIngredient(ItemID.Obsidian, 15);
			recipe.AddIngredient(null, "DemonBlood", 8);
			recipe.AddIngredient(null, "MinotaurHorn", 2);
			recipe.AddTile(null, "DevilForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
