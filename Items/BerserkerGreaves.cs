using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class BerserkerGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 500;

			item.rare = 2;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Greaves");
			Tooltip.SetDefault("4% increased melee damage");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.04f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteelBar", 16);
			recipe.AddIngredient(null, "MinotaurHorn", 1);
			recipe.AddIngredient(null, "EarthFragment", 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}


}
