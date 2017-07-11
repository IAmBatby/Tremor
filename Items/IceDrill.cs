using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {

public class IceDrill : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 32;
        item.melee = true;
        item.width = 20;
        item.height = 12;
        item.useTime = 5;
        item.useAnimation = 25;
        item.channel = true;
        item.noUseGraphic = true;
        item.noMelee = true;
        item.pick = 200;
        item.axe = 24;
        item.tileBoost++;
        item.useStyle = 5;
        item.knockBack = 6;
        item.value = Item.buyPrice(0, 20, 0, 0);
        item.rare = 7;
        item.UseSound = SoundID.Item23;
        item.autoReuse = true;
        item.shoot = mod.ProjectileType("IceDrillPro");
        item.shootSpeed = 40f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ice Drill");
      Tooltip.SetDefault("");
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "FrostoneBar", 12);
        recipe.AddTile(134);
        recipe.SetResult(this);
        recipe.AddRecipe();
}
}}
