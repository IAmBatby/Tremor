using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Legs)]
public class BoneGreaves : ModItem
{


        public override void SetDefaults()
        {



            item.defense = 8;
            item.width = 22;
            item.height = 18;
            item.value = 25000;
            item.rare = 4;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bone Greaves");
      Tooltip.SetDefault("20% increased throwing critical strike chance\n6% increased ranged damage");
    }


        public override void UpdateEquip(Player p)
        {
            p.thrownCrit += 20;
            p.rangedDamage += 0.06f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(153, 1);
            recipe.AddIngredient(3376, 1);
        recipe.AddIngredient(null, "CursedSoul", 1);
        recipe.AddIngredient(ItemID.SoulofNight, 3);
        recipe.AddIngredient(null, "SharpenedTooth", 3);
        recipe.AddIngredient(null, "TheRib", 3);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
