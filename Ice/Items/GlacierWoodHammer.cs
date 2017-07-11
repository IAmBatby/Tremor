using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Ice.Items {
public class GlacierWoodHammer : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 2;
        item.melee = true;
        item.width = 32;
        item.height = 32;
        item.useTime = 36;
        item.useAnimation = 36;
        item.useStyle = 1;
        item.knockBack = 5;
        item.value = 10;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
        item.hammer = 25;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Glacier Wood Hammer");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GlacierWood", 8);
        recipe.SetResult(this);
        recipe.AddTile(18);
        recipe.AddRecipe();
    }

}}
