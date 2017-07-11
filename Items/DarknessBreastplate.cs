using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class DarknessBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;

			item.value = 600000;
			item.rare = 11;
			item.defense = 30;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Breastplate of Darkness");
			Tooltip.SetDefault("Increases life regeneration");
		}


		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkGel", 38);
			recipe.AddIngredient(null, "DarkMatter", 38);
			recipe.AddIngredient(null, "DarkMass", 1);
			recipe.SetResult(this);
			recipe.AddTile(247);
			recipe.AddRecipe();
		}
	}
}
