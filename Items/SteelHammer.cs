using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SteelHammer : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 10;
        item.melee = true;
        item.width = 32;
        item.height = 32;
        item.useTime = 17;
        item.useAnimation = 27;
        item.hammer = 45;
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 600;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Steel Hammer");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "SteelBar", 9);
recipe.AddIngredient(ItemID.Wood, 3);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }
}}
