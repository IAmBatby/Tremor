using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items {

public class NanoSaw : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 18;
        item.melee = true;
        item.width = 20;
        item.height = 12;
        item.useTime = 12;
        item.useAnimation = 25;
        item.channel = true;
        item.noUseGraphic = true;
        item.noMelee = true;
        item.axe = 22;
        item.tileBoost++;
        item.useStyle = 5;
        item.knockBack = 6;
        item.value = Item.buyPrice(0, 4, 50, 0);
        item.rare = 6;
        item.UseSound = SoundID.Item23;
        item.autoReuse = true;
        item.shoot = mod.ProjectileType("NanoSawPro");
        item.shootSpeed = 40f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nano Saw");
      Tooltip.SetDefault("");
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "NanoBar", 15);
        recipe.SetResult(this);
        recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
