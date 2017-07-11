using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Tremor.Items {
public class ArgiteHamaxe : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 20;
        item.melee = true;
        item.width = 54;
        item.height = 48;
        item.useTime = 18;
        item.useAnimation = 18;
        item.useStyle = 1;
        item.knockBack = 5;
        item.value = 20000;
        item.rare = 3;
        item.axe = 6;
        item.hammer = 66;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Argite Hamaxe");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ArgiteBar", 12);
        recipe.SetResult(this);
        recipe.AddTile(16);
        recipe.AddRecipe();
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if(Main.rand.Next(3) == 0)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 61);
        }
    }
}}
