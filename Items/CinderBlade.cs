using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class CinderBlade : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 70;
        item.melee = true;
        item.width = 52;
        item.height = 52;
        item.useTime = 22;
        item.useAnimation = 22;
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 600;
        item.rare = 8;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cinder Blade");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "MagmoniumBar", 12);
        recipe.SetResult(this);
        recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
