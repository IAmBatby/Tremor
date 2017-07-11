using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class DemoniteProtector : ModItem
{
    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 44;

        item.value = 12500;
        item.rare = 2;
        item.defense = 2;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Demonite Protector");
      Tooltip.SetDefault("Increases max health by 50");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.statLifeMax2 += 50;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.DemoniteBar, 12);
        recipe.AddIngredient(ItemID.ShadowScale, 25);
        recipe.SetResult(this);
        recipe.AddTile(null, "GreatAnvilTile");
        recipe.AddRecipe();
    }
}}
