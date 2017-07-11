using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class IceHammer : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 72;
        item.melee = true;
        item.width = 36;
        item.height = 36;
        item.useTime = 5;
        item.useAnimation = 16;
        item.hammer = 100;
        item.useStyle = 1;
        item.knockBack = 5;
        item.value = 200000;
        item.rare = 7;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ice Hammer");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "FrostoneBar", 10);
        recipe.AddTile(134);
        recipe.SetResult(this);
        recipe.AddRecipe();
}
}}
