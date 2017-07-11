using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class TheCrescent : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 275;
        item.noMelee = true;
        item.ranged = true;
        item.width = 16;
        item.height = 32;
        item.useTime = 5;
        item.shoot = 1; 
        item.shootSpeed = 11f; 
        item.useAnimation = 25;
        item.useStyle = 5;
        item.knockBack = 1;
        item.value = 10000;
        item.useAmmo = AmmoID.Arrow;
        item.rare = 1;
        item.UseSound = SoundID.Item5;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Crescent");
      Tooltip.SetDefault("");
    }


    public override bool ConsumeAmmo(Player p)
		{
			return Main.rand.Next(2) == 0;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, -2);
        }  

    public override void AddRecipes()                
    {                                                
        ModRecipe recipe = new ModRecipe(mod);     
        recipe.AddIngredient(null, "WhiteGoldBar", 15); 
        recipe.SetResult(this);  
        recipe.AddTile(null, "DivineForgeTile");
        recipe.AddRecipe();
    }   
}}
