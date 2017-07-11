using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items {
public class PalladiumDisc : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 36;
        item.thrown = true;
        item.width = 48;
        item.height = 48;
        item.useTime = 20;
        item.shootSpeed = 12f;
        item.useAnimation = 20;
        item.useStyle = 1;
        item.knockBack = 3f;
        item.shoot = mod.ProjectileType("PalladiumDiscPro");
        item.value = 27600;
        item.rare = 4;
        item.noUseGraphic = true;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Palladium Disc");
      Tooltip.SetDefault("");
    }


public override bool CanUseItem(Player player)
{
    for (int i = 0; i < 1000; ++i)
    {
        if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
        {
            return false;
        }
    }
    return true;
}
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.PalladiumBar, 12);
        recipe.SetResult(this);
	recipe.AddTile(134);
        recipe.AddRecipe();
    }
}}
