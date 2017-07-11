using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class WolfHood : ModItem
{


    public override void SetDefaults()
    {

        item.width = 28;
        item.height = 22;
        item.rare = 1;

        item.value = 100;
        item.defense = 2;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Wolf Hood");
      Tooltip.SetDefault("6% increased minion damage");
    }


    public override void UpdateEquip(Player player)
    {
            player.minionDamage += 0.06f;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
return body.type == mod.ItemType("WolfJerkin") && legs.type == mod.ItemType("WolfLeggings");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Increases your max number of minions";
            player.maxMinions += 1;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "WolfPelt", 8);
        recipe.AddIngredient(null, "AlphaClaw", 1);
        recipe.SetResult(this);
	recipe.AddTile(18);
        recipe.AddRecipe();
    }
}}
