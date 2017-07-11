using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{ 
[AutoloadEquip(EquipType.Body)]
    public class BerserkerChestplate : ModItem
    {

        public override void SetDefaults()
        {

            item.width = 26;
            item.height = 18;

            item.value = 600;
            item.rare = 2;
            item.defense = 6;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Berserker Chestplate");
      Tooltip.SetDefault("7% increased melee critical strike chance");
    }


        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 7;
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "SteelBar", 20);
        recipe.AddIngredient(null, "MinotaurHorn", 1);
        recipe.AddIngredient(null, "EarthFragment", 10);
        recipe.SetResult(this);
	recipe.AddTile(16);
        recipe.AddRecipe();
    }
    }
}
