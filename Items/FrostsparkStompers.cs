using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class FrostsparkStompers : ModItem
{

    public override void SetDefaults()
    {

        item.width = 26;
        item.height = 20;
        item.value = 110000;
        item.rare = 3;


        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Frostspark Stompers");
      Tooltip.SetDefault("Increases movement speed by 10% and increases knockback effect\nAllows flight, super fast running, and extra mobility on ice");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)

        {
         player.kbBuff = true;
						player.accRunSpeed = 6.75f;
						player.rocketBoots = 3;
						player.moveSpeed += 0.1f;
						player.iceSkate = true;
        }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(1862, 1);
        recipe.AddIngredient(null, "RockStompers", 1);
        recipe.SetResult(this);
	recipe.AddTile(114);
        recipe.AddRecipe();
    }
}}
