using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class InvarHeadgear : ModItem
{



    public override void SetDefaults()
    {

        item.width = 32;
        item.height = 26;
        item.value = 400;

        item.rare = 1;
        item.defense = 1;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Invar Headgear");
      Tooltip.SetDefault("6% increased melee damage");
    }


    public override void UpdateEquip(Player player)
    {
            player.meleeDamage += 0.06f;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
return body.type == mod.ItemType("InvarBreastplate") && legs.type == mod.ItemType("InvarGreaves");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "6% increased melee crit";
        player.meleeCrit += 6;
    }
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "InvarBar", 8);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }
}}
