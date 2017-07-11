using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { 
[AutoloadEquip(EquipType.Body)]
public class WhiteGoldBreastplate : ModItem
{

    public override void SetDefaults()
    {

        item.width = 38;
        item.height = 22;

        item.value = 10000;
        item.rare = 11;
        item.defense = 35;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("White Gold Breastplate");
      Tooltip.SetDefault("Increases melee and ranged critical strike chances by 25%");
    }


    public override void UpdateEquip(Player player)
    {
        player.rangedCrit += 25;
        player.meleeCrit += 25;
    }

       
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WhiteGoldBar", 18);
            recipe.SetResult(this);
            recipe.AddTile(null, "DivineForgeTile");
            recipe.AddRecipe();
        }
}}
