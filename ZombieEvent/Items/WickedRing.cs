using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;

namespace Tremor.ZombieEvent.Items {
public class WickedRing : ModItem
{
	
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
	{
    	float spread = 45f * 0.0174f;
    	double startAngle = Math.Atan2(speedX, speedY)- spread/2;
    	double deltaAngle = spread/8f;
    	double offsetAngle;
    	int i;
    	for (i = 0; i < 4; i++ )
    	{
   		offsetAngle = (startAngle + deltaAngle * ( i + i * i ) / 2f ) + 32f * i;
        	Terraria.Projectile.NewProjectile(position.X, position.Y, (float)( Math.Sin(offsetAngle) * 5f ), (float)( Math.Cos(offsetAngle) * 5f ), item.shoot, damage, knockBack, item.owner);
        	Terraria.Projectile.NewProjectile(position.X, position.Y, (float)( -Math.Sin(offsetAngle) * 5f ), (float)( -Math.Cos(offsetAngle) * 5f ), item.shoot, damage, knockBack, item.owner);
    	}
    	return false;
	}

    public override void SetDefaults()
    {

        item.damage = 10;
        item.magic = true;
        item.mana = 30;
        item.useTime = 60;
        item.useAnimation = 60;
        item.knockBack = 5;
        item.value = 2500;
        item.noUseGraphic = true;
        item.rare = 3;
        item.UseSound = SoundID.Item21;
        item.autoReuse = true;
        item.width = 28;
        item.height = 30;
        item.useStyle = 5;

        item.noMelee = true;
        item.shoot = 496;
        item.shootSpeed = 20f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Wicked Ring");
      Tooltip.SetDefault("Releases shadow tentacles in all directions");
    }

    

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "RupicideBar", 3);
        recipe.AddIngredient(ItemID.DemoniteBar, 12);
        recipe.AddIngredient(ItemID.ShadowScale, 12);
        recipe.AddIngredient(null, "WickedHeart", 1);
        recipe.AddTile(null, "NecromaniacWorkbenchTile");
        recipe.SetResult(this);
        recipe.AddRecipe();

        recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "RupicideBar", 3);
        recipe.AddIngredient(ItemID.CrimtaneBar, 12);
        recipe.AddIngredient(ItemID.TissueSample, 12);
        recipe.AddIngredient(null, "WickedHeart", 1);
        recipe.AddTile(null, "NecromaniacWorkbenchTile");
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
