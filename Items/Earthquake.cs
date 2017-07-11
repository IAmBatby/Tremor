using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class Earthquake : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 41;
        item.magic = true;
        item.width = 28;
        item.height = 30;
        item.useTime = 12;
        item.useAnimation = 12;
        item.shootSpeed = 15f; 
	item.mana = 8;
        item.useStyle = 5;
        item.shoot = mod.ProjectileType("EarthquakePro");
        item.knockBack = 3;
        item.value = 10000;
        item.rare = 5;
        item.UseSound = SoundID.Item20;
        item.autoReuse = true;
    }                                                         

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Earthquake");
      Tooltip.SetDefault("");
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.SpellTome, 1);
        recipe.AddIngredient(ItemID.MudBlock, 25);
        recipe.AddIngredient(null, "EarthFragment", 14);
        recipe.AddIngredient(null, "SeaFragment", 10);
        recipe.SetResult(this);
	recipe.AddTile(16);
        recipe.AddRecipe();
    }                    
}} 
