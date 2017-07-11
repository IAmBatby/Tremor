using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
public class WhiteGoldGreaves : ModItem
{


    public override void SetDefaults()
    {

        item.width = 38;
        item.height = 22;

        item.value = 10000;
        item.rare = 11;
        item.defense = 32;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("White Gold Greaves");
      Tooltip.SetDefault("50% increased movement speed");
    }


    public override void UpdateEquip(Player player)
    {
			player.moveSpeed += 0.5f;
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WhiteGoldBar", 15);
            recipe.SetResult(this);
            recipe.AddTile(null, "DivineForgeTile");
            recipe.AddRecipe();
        }

}}
