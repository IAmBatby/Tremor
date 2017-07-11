using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class NanoGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 6000;

			item.rare = 6;
			item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Greaves");
			Tooltip.SetDefault("20% increased movement speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.20f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NanoBar", 15);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
