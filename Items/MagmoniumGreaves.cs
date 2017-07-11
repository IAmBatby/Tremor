using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
public class MagmoniumGreaves : ModItem
{


        public override void SetDefaults()
        {
        item.defense = 15;
        item.width = 22;
        item.height = 18;
        item.value = 2500;
        item.rare = 8;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Magmonium Greaves");
      Tooltip.SetDefault("10% increased melee speed\n10% reduced mana usage");
    }


        public override void UpdateEquip(Player player)
        {
            player.manaCost -= 0.1f;
            player.meleeSpeed += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagmoniumBar", 20);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
