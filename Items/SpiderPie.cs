using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
	public class SpiderPie : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;

			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 30000;
			item.rare = 2;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = mod.MountType("Spider");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Pie");
			Tooltip.SetDefault("Summons a rideable Fat Spider mount");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bowl, 1);
			recipe.AddIngredient(null, "SpiderMeat", 15);
			recipe.AddIngredient(ItemID.Cobweb, 100);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
