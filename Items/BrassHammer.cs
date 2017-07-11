using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {

public class BrassHammer : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 40;
        item.melee = true;
        item.width = 42;
        item.height = 40;
        item.useTime = 10;
        item.useAnimation = 15;
        item.hammer = 95;
        item.tileBoost++;
        item.useStyle = 1;
        item.knockBack = 6;
        item.value = Item.buyPrice(0, 1, 50, 0);
        item.rare = 5;
        item.UseSound = SoundID.Item71;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Brass Hammer");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "BrassBar", 10);
        recipe.AddIngredient(ItemID.Cog, 10);
        recipe.SetResult(this);
	recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
