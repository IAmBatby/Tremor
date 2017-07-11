using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Tremor.Items {
public class Crusher: ModItem
{
    public override void SetDefaults()
    {

        item.damage = 32;
        item.melee = true;
        item.width = 60;
        item.height = 60;
        item.useTime = 40;
        item.useAnimation = 38;
        item.useStyle = 1;
        item.knockBack = 12;
        item.value = 26025;
        item.rare = 3;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Crusher");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "FireFragment", 15);
        recipe.AddIngredient(null, "MoltenParts", 1);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if(Main.rand.Next(3) == 0)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
        }
    }
}}
