using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class Dissolver : ModItem
{
    public override void SetDefaults()
    {
        item.CloneDefaults(3279);

        item.damage = 58;
        item.width = 30;
        item.height = 26;
        item.shoot = mod.ProjectileType("DissolverPro");
        item.knockBack = 4;
        item.value = 10000;
        item.rare = 4;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Dissolver");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(3290, 1);
        recipe.AddIngredient(ItemID.SoulofSight, 5);
        recipe.AddIngredient(ItemID.Ichor, 18);
        recipe.SetResult(this);
        recipe.AddTile(134);
        recipe.AddRecipe();
    }
}
}
