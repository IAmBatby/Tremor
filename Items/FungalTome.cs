using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class FungalTome : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 24;
        item.melee = false;
        item.magic = true;
        item.width = 50;
        item.height = 55;
        item.useTime = 15;
        item.mana = 7;
        item.useAnimation = 15;
        item.useStyle = 5;
        item.shoot = 131;
        item.shootSpeed = 20f; 
        item.knockBack = 4;
        item.value = 50000;
        item.rare = 3;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Fungal Tome");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Book, 1);
        recipe.AddIngredient(ItemID.GlowingMushroom, 15);
        recipe.SetResult(this);
        recipe.AddTile(null, "MagicWorkbenchTile");
        recipe.AddRecipe();
    }
}
}
