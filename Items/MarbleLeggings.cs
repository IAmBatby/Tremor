using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
public class MarbleLeggings : ModItem
{


        public override void SetDefaults()
        {


            item.defense = 2;
        item.width = 22;
        item.height = 18;
        item.value = 2500;
        item.rare = 1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Marble Leggings");
      Tooltip.SetDefault("10% increased throwing critical strike chance");
    }


        public override void UpdateEquip(Player p)
        {
            p.thrownCrit += 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MarbleBlock, 45);
            recipe.AddIngredient(null, "StoneofLife", 1);
            recipe.SetResult(this);
        recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
