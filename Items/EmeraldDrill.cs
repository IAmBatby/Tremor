using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class EmeraldDrill : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 8;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 85;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 0, 50, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("EmeraldDrillPro");
			item.shootSpeed = 40f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Emerald Drill");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Obsidian, 25);
			recipe.AddIngredient(ItemID.MeteoriteBar, 16);
			recipe.AddIngredient(ItemID.Emerald, 12);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
