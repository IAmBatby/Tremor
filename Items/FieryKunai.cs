using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FieryKunai : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.height = 32;

			item.thrown = true;
			item.width = 18;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.useTime = 18;
			item.useAnimation = 18;
			item.shoot = mod.ProjectileType("FieryKunai");
			item.shootSpeed = 16f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 60;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fiery Kunai");
			Tooltip.SetDefault("50% chance to set enemy on fire");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Kunai", 50);
			recipe.AddIngredient(null, "FireFragment");
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
