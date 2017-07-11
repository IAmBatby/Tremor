using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{ 
[AutoloadEquip(EquipType.Body)]
	public class ArgiteBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 25000;
			item.rare = 3;

			item.defense = 9;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Argite Breastplate");
      Tooltip.SetDefault("12% increased melee damage");
    }


    public override void UpdateEquip(Player player)
    {
	player.meleeDamage += 0.12f;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ArgiteBar", 22);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }
	}
}
