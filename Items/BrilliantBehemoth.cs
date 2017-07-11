using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BrilliantBehemoth : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 70;
			item.thrown = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 90000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("BrilliantBehemothPro");
			item.shootSpeed = 8f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brilliant Behemoth");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PerfectBehemoth", 1);
			recipe.AddIngredient(ItemID.SoulofLight, 7);
			recipe.AddIngredient(ItemID.SoulofNight, 7);
			recipe.AddIngredient(null, "Opal", 3);
			recipe.AddIngredient(ItemID.Amethyst, 25);
			recipe.SetResult(this);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();
		}
	}
}
