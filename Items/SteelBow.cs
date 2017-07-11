using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SteelBow : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 12;
        item.ranged = true;
        item.width = 16;
        item.height = 32;
        item.useTime = 30;
        item.shoot = 1; 
        item.shootSpeed = 11f; 
        item.useAnimation = 30;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 540;
        item.useAmmo = AmmoID.Arrow;
        item.rare = 1;
        item.UseSound = SoundID.Item5;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Steel Bow");
      Tooltip.SetDefault("");
    }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }  

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "SteelBar", 9);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }
}}
