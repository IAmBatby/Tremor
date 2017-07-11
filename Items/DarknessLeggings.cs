using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class DarknessLeggings : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 600000;

			item.rare = 11;
			item.defense = 25;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leggings of Darkness");
			Tooltip.SetDefault("Increases life regeneration");
		}

		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkGel", 45);
			recipe.AddIngredient(null, "DarkMatter", 45);
			recipe.AddIngredient(null, "DarkMass", 1);
			recipe.SetResult(this);
			recipe.AddTile(247);
			recipe.AddRecipe();
		}
	}
}
