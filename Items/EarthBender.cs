using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
	public class EarthBender : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 42;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 25;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 12000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Earth Bender");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ColossusSword", 1);
			recipe.AddIngredient(null, "EarthFragment", 12);
			recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
