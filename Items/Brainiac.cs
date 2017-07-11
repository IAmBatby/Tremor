using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class Brainiac : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 17;
        item.magic = true;
        item.width = 68;
        item.height = 28;
        item.useTime = 30;
        item.useAnimation = 30;
        item.mana=8;
        item.shoot = mod.ProjectileType("BrainiacWavePro");
        item.shootSpeed = 5f; 
        item.useStyle = 5;
        item.knockBack = 4;
        item.value = 325000;

        item.rare = 4;
        item.UseSound = SoundID.Item114;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Brainiac");
      Tooltip.SetDefault("'Shoots mind waves'");
    }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "TheBrain", 1);
        recipe.AddIngredient(null, "AtisBlood", 15);
        recipe.AddIngredient(null, "DrippingRoot", 20);
        recipe.SetResult(this);
        recipe.AddTile(134);
        recipe.AddRecipe();    
    }

}}
