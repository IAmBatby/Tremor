using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class ObsidianHeart : ModItem
{
    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 44;


        item.value = 1200;
        item.rare = 2;
        item.accessory = true;
        item.defense = 4;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Obsidian Heart");
      Tooltip.SetDefault("Increases life regeneration\nGrants immunity to fire blocks");
    }


    public override void UpdateAccessory(Player player, bool hideVisual)
    {
		player.lifeRegen +=1;
                       player.fireWalk = true;
    }
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "HeartofAtis", 1);
        recipe.AddIngredient(ItemID.ObsidianSkull, 1);      
        recipe.SetResult(this);
	recipe.AddTile(114);
        recipe.AddRecipe();
    }

}}
