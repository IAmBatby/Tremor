using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AncientDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 96;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 42;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("AncientDaggerPro");
			item.shootSpeed = 22f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 7;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Dagger");
			Tooltip.SetDefault("Throws an exploding dagger");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientTablet");
			recipe.AddIngredient(ItemID.ThrowingKnife, 25);
			recipe.SetResult(this, 25);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
