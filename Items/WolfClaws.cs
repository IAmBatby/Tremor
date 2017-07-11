using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WolfClaws : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.melee = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 660;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wolf Claws");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WolfPelt", 13);
			recipe.AddIngredient(null, "AlphaClaw", 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
