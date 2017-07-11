using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class PalladiumStaff : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 35;
        item.magic = true;
        item.mana = 8;
        item.width = 40;
        item.height = 40;
        item.useTime = 28;
        item.useAnimation = 28;
        item.useStyle = 5;
        item.noMelee = true;
        item.knockBack = 3;
        item.value = 18440;
        item.rare = 4;
        item.UseSound = SoundID.Item101;
        item.autoReuse = true;
        Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        item.shoot = mod.ProjectileType("PalladiumBolt");
        item.shootSpeed = 13f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Palladium Staff");
      Tooltip.SetDefault("");
    }


    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.PalladiumBar, 12);
        recipe.SetResult(this);
	recipe.AddTile(16);
        recipe.AddRecipe();
    }
}}
