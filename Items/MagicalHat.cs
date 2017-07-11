using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class MagicalHat : ModItem
{

    public override void SetDefaults()
    {

        item.width = 26;
        item.height = 22;

        item.value = 250;
        item.rare = 1;
        item.defense = 2;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Theurgic Hat");
      Tooltip.SetDefault("3% increased magic damage");
    }


    public override void UpdateEquip(Player player)
    {
            player.magicDamage += 0.03f;
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == mod.ItemType("MagicalRobe") && legs.type == mod.ItemType("MagicalGreaves");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Increases maximum mana by 20";
        player.statManaMax2 += 20;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Silk, 7);
        recipe.AddIngredient(ItemID.LeadBar, 3);
        recipe.SetResult(this);
        recipe.AddTile(18);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Silk, 7);
        recipe.AddIngredient(ItemID.IronBar, 3);
        recipe.SetResult(this);
        recipe.AddTile(18);
        recipe.AddRecipe();

    }

}}
