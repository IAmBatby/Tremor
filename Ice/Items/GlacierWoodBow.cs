using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class GlacierWoodBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.ranged = true;
			item.width = 16;
			item.height = 32;
			item.useTime = 29;
			item.shoot = 1;
			item.shootSpeed = 11f;
			item.useAnimation = 29;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 20;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Bow");
			Tooltip.SetDefault("");
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWood", 10);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
