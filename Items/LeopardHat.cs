using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class LeopardHat : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 22;
			item.value = 100000;
			item.rare = 11;
			item.vanity = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leopard Hat");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FashionableHat");
			recipe.AddIngredient(2282);
			recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.AddRecipe();
		}

	}
}
