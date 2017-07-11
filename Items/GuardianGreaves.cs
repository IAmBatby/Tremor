using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class GuardianGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.defense = 50;
			item.width = 22;
			item.height = 18;
			item.value = 25000;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Guardian Greaves");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientArmorPlate", 16);
			recipe.AddIngredient(null, "Squorb", 1);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
