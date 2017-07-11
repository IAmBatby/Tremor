using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class SandstoneDrill : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 8;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 21;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 46;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 13500;
			item.rare = 1;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SandstoneDrillPro");
			item.shootSpeed = 40f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Drill");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AntlionShell", 1);
			recipe.AddIngredient(ItemID.Topaz, 4);
			recipe.AddIngredient(ItemID.AntlionMandible, 4);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
