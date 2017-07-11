using Terraria.ID;
using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EternalAgony : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 10;
			item.value = Item.sellPrice(2, 0, 0, 0);

			item.rare = 4;
			item.noMelee = true;
			item.useStyle = 5;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 7.5F;
			item.damage = 76;
			item.scale = 1.1F;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("EternalAgonyPro");
			item.shootSpeed = 20.9F;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eternal Agony");
			Tooltip.SetDefault("Inflicts Shadow Flames on foes");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkMatter", 50);
			recipe.AddIngredient(ItemID.DarkShard, 1);
			recipe.AddIngredient(ItemID.LightShard, 1);
			recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.AddRecipe();
		}
	}
}
