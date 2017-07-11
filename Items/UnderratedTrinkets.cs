using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class UnderratedTrinkets: ModItem
{


    public override void SetDefaults()
    {

        item.width = 26;
        item.height = 20;
        item.value = 125000;
        item.rare = 10;

        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Underrated Trinkets");
      Tooltip.SetDefault("The less health, the more stats bonuses you gain");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)

        {
           if (player.statMana < 25)
		   {
               player.statDefense += 10;
		   }   
           if (player.statMana < 100)
		   {
               player.statDefense += 8;
		   }   
           if (player.statMana < 200)
		   {
               player.statDefense += 6;
		   }  
           if (player.statMana < 300)
		   {
               player.statDefense += 3;
		   }           
           if (player.statLife < 50) 
		   {
               player.moveSpeed += 1f;
		   }   
           if (player.statLife < 100)
		   {
               player.moveSpeed += 0.9f;
		   }   
           if (player.statLife < 200)
		   {
               player.moveSpeed += 0.7f;
		   }  
           if (player.statLife < 300)
		   {
               player.moveSpeed += 0.5f;
		   }              
           if (player.statLife < 50)
		   {
            player.magicCrit += 20;
            player.meleeCrit += 20;
            player.rangedCrit += 20;
            player.magicDamage += 0.20f;
            player.meleeDamage += 0.20f;
            player.rangedDamage += 0.20f;
		   }   
           if (player.statLife < 100)
		   {
            player.magicCrit += 15;
            player.meleeCrit += 15;
            player.rangedCrit += 15;
            player.magicDamage += 0.15f;
            player.meleeDamage += 0.15f;
            player.rangedDamage += 0.15f;
		   }   
           if (player.statLife < 200)
		   {
            player.magicCrit += 10;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicDamage += 0.10f;
            player.meleeDamage += 0.10f;
            player.rangedDamage += 0.10f;
		   }  
           if (player.statLife < 300)
		   {
            player.magicCrit += 5;
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.rangedDamage += 0.05f;
		   }  
        }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "ChaoticCross", 1);
        recipe.AddIngredient(null, "ShroomiteMagicalBoots", 1);  
        recipe.SetResult(this);
	recipe.AddTile(114);
        recipe.AddRecipe();
    }
}}
