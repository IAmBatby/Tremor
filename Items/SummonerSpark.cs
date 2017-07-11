using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SummonerSpark : ModItem
{

    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 22;


        item.rare = 1;
        item.accessory = true;        
        item.value = 20000;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Summoner Spark");
      Tooltip.SetDefault("Increases minion damage by 5%\nIncreases your max number of minions");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
    }
	
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
            player.maxMinions += 1;
            player.minionDamage += 0.05f;
}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "AdventurerSpark");
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}
