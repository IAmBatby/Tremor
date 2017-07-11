using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	public class AngelicTears : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 256;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 14;
			item.useAnimation = 14;
			item.shoot = mod.ProjectileType("AngelTearsPro");
			item.shootSpeed = 16f;
			item.mana = 6;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 90000;
			item.rare = 0;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angelic Tears");
			Tooltip.SetDefault("");
		}


		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AngeliteBar", 12);
			recipe.AddIngredient(null, "LapisLazuli", 7);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(null, "HuskofDusk", 8);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
