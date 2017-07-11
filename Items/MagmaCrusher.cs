using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MagmaCrusher : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 85;
			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.useTime = 27;
			item.useAnimation = 27;
			item.hammer = 180;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 600;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Crusher");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmoniumBar", 15);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
