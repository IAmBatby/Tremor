using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BronzeHamaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 17;
			item.useAnimation = 27;
			item.axe = 9;
			item.hammer = 45;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 600;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bronze Hamaxe");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BronzeBar", 12);
			recipe.AddIngredient(ItemID.Wood, 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
