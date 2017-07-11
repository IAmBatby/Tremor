using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class StarDrill : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 100;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 5;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 250;
			item.tileBoost += 8;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 12, 50, 0);
			item.rare = 0;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("StarDrillPro");
			item.shootSpeed = 40f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Drill");
			Tooltip.SetDefault("");
		}


		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TrueEssense", 3);
			recipe.AddIngredient(null, "NightCore", 3);
			recipe.AddIngredient(null, "CometiteBar", 15);
			recipe.AddIngredient(null, "HardCometiteBar", 3);
			recipe.AddIngredient(null, "StarBar", 3);
			recipe.AddIngredient(null, "LunarRoot", 25);
			recipe.SetResult(this);
			recipe.AddTile(null, "StarvilTile");
			recipe.AddRecipe();
		}
	}
}
