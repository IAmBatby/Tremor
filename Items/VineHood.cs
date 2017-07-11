using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class VineHood : ModItem
{


    public override void SetDefaults()
    {

        item.width = 26;
        item.height = 26;

        item.value = 100;
        item.rare = 1;
        item.defense = 1;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vine Hood");
      Tooltip.SetDefault("5% increased ranged damage");
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
return body.type == mod.ItemType("VineCape") && legs.type == mod.ItemType("VinePants");
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "15% increased movement speed";
        player.moveSpeed += 0.15f;
    }
    public override void UpdateEquip(Player player)
    {
            player.rangedDamage += 0.05f;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.VineRope, 25);
        recipe.AddIngredient(ItemID.Daybloom, 1);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }

}}
