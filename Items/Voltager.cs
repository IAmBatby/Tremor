using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Voltager : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 212;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 30;
			item.useAnimation = 14;
			item.shoot = mod.ProjectileType("LightningBoltPro");
			item.shootSpeed = 7f;
			item.mana = 6;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 122355;
			item.rare = 5;
			item.UseSound = SoundID.Item117;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Voltager");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareBar", 10);
			recipe.AddIngredient(3467, 10);
			recipe.AddIngredient(null, "Doomstone", 9);
			recipe.AddIngredient(null, "Phantaplasm", 12);
			recipe.AddIngredient(null, "ConcentratedEther", 8);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
