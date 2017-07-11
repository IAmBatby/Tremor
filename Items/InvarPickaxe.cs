using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class InvarPickaxe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 6;
        item.melee = true;
        item.width = 36;
        item.height = 36;
        item.useTime = 20;
        item.useAnimation = 20;
        item.pick = 45;
        item.useStyle = 1;
        item.knockBack = 3;
        item.value = 100;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Invar Pickaxe");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "InvarBar", 12);
        recipe.AddIngredient(ItemID.Wood, 3);
        recipe.AddTile(16);
        recipe.SetResult(this);
        recipe.AddRecipe();
}
}}
