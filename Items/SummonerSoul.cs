using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SummonerSoul : ModItem
{

    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 22;


        item.rare = 2;
        item.accessory = true;     
        item.value = 100000;   
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Summoner Soul");
      Tooltip.SetDefault("Increases minion damage by 12%\nIncreases your max number of minions");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
            player.maxMinions += 2;
            player.minionDamage += 0.12f;
}

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "SummonerFocus");
        recipe.AddIngredient(null, "Opal", 3);
        recipe.AddIngredient(ItemID.SummonerEmblem, 1);
        recipe.SetResult(this);
        recipe.AddTile(null, "AltarofEnchantmentsTile");
        recipe.AddRecipe();
    }
}}
