using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class Magminer : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 40;
        item.melee = true;
        item.width = 60;
        item.height = 52;
        item.useTime = 12;
        item.useAnimation = 15;
        item.pick = 200;
        item.useStyle = 1;
        item.knockBack = 2;
        item.value = 600;
        item.rare = 8;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Magminer");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "MagmoniumBar", 15);
        recipe.SetResult(this);
        recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
