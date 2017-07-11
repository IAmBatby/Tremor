using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class StardustRing : ModItem
{

    public override void SetDefaults()
    {

        item.width = 30;
        item.height = 24;
        item.value = 250000;
        item.rare = 8;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Stardust Ring ");
      Tooltip.SetDefault("20% increased minion damage\nIncreases your maximum number of minions");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)

        {
            player.minionDamage += 0.2f;
            player.maxMinions += 2;
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(3459, 10);
        recipe.AddIngredient(3467, 15);
        recipe.AddIngredient(null, "Band");
        recipe.SetResult(this);
        recipe.AddTile(412);
        recipe.AddRecipe();
    }
}}
