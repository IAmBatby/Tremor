using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
public class ArgiteGreaves : ModItem
{


    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 18;
        item.value = 15000;
        item.rare = 3;

        item.defense = 6;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Argite Greaves");
      Tooltip.SetDefault("10% increased movement speed");
    }


    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.1f;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ArgiteBar", 18);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }

}}
