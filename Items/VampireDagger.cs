using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class VampireDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 48;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 20;
			item.shoot = 304;
			item.shootSpeed = 15f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 7;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vampire Dagger");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SkullTeeth");
			recipe.SetResult(this, 100);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
