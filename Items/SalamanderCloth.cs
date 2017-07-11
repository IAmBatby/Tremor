using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class SalamanderCloth : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 26;
			item.rare = 1;

			item.value = 100;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Salamander Cloth");
			Tooltip.SetDefault("Increases movement speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SalamanderSkin", 10);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
