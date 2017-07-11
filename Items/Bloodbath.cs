using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Bloodbath : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 98;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 14;
			item.useAnimation = 14;
			item.shoot = 524;
			item.shootSpeed = 6f;
			item.mana = 6;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 122355;
			item.rare = 5;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodbath");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldenShower, 1);
			recipe.AddIngredient(null, "NightmareBar", 10);
			recipe.AddIngredient(null, "ConcentratedEther", 8);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
