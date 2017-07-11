using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class ParaxydeBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 10000;
			item.rare = 5;
			item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paraxyde Breastplate");
			Tooltip.SetDefault("Increases melee and magic criticals strike chance by 15");
		}


		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 15;
			player.meleeCrit += 15;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ParaxydeShard", 18);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchematorTile");
			recipe.AddRecipe();
		}
	}
}
