using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Conglomeration : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;
			item.value = 250000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Conglomeration");
			Tooltip.SetDefault("Prolonged after hit invincibility\nGreatly increased life regeneration\nIncreases maximum life by 140");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed -= 0.2f;
			player.longInvince = true;
			player.lifeRegen += 45;
			player.statLifeMax2 += 140;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SwampClump");
			recipe.AddIngredient(null, "ExtraterrestrialRubies");
			recipe.AddIngredient(null, "DelightfulClump");
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
