using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
public class FleshGreaves : ModItem
{


    public override void SetDefaults()
    {

        item.width = 38;
        item.height = 22;


        item.value = 18000;
        item.rare = 1;
        item.defense = 7;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Flesh Greaves");
      Tooltip.SetDefault("5% increased minion damage\nIncreases your max number of minions");
    }


    public override void UpdateEquip(Player player)
    {
            player.maxMinions += 1;
            player.minionDamage += 0.05f;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "PieceofFlesh", 6);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }

}}
